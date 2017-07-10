using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPS.SimpleMVC.Views;

namespace GPS.SimpleMVC.Tests.ControllerImplementations
{
    internal interface ITestView : ISimpleView
    {
        Guid UID { get; set; }
        string Name { get; set; }
        string Value { get; set; }

        event EventHandler<Guid> LoadData;
        event EventHandler DataBound;

        void Databind();
    }
}
