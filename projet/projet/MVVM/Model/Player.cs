using AttackPlayers;
using Inventorys;
using Monsters;
using projet.MVVM.Model;
using projet.MVVM.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Players
{
    [Serializable]
    public class Player
    {
        private static Player _instance;
        public string Name { get; }
        public int Pv { get; private set; }

        public int Mana { get; private set; }

        public int Level { get; private set; }
        public int XpRequiredForNextLevel { get; private set; }
        public bool IsBurned { get; private set; } = false;
        public bool IsFrozen { get; private set; } = false;
        public bool IsDepressed { get; private set; } = false;
        public bool PossessedByTheDevil { get; private set; } = false;
        public int Wins { get; set; }
        public int originalHealth;
        public int originalMana;
        public bool HardcoreMode = false;
        public int ExperiencePoints { get; private set; }

        public bool hasUsedParchmentMana = false;
        public bool hasUsedParchmentPv = false;

        public List<AttackPlayer> Attack { get; } = new List<AttackPlayer>();
        public ObservableCollection<PokedexItem> Pokedex { get; set; }
        private static Inventory inventory;
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

        public Player(string name, int pv, int mana, int level, int xpRequiredForNextLevel)
        {
            Name = name;
            Pv = pv;
            Mana = mana;
            Level = level;
            originalHealth = pv;
            originalMana = mana;
            XpRequiredForNextLevel = xpRequiredForNextLevel;
        }
        public static Player Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Player("joueur", 40, 40, 1, 50);
                    _instance.Attack.Add(new AttackPlayer("Coup de pied", 10, 0));
                    _instance.Attack.Add(new AttackPlayer("Coup de poing", 10, 0));
                    _instance.Attack.Add(new AttackPlayer("FireBall", 25, 10));
                    _instance.Attack.Add(new AttackPlayer("Thunder", 30, 15));
                    _instance.Inventory = new Inventory();
                    _instance.Pokedex = new ObservableCollection<PokedexItem> {
                        //new PokedexItem { ImagePath = "/Images/Monsters/mewtwo.gif", ItemText = "Mewtwo", Rarity = "Epique" },
                    };
                }
                return _instance;
            }
        }

        public void addPlayerMana(int mana)
        {
            Mana += mana;
        }
        public void addPlayerPv(int pv)
        {
            Pv += pv;
        }

        public void UpdatePlayerProperties(int newPv, int newMana, int level, int XP, int XPRequired, int originalhealth, int originalmana, int wins, Inventory inventory, ObservableCollection<PokedexItem> pokedex)
        {
            Pv = newPv;
            Mana = newMana;
            Level = level;
            originalHealth = originalhealth;
            originalMana = originalmana;
            XpRequiredForNextLevel = XPRequired;
            Wins = wins;
            Inventory = inventory;
            Pokedex = pokedex;
        }

        public void UpdateInventory(int rewardAmount, int type)
        {
            switch (type)
            {
                case 1:
                    this.Inventory.PotionPv += rewardAmount;
                    break;
                case 2:
                    this.Inventory.PotionMana += rewardAmount;
                    break;
                case 3:
                    this.Inventory.ParchmentPv += rewardAmount;
                    break;
                case 4:
                    this.Inventory.ParchmentMana += rewardAmount;
                    break;
            }
        }

        public void InitializeInventory()
        {
            this.Inventory = InventoryManager.Instance.Inventory;
        }

        public void AddToPokedex(Monster monster)
        {
            if (!Pokedex.Any(p => p.ItemText == monster.Name))
            {
                PokedexItem addedPokemon = new PokedexItem();
                addedPokemon.Rarity = monster.Category;
                addedPokemon.ImagePath = monster.Img;
                addedPokemon.ItemText = monster.Name;
                Pokedex.Add(addedPokemon);
            }
        }

        public bool IsAlivePlayer()
        {
            return Pv > 0;
        }

        public void CastAttack(AttackPlayer attackPlayer, Monster target)
        {
            if (!hasUsedParchmentMana)
            {
                Mana -= attackPlayer.ManaCost;
            }
            target.ApplyDamage(attackPlayer.Damage);

            hasUsedParchmentMana = false;
        }

        public string GetStatusPlayer()
        {
            return $"{Name}: PV = {Pv}, Mana = {Mana}, Level = {Level}";
        }

        public void ApplyDamage(int damage)
        {
            if (!hasUsedParchmentPv)
            {
                Pv -= damage;
            }

            hasUsedParchmentPv = false;
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


        public void AddExperiencePoints(int xp)
        {
            ExperiencePoints += xp;
            CheckLevelUp();
        }

        private int ExperiencePointsRequiredForNextLevel()
        {
            int baseXP = 100;
            int exponent = 2;

            return baseXP * (int)Math.Pow(Level, exponent);
        }

        public void CheckLevelUp()
        {

            if (ExperiencePoints >= XpRequiredForNextLevel)
            {
                Level++;
                XpRequiredForNextLevel = ExperiencePointsRequiredForNextLevel();
                Pv += 10;
                Mana += 10;
                originalHealth += 10;
                originalMana += 10;
                ExperiencePoints = 0;
                Console.WriteLine($"{Name} est passer niveau {Level}!");
                Console.WriteLine($"{Name} a besoin de {XpRequiredForNextLevel} pour passer au prochain niveau");
                Console.WriteLine($"les Pv et le Mana de {Name} on augmenter de 10");
            }
        }
        public void ApplyBurnEffect()
        {
            IsBurned = true;
            Console.WriteLine($"{Name} est br�l�!");
        }

        public void ApplyFrozenEffect()
        {
            IsFrozen = true;
            Console.WriteLine($"{Name} est gel�!");
        }

        public void ApplyDepressedEffect()
        {
            IsDepressed = true;
            Console.WriteLine($"{Name} est D�pr�ssif");
        }

        public void ApplyPossessedByTheDevilEffect()
        {
            IsDepressed = true;
            Console.WriteLine($"{Name} est Poss�der par le diable");
        }

        public void Reset()
        {
            Pv = 40;
            Mana = 40;
            originalHealth = 40;
            originalMana = 40;
            ExperiencePoints = 0;
            Level = 1;
            Wins = 0;
            Inventory newInv = new Inventory();
            Inventory = newInv;
        }

        public void ResetStatsPlayer()
        {
            Pv = originalHealth;
            Mana = originalMana;
            Wins++;
        }
    }
}