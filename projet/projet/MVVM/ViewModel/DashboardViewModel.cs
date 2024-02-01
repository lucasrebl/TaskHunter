using Players;
using System.Collections.ObjectModel;
using System.ComponentModel;
using projet.MVVM.Model;

namespace projet.MVVM.ViewModel
{
    class DashboardViewModel : INotifyPropertyChanged
    {
        private Player _actualPlayer;
        private string _playerLife;
        private string _playerMana;
        private string _playerLevel;
        private string _playerXpNeeded;
        private string _playerXp;
        private string _playerWins;
        private string _potionMana;
        private string _parchmentPv;
        private string _parchmentMana;
        private string _potionPv;
        private ObservableCollection<PokedexItem> _pokedex;

        public ObservableCollection<PokedexItem> Pokedex
        {
            get { return _pokedex; }
            set
            {
                if (_pokedex != value)
                {
                    _pokedex = value;
                    OnPropertyChanged(nameof(Pokedex));
                }
            }
        }
        public string ParchmentPv
        {
            get { return _parchmentPv; }
            set
            {
                if (_parchmentPv != value)
                {
                    _parchmentPv = value;
                    OnPropertyChanged(nameof(ParchmentPv));
                }
            }
        }

        public string ParchmentMana
        {
            get { return _parchmentMana; }
            set
            {
                if (_parchmentMana != value)
                {
                    _parchmentMana = value;
                    OnPropertyChanged(nameof(ParchmentMana));
                }
            }
        }

        public string PotionPv
        {
            get { return _potionPv; }
            set
            {
                if (_potionPv != value)
                {
                    _potionPv = value;
                    OnPropertyChanged(nameof(PotionPv));
                }
            }
        }

        public string PotionMana
        {
            get { return _potionMana; }
            set
            {
                if (_potionMana != value)
                {
                    _potionMana = value;
                    OnPropertyChanged(nameof(PotionMana));
                }
            }
        }
        public string PlayerLife
        {
            get { return _playerLife; }
            set
            {
                if (_playerLife != value)
                {
                    _playerLife = value;
                    OnPropertyChanged(nameof(PlayerLife));
                }
            }
        }

        public string PlayerMana
        {
            get { return _playerMana; }
            set
            {
                if (_playerMana != value)
                {
                    _playerMana = value;
                    OnPropertyChanged(nameof(PlayerMana));
                }
            }
        }
        public string PlayerLevel
        {
            get { return _playerLevel; }
            set
            {
                if (_playerLevel != value)
                {
                    _playerLevel = value;
                    OnPropertyChanged(nameof(PlayerLevel));
                }
            }
        }
        public string PlayerXp
        {
            get { return _playerXp; }
            set
            {
                if (_playerXp != value)
                {
                    _playerXp = value;
                    OnPropertyChanged(nameof(PlayerXp));
                }
            }
        }
        public string PlayerXpNeeded
        {
            get { return _playerXpNeeded; }
            set
            {
                if (_playerXpNeeded != value)
                {
                    _playerXpNeeded = value;
                    OnPropertyChanged(nameof(PlayerXpNeeded));
                }
            }
        }

        public string PlayerWins
        {
            get { return _playerWins; }
            set
            {
                if (_playerWins != value)
                {
                    _playerWins = value;
                    OnPropertyChanged(nameof(PlayerWins));
                }
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InitializeDashboard(Player player)
        {
            Pokedex = player.Pokedex;
            PlayerLife = $"{player.Pv}";
            PlayerMana = $"{player.Mana}";
            PlayerXpNeeded = $"{player.XpRequiredForNextLevel}";
            PlayerXp = $"{player.ExperiencePoints}";
            PlayerLevel = $"{player.Level}";
            PlayerWins = $"{player.Wins}";
            PotionMana = $"{player.Inventory.PotionMana}";
            PotionPv = $"{player.Inventory.PotionPv}";
            ParchmentPv = $"{player.Inventory.ParchmentPv}";
            ParchmentMana = $"{player.Inventory.ParchmentMana}";
        }
    }
}
