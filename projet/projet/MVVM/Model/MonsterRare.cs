using AttackMonstersRare;

namespace MonstersRare
{
    class MonsterRare
    {
        public string Name { get; }

        public int Pv { get; private set; }

        public int Mana { get; private set; }

        public List<AttackMonsterRare> AttackRare = new List<AttackMonsterRare>();

        public MonsterRare(string name, int pv, int mana)
        {
            Name = name;
            Pv = pv;
            Mana = mana;
        }

        public bool IsAliveMonsterRare()
        {
            return Pv > 0;
        }

        public void DisplayAttacksRare()
        {
            Console.WriteLine($"Attaques su monstres rare '{Name}' :");
            foreach (var attack in AttackRare)
            {
                Console.WriteLine($"{attack.Name} - Dommages : {attack.Damage}, Co�t en mana : {attack.ManaCost}");
            }
            Console.WriteLine();
        }

        public static List<MonsterRare> InitRare()
        {
            List<MonsterRare> rareMonsters = new List<MonsterRare>
            {
                new MonsterRare("French Pampa", 45, 60),
                new MonsterRare("Hatsune Miku", 40, 25),
                new MonsterRare("Sakam�che", 50, 50),
            };

            foreach (var monster in rareMonsters)
            {
                monster.AttackRare.AddRange(AttackMonsterRare.GenerateDefaultAttacksRare());
            }

            foreach (var monster in rareMonsters)
            {
                monster.DisplayAttacksRare();
            }

            return rareMonsters;
        }
    }
}