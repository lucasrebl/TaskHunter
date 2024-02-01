using Players;
using projet.Core;
using projet.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace projet.MVVM.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private Player _actualPlayer;

        public Player ActualPlayer
        {
            get { return _actualPlayer; }
            set
            {
                if (_actualPlayer != value)
                {
                    _actualPlayer = value;
                    OnPropertyChanged(nameof(ActualPlayer));
                }
            }
        }

        private string _newTaskTitle;
        public int TotalReward = 0;
        public string NewTaskTitle
        {
            get { return _newTaskTitle; }
            set
            {
                if (_newTaskTitle != value)
                {
                    _newTaskTitle = value;
                    OnPropertyChanged(nameof(NewTaskTitle));
                }
            }
        }

        private string _taskMessage;
        public string TaskMessage
        {
            get { return _taskMessage; }
            set
            {
                if (_taskMessage != value)
                {
                    _taskMessage = value;
                    OnPropertyChanged(nameof(TaskMessage));
                }
            }
        }

        private DateTime _newTaskDate;
        public DateTime NewTaskDate
        {
            get { return _newTaskDate; }
            set
            {
                if (_newTaskDate != value)
                {
                    _newTaskDate = value;
                    OnPropertyChanged(nameof(NewTaskDate));
                }
            }
        }

        public ICommand AddTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }
        public ICommand CompleteTaskCommand { get; }
        public TaskViewModel()
        {
            Tasks = new ObservableCollection<TaskListManager>();
            AddTaskCommand = new RelayCommand(AddTask);
            CompleteTaskCommand = new RelayCommand(CompleteTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask);
            NewTaskDate = DateTime.Now;
        }

        private void AddTask(object parameter)
        {
            TaskListManager newTask = new TaskListManager
            {
                Title = NewTaskTitle,
                Date = NewTaskDate
            };

            Tasks.Add(newTask);

            NewTaskTitle = string.Empty;
            NewTaskDate = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<TaskListManager> _tasks;
        public ObservableCollection<TaskListManager> Tasks
        {
            get { return _tasks; }
            set
            {
                if (_tasks != value)
                {
                    _tasks = value;
                    OnPropertyChanged(nameof(Tasks));
                }
            }
        }

        public void InitializeTasks(Player player)
        {
            ActualPlayer = player;
            TaskMessage = string.Empty;
        }

        private Random random = new Random();
        private void CompleteTask(object parameter)
        {
            if (parameter is TaskListManager task)
            {
                task.IsCompleted = true;
                Tasks.Remove(task);
                int rewardAmount = GetRandomReward();
                random = new Random();
                int randomRes = random.Next(1, 5);
                ActualPlayer.UpdateInventory(rewardAmount, randomRes);
                switch (randomRes)
                {
                    case 1:
                        TaskMessage = $"Vous avez obtenu {rewardAmount} Potion(s) de vie !";
                        break;
                    case 2:
                        TaskMessage = $"Vous avez obtenu {rewardAmount} Potion(s) de mana !";
                        break;
                    case 3:
                        TaskMessage = $"Vous avez obtenu {rewardAmount} Parchemin(s) de vie !";
                        break;
                    case 4:
                        TaskMessage = $"Vous avez obtenu {rewardAmount} Parchemin(s) de mana !";
                        break;
                    default:
                        TaskMessage = $"Vous avez obtenu {rewardAmount} {randomRes} !";
                        break;
                }
            }
        }


        public int GetRandomReward()
        {
            return random.Next(1, 4);
        }

        /*private void ApplyRewardToInventory(int rewardAmount)
        {
                switch (rewardAmount)
                {
                    case 1:
                        ActualPlayer.Inventory.PotionPv += TotalReward;
                        break;
                    case 2:
                        ActualPlayer.Inventory.PotionMana += TotalReward;
                        break;
                    case 3:
                        ActualPlayer.Inventory.ParchmentPv += TotalReward;
                        break;
                    case 4:
                        ActualPlayer.Inventory.ParchmentMana += TotalReward;
                        break;
                }
        }

        public string GetRewardType(int rewardAmount)
        {
            switch (rewardAmount)
            {
                case 1:
                    return "Potion de Vie";
                case 2:
                    return "Potion de Mana";
                case 3:
                    return "Parchemin de Vie";
                case 4:
                    return "Parchemin de Mana";
                default:
                    return "Récompense non spécifiée";
            }
        }*/

        private void DeleteTask(object parameter)
        {
            if (parameter is TaskListManager task)
            {
                Tasks.Remove(task);
                TaskMessage = $"Vous avez supprimé une tâche !";
            }
        }
    }
}
