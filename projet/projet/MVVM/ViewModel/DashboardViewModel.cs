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
        }
    }

    public class PokedexItem
    {
        public string ImagePath { get; set; }
        public string ItemText { get; set; }
        public string Rarity { get; set; }
    }
}
