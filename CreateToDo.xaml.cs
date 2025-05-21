using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для CreateToDo.xaml
    /// </summary>
    public partial class CreateToDo : Window
    {
        public CreateToDo()
        {
            InitializeComponent();
            dateToDo.SelectedDate = DateTime.Now;
        }

        private void SaveToDo(object sender, RoutedEventArgs e)
        {
            var temp = dateToDo.SelectedDate.Value;
            var mainWindow = (MainWindow)Owner;
            mainWindow.ToDoList.Add(new ToDo(titleToDo.Text, new DateTime(temp.Year, temp.Month, temp.Day), descriptionToDo.Text));
            this.Close();
        }

    }
}
