using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp3.Models 
{
    [JsonObject]
    public partial class ToDo : ObservableObject
    {
        [JsonProperty("name")]
        [ObservableProperty]
        private readonly string _name;

        [JsonProperty("date")]
        [ObservableProperty]
        private readonly DateTime _date;

        [JsonProperty ("description")]
        [ObservableProperty]
        private readonly string _description;

        [JsonProperty ("isDone")]
        [ObservableProperty]
        private readonly bool _isDone;

        public ToDo(string name, DateTime date, string description)
        {
            _name = name;
            _date = date;
            _description = description;
            _isDone = false;
        }

        // Пустой конструктор для десериализации
        [JsonConstructor]
        public ToDo() { }

        
    }
}
