using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FrigoApp.Model
{
    public class Container
    {
        public String id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "proprio")]
        public String Proprio { get; set; }

        [JsonProperty(PropertyName = "isFreezer")]
        public Boolean IsFreezer { get; set; }

        public Container()
        {

        }

        public Container(String name, String proprio, Boolean isFreezer)
        {
            Name = name;
            Proprio = proprio;
            IsFreezer = isFreezer;
        }

        public override String ToString()
        {
            return Name;
        }
    }
}
