using AttackPlayers;
using Inventorys;
using Monsters;

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
        public int Wins { get; private set; }

        public int originalHealth;
        public int originalMana;
        public int ExperiencePoints { get; private set; }

        private bool hasUsedParchmentMana = false;
        private bool hasUsedParchmentPv = false;

        public List<AttackPlayer> Attack { get; } = new List<AttackPlayer>();

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
                }
                return _instance;
            }
        }

        public void UpdatePlayerProperties(int newPv, int newMana,int level, int XP, int XPRequired, int originalhealth, int originalmana, int wins)
        {
            Pv = newPv;
            Mana = newMana;
            Level = level;
            originalHealth = originalhealth;
            originalMana = originalmana;
            XpRequiredForNextLevel = XPRequired;
            Wins = wins;
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
            Console.WriteLine($"{Name} est brûlé!");
        }

        public void ApplyFrozenEffect()
        {
            IsFrozen = true;
            Console.WriteLine($"{Name} est gelé!");
        }

        public void ApplyDepressedEffect()
        {
            IsDepressed = true;
            Console.WriteLine($"{Name} est Dépréssif");
        }

        public void ApplyPossessedByTheDevilEffect()
        {
            IsDepressed = true;
            Console.WriteLine($"{Name} est Posséder par le diable");
        }

        public void ResetStatsPlayer()
        {
            Pv = originalHealth;
            Mana = originalMana;
            Wins++;
        }
        public void PotionPv(Inventory inventory)
        {
            inventory.PotionHeal -= 1;
            Pv += 20;
        }

        public void PotionMana(Inventory inventory)
        {
            inventory.PotionMana -= 1;
            Mana += 20;
        }

        public void ParchmentMana(Inventory inventory)
        {
            inventory.ParchmentMana -= 1;
            hasUsedParchmentMana = true;
        }

        public void ParchmentPv(Inventory inventory)
        {
            inventory.ParchmentPv -= 1;
            hasUsedParchmentPv = true;
        }
    }
}