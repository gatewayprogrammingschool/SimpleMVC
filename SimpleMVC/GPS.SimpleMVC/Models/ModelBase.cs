using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleMVC.Models
{
    public abstract class ModelBase : INotifyPropertyChanged
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

        public abstract Task<int> SaveAsync();

        public abstract Task<int> LoadAsync();

        public abstract Task<bool> DeleteAsync();
    }
}
