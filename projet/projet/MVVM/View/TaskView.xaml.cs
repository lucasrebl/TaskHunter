using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task;

namespace projet.MVVM.View
{
    public partial class TaskView : UserControl
    {
        private TaskListManager taskListManager;
        public TaskView()
        {
            InitializeComponent();
            taskListManager = new TaskListManager(new Inventorys.Inventory(0, 0, 0, 0));

            taskListBox.ItemsSource = taskListManager.Tasks;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string newTask = ToDoListTitle.Text;
            DateTime selectedDate = calendarDatePicker.SelectedDate ?? DateTime.Now;
            taskListManager.AddTask(newTask, selectedDate);
            ToDoListTitle.Text = "";
        }

        private void ToDoListTitle_GotFocus(object sender, RoutedEventArgs e)
        {
            ToDoListTitle.Text = "";
        }

        private void ToDoListTitle_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Gestion de la modification du texte, si nécessaire
        }

        private const string CompleteButtonName = "completeButton";
        private const string DeleteButtonName = "deleteButton";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonBase button = (ButtonBase)sender;
            TaskItem task = (TaskItem)button.DataContext;

            if (task != null)
            {
                if (button.Name == CompleteButtonName)
                {
                    taskListManager.CompleteTask(task);
                    taskListManager.Tasks.Remove(task);

                    int rewardAmount = taskListManager.GetRandomReward();
                    string rewardType = taskListManager.GetRewardType(rewardAmount);

                    statusLabel.Text = $"Félicitations ! Vous avez reçu {taskListManager.TotalReward} {rewardType} en récompense. ";
                }
                else if (button.Name == DeleteButtonName)
                {
                    if (taskListManager.Tasks.Contains(task))
                    {
                        taskListManager.Tasks.Remove(task);
                    }
                }
            }
        }
    }
}
