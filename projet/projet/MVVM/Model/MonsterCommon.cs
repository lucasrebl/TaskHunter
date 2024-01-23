using AttackMonstersCommon;

namespace MonstersCommon
{
    class MonsterCommon
    {
        public string Name { get; }

        public int Pv { get; private set; }

        public int Mana { get; private set; }

        public List<AttackMonsterCommon> AttackCommon = new List<AttackMonsterCommon>();

        public MonsterCommon(string name, int pv, int mana)
        {
            Name = name;
            Pv = pv;
            Mana = mana;
        }

        public bool IsAliveMonsterCommon()
        {
            return Pv > 0;
        }

        public void DisplayAttacksCommon()
        {
            Console.WriteLine($"Attaques du monstre commun '{Name}':");
            foreach ( var attack in AttackCommon )
            {
                Console.WriteLine($"{attack.Name} - Dommages : {attack.Damage}, Co�t en mana : {attack.ManaCost}");
            }
            Console.WriteLine();
        }

        public static void InitCommon()
        {
            List<MonsterCommon> commonMonsters = new List<MonsterCommon>
            {
                new MonsterCommon("Slime", 20, 15),
                new MonsterCommon("Sprout", 25, 20),
                new MonsterCommon("Spoink", 35, 25),
            };

            foreach (var monster in commonMonsters)
            {
                monster.AttackCommon.AddRange(AttackMonsterCommon.GenerateDefaultAttacksCommon());
            }

            foreach (var monster in commonMonsters)
            {
                monster.DisplayAttacksCommon();
            }
        }
    }
}