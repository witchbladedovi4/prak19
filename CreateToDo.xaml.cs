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

            var mainWindow = (MainWindow)Owner;
            if (!dateToDo.SelectedDate.HasValue)
            {
                dateToDo.SelectedDate = DateTime.Now;
            }
            if (string.IsNullOrEmpty(titleToDo.Text)) 
            {
                titleToDo.Text = titleToDo.Text = "Надо навзвание";
            }
            if (string.IsNullOrEmpty(descriptionToDo.Text))
            {
                descriptionToDo.Text = descriptionToDo.Text = "Надо описание";
            }

            mainWindow.Todo.Add(new ToDo(titleToDo.Text,
                                    new DateTime(dateToDo.SelectedDate.Value.Year,
                                                dateToDo.SelectedDate.Value.Month,
                                                dateToDo.SelectedDate.Value.Day),
                                    descriptionToDo.Text));
            this.Close();

        }

    }
}
