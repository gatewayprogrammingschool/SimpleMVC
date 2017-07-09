using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleMVC.Models
{
    public abstract class LoadModelAdapterBase<T> where T: ModelBase
    {
        public async virtual Task<T> LoadSingle(Guid uid)
        {
            var def = default(T);

            var adapter =
                GPS.SimpleDI.SimpleDiFactory.Load(def.GetType());

            return await ((IModelAdapterDataProvider<T>)adapter.MakeObject()).LoadModel(uid);
        }

        public async virtual Task<T> LoadSingle(long id)
        {
            var def = default(T);

            var adapter =
                GPS.SimpleDI.SimpleDiFactory.Load(def.GetType());

            return await ((IModelAdapterDataProvider<T>)adapter.MakeObject()).LoadModel(id);
        }

        public async virtual Task<T> LoadSingle(int id)
        {
            var def = default(T);

            var adapter =
                GPS.SimpleDI.SimpleDiFactory.Load(def.GetType());

            return await ((IModelAdapterDataProvider<T>)adapter.MakeObject()).LoadModel(id);
        }
    }
}

