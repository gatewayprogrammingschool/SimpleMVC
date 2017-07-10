using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GenericExtensionMethods;
using GPS.SimpleDI;
using GPS.SimpleMVC.Models;
using GPS.SimpleMVC.Tests.AdapterImplementations;
using Newtonsoft.Json;

namespace GPS.SimpleMVC.Tests.ModelImplementations
{
    public class TestModel : ModelBase
    {
        public long ID { get; set; } = 0L;
        public string Name { get; set; } = "ModelBase";
        public string Value { get; set; } = "Default";
        public Guid UID { get; set; }

        private static async Task<TestLoadAdapter> GetLoadAdapter()
        {
            var type = typeof(TestLoadAdapterDependencyBuilder);
            try
            {
                var data = File.ReadAllText("ModelImplementations/DefaultTestModelAdapterDefinition.json");

                dynamic obj = JsonConvert.DeserializeObject(data);

                type = Type.GetType(obj.TypeName as string ?? 
                    "GPS.SimpleMVC.Tests.AdapterImplementations.TestLoadAdapterDependencyBuilder");
            }
            catch (Exception e)
            {
                throw new ApplicationException("Could not load JSON", e);
            }

            var injector = SimpleDiFactory.Load<IInjectable>(type);
            return new TaskFactory().StartNew(() => ((TestLoadAdapterInjector)injector).MakeObject() as TestLoadAdapter).Result;
        }

        public override async Task<long> SaveAsync()
        {
            var loadAdapter = await GetLoadAdapter();
            return await loadAdapter.SaveModels(new List<IModelBase> {this});
        }

        public new static async Task<IModelBase> LoadAsync(long id)
        {
            var adapter = await GetLoadAdapter();

            if (adapter == null) throw new ApplicationException("adapter is null");

            var model = await adapter.LoadModel(id);

            return model;
        }

        public new static async Task<IModelBase> LoadAsync(Guid uid)
        {
            var adapter = await GetLoadAdapter();

            if (adapter == null) throw new ApplicationException("adapter is null");

            var model = await adapter.LoadModel(uid);

            return model;
        }

        public override async Task<bool> DeleteAsync()
        {
            return await GetLoadAdapter().Result.DeleteModel(this);
        }
    }
}
