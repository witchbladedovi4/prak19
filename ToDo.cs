using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    [JsonObject]
    public class ToDo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isDone")]
        public bool IsDone { get; set; }

        public ToDo(string name, DateTime date, string description)
        {
            Name = name;
            Date = date;
            Description = description;
            IsDone = false;
        }

        // Пустой конструктор для десериализации
        [JsonConstructor]
        public ToDo() { }
    }
}
