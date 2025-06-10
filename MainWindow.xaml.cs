using System.Collections.ObjectModel;
using System.IO;
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
using Microsoft.Win32;
using Newtonsoft.Json;


namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<ToDo> Todo = [];


        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            listToDo.ItemsSource = Todo;
            EndTodo();
            listToDo.SelectionChanged += (s, e) => EndTodo();
            Todo.CollectionChanged += (s, e) => EndTodo();
        }
       private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var loadedTodoS = JsonFileService.LoadFromFile();
            Todo.Clear();
            foreach (var todo in loadedTodoS)
            {
                Todo.Add(todo);
            }

            Todo.CollectionChanged += (s, args) =>
            {
                JsonFileService.SaveToFile(Todo);
            };
        }
        private void EndTodo()
        {
            if (Todo.Count == 0)
            {
                progressBar.Minimum = 0;
                progressBar.Maximum = 1;
                progressBar.Value = 0;
                progressText.Text = "0/0";
                return;
            }
           
            
            int doneCount = 0;
            foreach(var todo in Todo)
            {
                if (todo.IsDone)
                {
                    doneCount++;
                }
            }

            progressBar.Minimum = 0;
            progressBar.Maximum = Todo.Count;
            progressBar.Value = doneCount;
            progressText.Text = $"{doneCount}/{Todo.Count}";
        }
        private void CheckBox_Cheked(object sender, RoutedEventArgs e)
        {
            var todo = (sender as CheckBox)?.DataContext as ToDo;
            if (todo != null)
            {
                EndTodo();
            }

            if (listToDo?.Visibility != null)
            {
                listToDo.Visibility = Visibility.Visible;
            }
        }

        private void CheckBox_Uncheked(object sender, RoutedEventArgs e)
        {
            var todo = (sender as CheckBox)?.DataContext as ToDo;
            EndTodo();

            listToDo.Visibility = Visibility.Hidden;
        }


        private void DeleteToDo(object sender, RoutedEventArgs e)
        {
            var resulr =MessageBox.Show("Вы уверены, что хотите удалить дело", "Удаление дела", 
                MessageBoxButton.YesNo);
            if (resulr == MessageBoxResult.Yes)
            {
                var button = sender as Button;
                if (button == null) return;

                var todoToDelete = button.DataContext as ToDo;
                if (todoToDelete == null) return;

                Todo.Remove(todoToDelete);
                EndTodo();
            }
            else return;
        }
        

        private void AddNewTask_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var newWindow = new CreateToDo
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            newWindow.ShowDialog();
        }

        private void AddNewTask_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveTask_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (Todo.Count == 0)
            {
                MessageBox.Show($"В списке нет дел", "", MessageBoxButton.OK);
                return;
            }
            var saveFile = new SaveFileDialog
            {
                Filter = "JSON файл (*.json)|*.json|" +
                "Текстовый файл (*.txt)|.txt",
                DefaultExt = ".json",
                Title = "Сохранить список задач",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (saveFile.ShowDialog() == true)
            {
                string filePath = saveFile.FileName;
                try
                {
                    if (filePath.EndsWith(".json"))
                    {
                        string json = JsonConvert.SerializeObject(Todo, Formatting.Indented);
                        File.WriteAllText(filePath, json);
                    }
                    else if (filePath.EndsWith(".txt"))
                    {

                        using (StreamWriter writer = new StreamWriter(saveFile.FileName))
                        {
                            foreach (var item in Todo)
                            {
                                if (item.IsDone == true)
                                {
                                    writer.WriteLine($"✔{item.Name}");
                                }
                                else
                                {
                                    writer.WriteLine(item.Name);
                                }
                                writer.WriteLine($"\n{item.Date}");
                                writer.WriteLine($"\n{item.Description}\n\n");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неизвестный формат файла", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show($"Задачи сохранены в файл:\n{filePath}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        
        

        private void SaveTask_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeleteTask_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (listToDo.SelectedItem is ToDo selectedTask)
            {
                var resulr = MessageBox.Show("Вы уверены, что хотите удалить дело", "Удаление дела",
                MessageBoxButton.YesNo);
                if (resulr == MessageBoxResult.Yes)
                {
                    Todo.Remove(selectedTask);
                    EndTodo();
                }
                else return;

            }

            
        }

        private void DeleteTask_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listToDo.SelectedItem != null;
        }
    }
}

