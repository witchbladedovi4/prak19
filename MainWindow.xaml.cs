using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<ToDo> Todo = new ObservableCollection<ToDo>();

        public MainWindow()
        {
            InitializeComponent();

            Todo.Add(new ToDo("Приготовить покушать", new DateTime(2024, 1, 15), "Описания нет"));
            Todo.Add(new ToDo("Поработать", new DateTime(2024, 1, 20), "Сьездить на совещения в Москву"));
            Todo.Add(new ToDo("Отдохнуть", new DateTime(2024, 1, 1), "Сьездить в отпуску в Сочи"));
            listToDo.ItemsSource = Todo;
        }

        private void CheckBox_Cheked(object sender, RoutedEventArgs e)
        {
            if (listToDo?.Visibility != null)
            {
                listToDo.Visibility = Visibility.Visible;
            }
        }

        private void CheckBox_Uncheked(object sender, RoutedEventArgs e)
        {
            listToDo.Visibility = Visibility.Hidden;
        }

        private void CreateToDo(object sender, RoutedEventArgs e)
        {
            var newwin = new CreateToDo();
            newwin.Owner = this;
            newwin.Show();
        }

        private void DeleteToDo(object sender, RoutedEventArgs e)
        {
            if (listToDo.SelectedItem as ToDo == null) { return; }
            else
            {
                Todo.Remove(listToDo.SelectedItem as ToDo);
            }
        }

    }
}
