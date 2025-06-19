using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp3
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand AddNewTask = new(
            "Добавить задачу",
            "AddNewTask",
            typeof(CustomCommands),
            [new KeyGesture(Key.N, ModifierKeys.Control)]
        );

        public static readonly RoutedUICommand SaveTask = new(
            "Сохранить задачу",
            "SaveTask",
            typeof(CustomCommands),
            [new KeyGesture(Key.S, ModifierKeys.Control)]);

        public static readonly RoutedUICommand DeleteTask = new(
            "Удалить задачу",
            "DeleteTask",
            typeof(CustomCommands),
            [new KeyGesture (Key.Delete)]);

        public static readonly RoutedUICommand Exit = new(
            "Выход",
            "Exit",
            typeof(CustomCommands),
            [new KeyGesture(Key.Enter)]);
    }
}
