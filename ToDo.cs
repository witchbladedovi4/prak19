using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class ToDo(string name, DateTime date, string description)
    {
        private string name_ = name;
        private DateTime date_ = date;
        private string description_ = description;

        public string Name { get { return name_; } }
        public DateTime Date { get { return date_; } }
        public string Description { get { return description_; } }
    }
}
