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


        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(titleToDo.Text))
                titleToDo.Text = "Название обязательно";

            if (!dateToDo.SelectedDate.HasValue)
                dateToDo.SelectedDate = DateTime.Now;

  
            var mainWindow = (MainWindow)Owner;
            mainWindow.Todo.Add(new ToDo(
                titleToDo.Text,
                dateToDo.SelectedDate.Value,
                descriptionToDo.Text ?? "Нет описания"
            ));


            this.Close();
        }

        private void Exit_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrWhiteSpace(titleToDo.Text)
                && dateToDo.SelectedDate.HasValue;
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if (e.OriginalSource is not TextBox)
            {

                Keyboard.ClearFocus();


            }
        }
    }
}
