using Players;
using AttackMonsters;

namespace Monsters
{
    [Serializable]
    public class Monster
    {
        private Random rand;
        public string? Name { get; }
        public int Health { get; private set; }
        public int Mana { get; private set; }
        public string Category { get; }
        public string Img { get; }

        private readonly int originalHealth;
        private readonly int originalMana;

        public List<AttackMonster> Attacks { get; set; }

        public Monster(string name, int health, int mana, string category, List<AttackMonster> attacks, Random random, string img)
        {
            Name = name;
            Health = health;
            Mana = mana;
            Category = category;
            Attacks = attacks;
            rand = random;

            originalHealth = health;
            originalMana = mana;
            Img = img;
        }

        public void ResetStats()
        {
            Health = originalHealth;
            Mana = originalMana;
        }

        public void ApplyDamage(int damage)
        {
            Health -= damage;
        }

        public bool IsAliveMonster()
        {
            return Health > 0;
        }

        public string GetStatusMonster()
        {
            return $"{Name}: PV = {Health}, Mana = {Mana}, Category = {Category}";
        }

        public AttackMonster ChooseAttack()
        {
            if (Attacks != null && Attacks.Count > 0)
            {
                int randomIndex = rand.Next(Attacks.Count);
                return Attacks[randomIndex];
            }
            else
            {
                return null;
            }
        }

        public void PerformAttackCommon(Player player)
        {
            if (IsAliveMonster() && Attacks != null && Attacks.Count > 0)
            {
                AttackMonster chosenAttack = ChooseAttack();
                if (chosenAttack != null)
                {
                    player.ApplyDamage(chosenAttack.Damage);
                    Mana -= chosenAttack.ManaCost;
                    Console.WriteLine($"{Name} attaque avec {chosenAttack.Name} et inflige {chosenAttack.Damage} points de dégâts à {player.Name}!");
                }
            }
        }

        public void PerformAttackRare(Player player)
        {
            if (IsAliveMonster() && Attacks != null && Attacks.Count > 0)
            {
                AttackMonster chosenAttack = ChooseAttack();
                if (chosenAttack != null && chosenAttack.OtherEffect == "suicide")
                {
                    player.ApplyDamage(chosenAttack.Damage);
                    Health -= Health;
                    Console.WriteLine($"{Name} attaque avec {chosenAttack.Name} et inflige {chosenAttack.Damage} points de dégâts à {player.Name}!");
                    Console.WriteLine($"{Name} c'est suicider en utilisant {chosenAttack.Name}");
                }
                else
                {
                    player.ApplyDamage(chosenAttack.Damage);
                    Mana -= chosenAttack.ManaCost;
                    Console.WriteLine($"{Name} attaque avec {chosenAttack.Name} et inflige {chosenAttack.Damage} points de dégâts à {player.Name}!");
                }
            }
        }

        public void PerformAttackEpic(Player player)
        {
            if (IsAliveMonster() && Attacks != null && Attacks.Count > 0)
            {
                AttackMonster chosenAttack = ChooseAttack();
                if (chosenAttack != null && chosenAttack.OtherEffect == "esquive")
                {
                    Console.WriteLine("test");
                }
                else
                {
                    player.ApplyDamage(chosenAttack.Damage);
                    Mana -= chosenAttack.ManaCost;
                    Console.WriteLine($"{Name} attaque avec {chosenAttack.Name} et inflige {chosenAttack.Damage} points de dégâts à {player.Name}!");
                }
            }
        }

        public void PerformAttackLegendary(Player player)
        {
            if (IsAliveMonster() && Attacks != null && Attacks.Count > 0)
            {
                AttackMonster chosenAttack = ChooseAttack();
                if (chosenAttack != null && chosenAttack.OtherEffect == "vol")
                {
                    Mana += 20;
                    Health -= 40;
                    player.ApplyStealMana();
                    Console.WriteLine($"{Name} attaque avec {chosenAttack.Name} et vole 20 de mana à {player.Name}!");
                }
                else if (chosenAttack != null && chosenAttack.OtherEffect == "heal")
                {
                    Health += 10;
                    Mana -= chosenAttack.ManaCost;
                    Console.WriteLine($"{Name} utilise {chosenAttack.Name} et ce soigne de 10 PV!");
                }
                else
                {
                    player.ApplyDamage(chosenAttack.Damage);
                    Mana -= chosenAttack.ManaCost;
                    Console.WriteLine($"{Name} attaque avec {chosenAttack.Name} et inflige {chosenAttack.Damage} points de dégâts à {player.Name}!");
                }
            }
        }

        public void PerformAttackBoss(Player player)
        {
            if (IsAliveMonster() && Attacks != null && Attacks.Count > 0)
            {
                AttackMonster chosenAttack = ChooseAttack();
                if (chosenAttack != null && chosenAttack.OtherEffect == "bosst")
                {
                    Health += 10;
                    Mana += 10;
                    Console.WriteLine($"{Name} utilise {chosenAttack.Name} et ce soigne de 10 PV et augmente son mana de 10!");
                }
                else
                {
                    player.ApplyDamage(chosenAttack.Damage);
                    Mana -= chosenAttack.ManaCost;
                    Console.WriteLine($"{Name} attaque avec {chosenAttack.Name} et inflige {chosenAttack.Damage} points de dégâts à {player.Name}!");
                }
            }
        }
    }
}