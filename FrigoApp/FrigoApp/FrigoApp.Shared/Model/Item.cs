using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FrigoApp.Model
{
    public class Item
    {
        public String id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "type")]
        public String Type { get; set; }

        [JsonProperty(PropertyName = "expirationdate")]
        public DateTime Expirationdate { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "idcontainer")]
        public int Idcontainer { get; set; }

        public Item()
        {

        }

        public Item(String name, String type, DateTime expirationdate, int quantity, int idContainer)
        {
            Name = name;
            Type = type;
            Expirationdate = expirationdate;
            Quantity = quantity;
            Idcontainer = idContainer;

        }

        public override String ToString()
        {
            return Name;
        }
    }
}
