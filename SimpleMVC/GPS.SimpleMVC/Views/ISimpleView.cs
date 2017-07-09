using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleMVC.Views
{
    public interface ISimpleView
    {
        Guid ViewKey { get; }
    }
}
