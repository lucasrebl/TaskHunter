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
            TaskVM = new TaskViewModel();

            CloseWindowCommand = new RelayCommand(CloseWindow);

            CurrentView = DashboardVM;

            DashboardViewCommand = new RelayCommand(o =>
            {
                CurrentView = DashboardVM;
            });

            GameViewCommand = new RelayCommand(o =>
            {
                CurrentView = GameVM;
            });

            TaskViewCommand = new RelayCommand(o =>
            {
                CurrentView = TaskVM;
            });
        }

        private void CloseWindow(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
