using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPS.SimpleDI;
using GPS.SimpleMVC.Tests.ModelImplementations;

namespace GPS.SimpleMVC.Tests.AdapterImplementations
{
    public class TestLoadAdapterInjector : IInjectable
    {
        public TestLoadAdapterInjector()
        {
        }

        public object MakeObject(List<Parameter> parameters)
        {
            throw new NotImplementedException("TestLoadAdapter does not take parameters on its constructor.");
        }

        public object MakeObject()
        {
            return new TestLoadAdapter();
        }

        public string TypeNamespace { get; set; }
        public string TypeName { get; set; }
        public List<List<Parameter>> Constructors { get; set; }
        public List<Method> Methods { get; set; }
    }
}
