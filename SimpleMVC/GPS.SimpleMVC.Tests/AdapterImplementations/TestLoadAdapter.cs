using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPS.SimpleMVC.Adapters;
using GPS.SimpleMVC.Models;
using GPS.SimpleMVC.Tests.ModelImplementations;

namespace GPS.SimpleMVC.Tests.AdapterImplementations
{
    public class TestLoadAdapter : IModelAdapterDataProvider
    {
        public async Task<IModelBase> LoadModel(Guid uid)
        {
            var model = await new TaskFactory().StartNew(() => new TestModel() { Value = "Loaded by GUID", UID = uid, Name= "TestModel" });

            return model;
        }

        public async Task<IModelBase> LoadModel(long id)
        {
            var model = await new TaskFactory().StartNew(() => new TestModel {Name="TestModel", Value="Loaded by ID", ID = id});
            return model;
        }

        public async Task<List<IModelBase>> LoadModels(SearchBy<IModelBase> root)
        {
            var model = await new TaskFactory().StartNew(() => new TestModel());
            return new List<IModelBase> {model};
        }

        public async Task<long> SaveModels(List<IModelBase> models)
        {
            return default(long);
        }

        public async Task<bool> DeleteModel(IModelBase model)
        {
            return default(bool);
        }
    }
}
