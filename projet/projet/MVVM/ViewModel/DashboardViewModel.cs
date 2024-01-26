using System.Collections.ObjectModel;
using System.ComponentModel;

namespace projet.MVVM.ViewModel
{
    class DashboardViewModel
    {
        public ObservableCollection<YourItemModel> YourItemList { get; set; }

        public DashboardViewModel()
        {
            YourItemList = new ObservableCollection<YourItemModel>
            {
                new YourItemModel { ImagePath = "/Images/Monsters/mewtwo.gif", ItemText = "Mewtwo", Rarity = "Epique" },
                new YourItemModel { ImagePath = "/Images/Monsters/pieds.gif", ItemText = "les pieds", Rarity = "Légendaire" },
                new YourItemModel { ImagePath = "/Images/Monsters/goldenhand.png", ItemText = "GoldenHand", Rarity = "Epique" },
                new YourItemModel { ImagePath = "/Images/Monsters/isabelle.gif", ItemText = "Marie", Rarity = "Legendaire" },
                new YourItemModel { ImagePath = "/Images/Monsters/crocmou.gif", ItemText = "YEAAAHAHAHHA", Rarity = "Legendaire" }
            };
        }
    }

    public class YourItemModel
    {
        public string ImagePath { get; set; }
        public string ItemText { get; set; }
        public string Rarity { get; set; }
    }
}
