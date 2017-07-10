using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPS.SimpleDI;
using System.Reflection;
using System.Globalization;
using GPS.SimpleMVC.Adapters;
using GPS.SimpleMVC.Models;

namespace GPS.SimpleMVC.DI
{
    public class LoadModelAdapterInjector : IInjectable
    {
        public string TypeNamespace { get; set; }
        public string TypeName { get; set; }
        public List<List<Parameter>> Constructors { get; set; }
        public List<Method> Methods { get; set; }

        public object MakeObject(List<Parameter> parameters)
        {
            var assm = Assembly.Load(TypeNamespace);

            var itype = Type.GetType(TypeName,
                null,
                (assembly, name, b) =>
                    assm.GetType(name, true, b),
                true, false);


            var passm = Assembly.Load(parameters[0].TypeNamespace);

            var ptype = Type.GetType(
                parameters[0].TypeName,
                null,
                (assembly, name, b) =>
                    passm.GetType(name, true, b),
                true,
                false);

            var param1 = Activator.CreateInstance(
                        ptype,
                        BindingFlags.Public | BindingFlags.Instance,
                        null,
                        new[] { (parameters[0].Value as string)?.ToCharArray() },
                        CultureInfo.CurrentCulture
                    );

            var obj = Activator.CreateInstance(
                itype,
                BindingFlags.Instance | BindingFlags.Public,
                null,
                new[] { param1 },
                CultureInfo.CurrentCulture);

            if (obj is LoadModelAdapterBase<IModelBase>)
            {
                return obj as LoadModelAdapterBase<IModelBase>;
            }

            throw new ApplicationException("Object is not of type T");
        }

        public object MakeObject()
        {
            var assm = Assembly.Load(TypeNamespace);

            var itype = Type.GetType(TypeName,
                null,
                (assembly, name, b) =>
                    assm.GetType(name, true, b),
                true, false);

            var obj = Activator.CreateInstance(itype,
                BindingFlags.Instance | BindingFlags.Public,
                null,
                new object[0],
                CultureInfo.CurrentCulture);

            if (obj is LoadModelAdapterBase<ModelBase>)
            {
                return ((LoadModelAdapterBase<ModelBase>)obj);
            }

            throw new ApplicationException("Object is not of type T");
        }
    }
}
