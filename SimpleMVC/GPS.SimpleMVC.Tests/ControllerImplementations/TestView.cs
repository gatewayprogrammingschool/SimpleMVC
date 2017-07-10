using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleMVC.Tests.ControllerImplementations
{
    public class TestView : ITestView
    {
        // ISimpleView
        private readonly Guid _key = Guid.NewGuid();
        public Guid ViewKey => _key;

        // ITestView
        public Guid UID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public event EventHandler<Guid> LoadData;
        public event EventHandler DataBound;

        public void Databind()
        {
            Console.WriteLine("In Databind...");
            DataBound?.Invoke(this, EventArgs.Empty);
        }

        public void InvokeLoadData(Guid uid)
        {
            LoadData?.Invoke(this, uid);
        }
    }
}
