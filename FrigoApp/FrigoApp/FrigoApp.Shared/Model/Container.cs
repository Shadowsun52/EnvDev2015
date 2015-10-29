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

        [JsonProperty(PropertyName = "type")]
        public String Type { get; set; }

        [JsonProperty(PropertyName = "proprio")]
        public String Proprio { get; set; }

        public Container()
        {

        }

        public Container(String name, String type, String proprio)
        {
            Name = name;
            Type = type;
            Proprio = proprio;
        }

        public override String ToString()
        {
            return Name;
        }
    }
}
