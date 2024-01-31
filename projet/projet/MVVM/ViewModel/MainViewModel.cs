using AttackPlayers;
using Inventorys;
using Players;
using projet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace projet.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand DashboardViewCommand { get; set; }
        public RelayCommand GameViewCommand { get; set; }
        public RelayCommand TaskViewCommand { get; set; }
        public ICommand CloseWindowCommand { get; }

        public DashboardViewModel DashboardVM { get; set; }
        public GameViewModel GameVM { get; set; }
        public TaskViewModel TaskVM { get; set; }
        public RelayCommand StartGameCommand { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChange();
            }
        }

        public MainViewModel()
        {
            DashboardVM = new DashboardViewModel();
            GameVM = new GameViewModel();
            TaskVM = new TaskViewModel() ;


            CloseWindowCommand = new RelayCommand(CloseWindow);

            Player player = Player.Instance;
            DashboardVM.InitializeDashboard(player);
            CurrentView = DashboardVM;

            DashboardViewCommand = new RelayCommand(o =>
            {
                DashboardVM.InitializeDashboard(player);
                CurrentView = DashboardVM;
            });

            GameViewCommand = new RelayCommand(o =>
            {
                GameVM.UpdateStats();
                CurrentView = GameVM;
            });

            TaskViewCommand = new RelayCommand(o =>
            {
                TaskVM.InitializeTasks(player);
                CurrentView = TaskVM;
            });

            GameVM.InitializeGame(player);
        }
        private void CloseWindow(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
