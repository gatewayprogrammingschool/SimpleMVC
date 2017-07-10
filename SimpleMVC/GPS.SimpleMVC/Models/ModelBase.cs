using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPS.SimpleMVC.Adapters;

namespace GPS.SimpleMVC.Models
{
    public abstract class ModelBase : INotifyPropertyChanged, IModelBase
    {
        private bool _dirty = false;

        public bool Dirty => _dirty;

        public ModelBase()
        {
            PropertyChanged += ModelBase_PropertyChanged;
        }

        private void ModelBase_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _dirty = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract Task<long> SaveAsync();

        public static Task<ModelBase> LoadAsync(long id)
        {
            throw new NotImplementedException();
        }

        public static Task<ModelBase> LoadAsync(Guid uid)
        {
            throw new NotImplementedException();
        }

        public static Task<List<ModelBase>> SearchAsync(SearchCriteria<ModelBase> criteria)
        {
            throw new NotImplementedException();
        }

        public abstract Task<bool> DeleteAsync();
    }
}
