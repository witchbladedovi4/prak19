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

    public partial class CreateToDo : Window
    {
        public CreateToDo()
        {
            InitializeComponent();
            dateToDo.SelectedDate = DateTime.Now;
        }


        private void Exit_Executed(object sender, ExecutedRoutedEventArgs? e)
        {
            if (string.IsNullOrEmpty(titleToDo.Text))
            {
                titleToDo.Text = "Без названия";
                titleToDo.Focus(); // Фокус на поле с ошибкой
                return;
            }

            var mainWindow = (MainWindow)Owner;
            mainWindow.Todo.Add(new ToDo(
                titleToDo.Text,
                dateToDo.SelectedDate ?? DateTime.Now,
                descriptionToDo.Text ?? "Нет описания"
            ));

            this.Close();
        }

        private void Exit_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(titleToDo.Text);
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Shift+Enter - перенос строки
            if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.Shift && Keyboard.FocusedElement == descriptionToDo)
            {
                var textBox = Keyboard.FocusedElement as TextBox;
                if (textBox != null)
                {
                    int caretIndex = textBox.CaretIndex;
                    textBox.Text = textBox.Text.Insert(caretIndex, Environment.NewLine);
                    textBox.CaretIndex = caretIndex + Environment.NewLine.Length;
                    e.Handled = true;
                }
                return;
            }
            // Enter (без Shift) - сохранить
            if (e.Key == Key.Enter)
            {
                
                Exit_Executed(sender, null);
                e.Handled = true; 
            }
            
            



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(titleToDo.Text))
            {
                titleToDo.Text = "Без названия";
                titleToDo.Focus();
                return;
            }

            var mainWindow = (MainWindow)Owner;
            mainWindow.Todo.Add(new ToDo(
                titleToDo.Text,
                dateToDo.SelectedDate ?? DateTime.Now,
                descriptionToDo.Text ?? "Нет описания"
            ));

            this.Close();
        }
    }
}
