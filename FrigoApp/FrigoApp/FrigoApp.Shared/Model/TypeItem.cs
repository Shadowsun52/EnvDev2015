using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrigoApp.Model
{
    public class TypeItem
    {
        public String id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "freezeExpiration")]
        public int FreezeExpiration { get; set; }

        public TypeItem()
        {

        }

        public TypeItem(String name, int freezeExpiration)
        {
            Name = name;
            FreezeExpiration = freezeExpiration;
        }

        public override String ToString()
        {
            return Name;
        }
    }
}
