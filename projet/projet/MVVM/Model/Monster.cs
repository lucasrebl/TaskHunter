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
        public enum MonsterState
        {
            Normal,
            Burned,
            Frozen,
            Depressed,
            PossessedByTheDevil,
        }
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

                    if (chosenAttack.Name == "Flamèche")
                    {
                        ApplyBurnEffect(player);
                    }

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
                else if (chosenAttack != null && chosenAttack.Name == "Boule de neige")
                {
                    ApplyFrozenEffect(player);
                    player.ApplyDamage(chosenAttack.Damage);
                    Mana -= chosenAttack.ManaCost;
                    Console.WriteLine($"{Name} attaque avec {chosenAttack.Name} et inflige {chosenAttack.Damage} points de dégâts à {player.Name}!");
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
                else if (chosenAttack != null && chosenAttack.Name == "Insulte")
                {
                    ApplyDepressedEffect(player);
                    player.ApplyDamage(chosenAttack.Damage);
                    Mana -= chosenAttack.ManaCost;
                    Console.WriteLine($"{Name} attaque avec {chosenAttack.Name} et inflige {chosenAttack.Damage} points de dégâts à {player.Name}!");
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
                else if (chosenAttack != null && chosenAttack.Name == "Danse endiablée")
                {
                    ApplyPossessedByTheDevilEffect(player);
                    player.ApplyDamage(chosenAttack.Damage);
                    Mana -= chosenAttack.ManaCost;
                    Console.WriteLine($"{Name} attaque avec {chosenAttack.Name} et inflige {chosenAttack.Damage} points de dégâts à {player.Name}!");
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
        public void UpdatePlayerXP(Player player)
        {
            int earnedXP = CalculateEarnedXP();
            player.AddExperiencePoints(earnedXP);
            Console.WriteLine($"{player.Name} a gagner {earnedXP} points d'experience!");
        }
        private int CalculateEarnedXP()
        {
            int minXP = 0;
            int maxXP = 0;

            switch (Category.ToLower())
            {
                case "common":
                    minXP = 50;
                    maxXP = 100;
                    break;
                case "rare":
                    minXP = 100;
                    maxXP = 150;
                    break;
                case "epic":
                    minXP = 150;
                    maxXP = 200;
                    break;
                case "legendary":
                    minXP = 200;
                    maxXP = 250;
                    break;
                case "boss":
                    minXP = 500;
                    maxXP = 1000;
                    break;

                default:
                    minXP = 50;
                    maxXP = 100;
                    break;
            }
            return rand.Next(minXP, maxXP + 1);
        }
        private void ApplyBurnEffect(Player player)
        {
            player.ApplyBurnEffect();
        }

        private void ApplyFrozenEffect(Player player)
        {
            player.ApplyFrozenEffect();
        }

        public void ApplyDepressedEffect(Player player)
        {
            player.ApplyDepressedEffect();
        }
        public void ApplyPossessedByTheDevilEffect(Player player)
        {
            player.ApplyPossessedByTheDevilEffect();
        }
    }
}