using GPS.SimpleMVC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleMVC.Controllers
{
    public abstract class SimpleControllerBase : IDisposable
    {
        private Dictionary<Guid, ISimpleView> _views = new Dictionary<Guid, ISimpleView>();

        protected Dictionary<Guid, ISimpleView> Views => _views;

        public bool AddView(ISimpleView view)
        {
            if(!_views.ContainsKey(view.ViewKey))
            {
                _views.Add(view.ViewKey, view);
                return _views.ContainsKey(view.ViewKey);
            }

            return false;
        }

        public T GetView<T>(Guid key) where T: class, ISimpleView
        {
            if(_views.ContainsKey(key))
            {
                return _views[key] as T;
            }

            return null;
        }

        public bool RemoveView(ISimpleView view)
        {
            var toDelete = _views[view.ViewKey];

            if(toDelete != null && toDelete == view)
            {
                return _views.Remove(view.ViewKey);
            }

            return false;
        }

        public abstract bool Initialize();

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _views.Clear();
                    _views = null;
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
