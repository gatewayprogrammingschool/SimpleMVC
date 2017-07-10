using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GPS.SimpleMVC.Models;

namespace GPS.SimpleMVC.Adapters
{
    public interface IModelAdapterDataProvider
    {
        Task<IModelBase> LoadModel(Guid uid);
        Task<IModelBase> LoadModel(long id);

        Task<List<IModelBase>> LoadModels(SearchBy<IModelBase> root);
        Task<long> SaveModels(List<IModelBase> models);
        Task<bool> DeleteModel(IModelBase model);
    }

    public delegate List<IModelBase> SearchBy<IModelBase>(SearchNode<object> root);
}
