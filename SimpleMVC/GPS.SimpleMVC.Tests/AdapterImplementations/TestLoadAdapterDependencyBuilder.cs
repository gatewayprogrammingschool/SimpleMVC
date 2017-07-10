using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPS.SimpleDI;
using GPS.SimpleMVC.DI;
using Newtonsoft.Json;

namespace GPS.SimpleMVC.Tests.AdapterImplementations
{
    public class TestLoadAdapterDependencyBuilder : IDefinitionLoader<TestLoadAdapterInjector>
    {
        private TestLoadAdapterInjector _definitionLoaderImplementation;

        public TestLoadAdapterInjector LoadDefintion()
        {
            if (_definitionLoaderImplementation == null)
            {
                _definitionLoaderImplementation = new TestLoadAdapterInjector();
            }
            return _definitionLoaderImplementation;
        }
    }
}
