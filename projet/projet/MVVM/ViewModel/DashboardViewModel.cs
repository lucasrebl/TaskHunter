using Players;
using System.Collections.ObjectModel;
using System.ComponentModel;
using projet.MVVM.Model;

namespace projet.MVVM.ViewModel
{
    class DashboardViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PokedexItem> Pokedex { get; set; }

        private Player _actualPlayer;
        private string _playerLife;
        private string _playerMana;
        private string _playerLevel;
        private string _playerXpNeeded;
        private string _playerXp;

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
            Pokedex = new ObservableCollection<PokedexItem>
            {
                new PokedexItem { ImagePath = "/Images/Monsters/mewtwo.gif", ItemText = "Mewtwo", Rarity = "Epique" },
                new PokedexItem { ImagePath = "/Images/Monsters/pieds.gif", ItemText = "les pieds", Rarity = "Légendaire" },
                new PokedexItem { ImagePath = "/Images/Monsters/goldenhand.png", ItemText = "GoldenHand", Rarity = "Epique" },
                new PokedexItem { ImagePath = "/Images/Monsters/isabelle.gif", ItemText = "Marie", Rarity = "Legendaire" },
                new PokedexItem { ImagePath = "/Images/Monsters/crocmou.gif", ItemText = "YEAAAHAHAHHA", Rarity = "Legendaire" }
            };
            PlayerLife = $"{player.Pv}";
            PlayerMana = $"{player.Mana}";
            PlayerXpNeeded = $"{player.XpRequiredForNextLevel}";
            PlayerXp = $"{player.ExperiencePoints}";
            PlayerLevel = $"{player.Level}";
        }
    }

    public class PokedexItem
    {
        public string ImagePath { get; set; }
        public string ItemText { get; set; }
        public string Rarity { get; set; }
    }
}
