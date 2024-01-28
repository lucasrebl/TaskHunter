using AttackPlayers;
using Inventorys;
using Monsters;
using projet.MVVM.Model;
using System.ComponentModel;

namespace Players
{
    public class Player : INotifyPropertyChanged
    {
        public string Name { get; }

        public int Pv { get; private set; }

        public int Mana { get; private set; }

        public int Level { get; private set; }

        public List<AttackPlayer> Attack { get; } = new List<AttackPlayer>();

        private Inventory inventory;

        public Inventory Inventory
        {
            get { return inventory; }
            set
            {
                if (inventory != value)
                {
                    if (inventory != null)
                    {
                        inventory.PropertyChanged -= Inventory_PropertyChanged;
                    }

                    inventory = value;

                    if (inventory != null)
                    {
                        inventory.PropertyChanged += Inventory_PropertyChanged;
                    }

                    OnPropertyChanged(nameof(Inventory));
                }
            }
        }

        public Player(string name, int pv, int mana, int level)
        {
            Name = name;
            Pv = pv;
            Mana = mana;
            Level = level;
        }

        public void InitializeInventory()
        {
            this.Inventory = InventoryManager.Instance.Inventory;
        }

        public bool IsAlivePlayer()
        {
            return Pv > 0;
        }

        public void CastAttack(AttackPlayer attackPlayer, Monster target)
        {
            Mana -= attackPlayer.ManaCost;
            target.ApplyDamage(attackPlayer.Damage);
        }

        public string GetStatusPlayer()
        {
            return $"{Name}: PV = {Pv}, Mana = {Mana}, Level = {Level}";
        }

        public void ApplyDamage(int damage)
        {
            Pv -= damage;
        }

        public void ApplyStealMana()
        {
            Mana -= 20;
        }

        private void Inventory_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Inventory));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}