﻿using AttackPlayers;
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


            Player player = new Player("joueur", 40, 40, 1);
            player.Attack.Add(new AttackPlayer("Coup de pied", 10, 0));
            player.Attack.Add(new AttackPlayer("Coup de poing", 10, 0));
            player.Attack.Add(new AttackPlayer("FireBall", 25, 10));
            player.Attack.Add(new AttackPlayer("Thunder", 30, 15));


            DashboardVM = new DashboardViewModel();
            GameVM = new GameViewModel();
            TaskVM = new TaskViewModel() ;


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

            GameVM.InitializeGame(player);
        }

        private void CloseWindow(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
