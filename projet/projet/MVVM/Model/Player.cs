using AttackPlayers;
using Monsters;

namespace Players
{
    public class Player
    {
        public string Name { get; }

        public int Pv { get; private set; }

        public int Mana { get; private set; }

        public int Level { get; private set; }

        public int ExperiencePoints { get; private set; }

        public List<AttackPlayer> Attack { get; } = new List<AttackPlayer>();

        public bool IsBurned { get; private set; } = false;
        public bool IsFrozen { get; private set; } = false;
        public bool IsDepressed { get; private set; } = false;
        public bool PossessedByTheDevil { get; private set; } = false;

        private readonly int originalHealth;
        private readonly int originalMana;

        public Player(string name, int pv, int mana, int level)
        {
            Name = name;
            Pv = pv;
            Mana = mana;
            Level = level;
            originalHealth = pv;
            originalMana = mana;
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
            int xpRequiredForNextLevel = ExperiencePointsRequiredForNextLevel();

            if (ExperiencePoints >= xpRequiredForNextLevel)
            {
                Level++;
                Pv += 10;
                Mana += 10;
                ExperiencePoints = 0;
                Console.WriteLine($"{Name} est passer niveau {Level}!");
                Console.WriteLine($"{Name} a besoin de {xpRequiredForNextLevel} pour passer au prochain niveau");
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
        }
    }
}