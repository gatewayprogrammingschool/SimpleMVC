using System;
using System.Threading.Tasks;
using GPS.SimpleMVC.Models;
using GPS.SimpleDI;
using GPS.SimpleMVC.DI;

namespace GPS.SimpleMVC.Adapters
{
    public abstract class LoadModelAdapterBase<T> where T: class
    {
        public async virtual Task<T> LoadSingle(Guid uid)
        {
            var def = default(T);

            var adapter =
                GPS.SimpleDI.SimpleDiFactory.Load<LoadModelAdapterInjector>(def.GetType());

            return await ((IModelAdapterDataProvider)adapter.MakeObject()).LoadModel(uid) as T;
        }

        public async virtual Task<T> LoadSingle(long id)
        {
            var def = default(T);

            var adapter =
                GPS.SimpleDI.SimpleDiFactory.Load<LoadModelAdapterInjector>(def.GetType());

            return await new TaskFactory().StartNew<T>(() => ((IModelAdapterDataProvider)adapter.MakeObject()).LoadModel(id) as T);
        }

        public async virtual Task<T> LoadSingle(int id)
        {
            var def = default(T);

            var adapter =
                GPS.SimpleDI.SimpleDiFactory.Load<LoadModelAdapterInjector>(def.GetType());

            return await ((IModelAdapterDataProvider)adapter.MakeObject()).LoadModel(id) as T;
        }
    }
}

