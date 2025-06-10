using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public static class JsonFileService
    {
        private static readonly string _filePath = "todos.json";

        public static ObservableCollection<ToDo> LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return new ObservableCollection<ToDo>();

            try
            {
                string json = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<ObservableCollection<ToDo>>(json);
            }
            catch
            {
                return new ObservableCollection<ToDo>();
            }
        }

        public static void SaveToFile(ObservableCollection<ToDo> todos)
        {
            string json = JsonConvert.SerializeObject(todos, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
