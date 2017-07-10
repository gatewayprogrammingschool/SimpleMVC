using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPS.SimpleMVC.Controllers;
using GPS.SimpleMVC.Tests.ModelImplementations;

namespace GPS.SimpleMVC.Tests.ControllerImplementations
{
    public class TestController : SimpleControllerBase
    {
        public override bool Initialize()
        {
            var result = true;

            foreach (var view in Views.Values)
            {
                if (view is ITestView)
                {
                    var tv = view as ITestView;

                    tv.LoadData += TvOnLoadData;

                    result &= true;
                }
                else
                {
                    Console.WriteLine($"{view.GetType().FullName} is invalid for this controller.");
                    result = false;
                }
            }

            return result;
        }

        private async void TvOnLoadData(object sender, Guid guid)
        {
            var testModel = await TestModel.LoadAsync(guid) as TestModel;

            if (testModel == null)
            {
                throw new ApplicationException("Could not load model.");
            }

            var tv = sender as ITestView;

            if (tv == null)
            {
                throw new ApplicationException("Invalid sender.");
            }

            tv.Value = testModel.Value;
            tv.Name = testModel.Name;
            tv.UID = testModel.UID;

            tv.Databind();
        }
    }
}
