using System.ComponentModel;

namespace Inventorys
{
    public class Inventory : INotifyPropertyChanged
    {
        private int parchmentPv;
        public int ParchmentPv
        {
            get { return parchmentPv; }
            set
            {
                if (parchmentPv != value)
                {
                    parchmentPv = value;
                    OnPropertyChanged(nameof(ParchmentPv));
                }
            }
        }

        private int parchmentMana;
        public int ParchmentMana
        {
            get { return parchmentMana; }
            set
            {
                if (parchmentMana != value)
                {
                    parchmentMana = value;
                    OnPropertyChanged(nameof(ParchmentMana));
                }
            }
        }

        private int potionPv;
        public int PotionPv
        {
            get { return potionPv; }
            set
            {
                if (potionPv != value)
                {
                    potionPv = value;
                    OnPropertyChanged(nameof(PotionPv));
                }
            }
        }

        private int potionMana;
        public int PotionMana
        {
            get { return potionMana; }
            set
            {
                if (potionMana != value)
                {
                    potionMana = value;
                    OnPropertyChanged(nameof(PotionMana));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
