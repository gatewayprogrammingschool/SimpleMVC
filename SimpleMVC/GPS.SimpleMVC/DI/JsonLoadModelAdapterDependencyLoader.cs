using GPS.SimpleDI;
using GPS.SimpleMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleMVC.DI
{
    public class JsonLoadModelAdapterDependencyLoader : IDefinitionLoader<LoadModelAdapterInjector>
    {
        private string _json;

        public JsonLoadModelAdapterDependencyLoader(string json)
        {
            _json = json;
        }

        public LoadModelAdapterInjector LoadDefintion()
        {
            return JsonConvert.DeserializeObject<LoadModelAdapterInjector>(_json);
        }
    }
}
