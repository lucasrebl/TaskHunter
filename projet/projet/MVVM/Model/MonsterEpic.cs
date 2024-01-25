using AttackMonstersEpic;

namespace MonstersEpic
{
    class MonsterEpic
    {
        public string Name { get; }

        public int Pv { get; private set; }

        public int Mana { get; private set; }

        public List<AttackMonsterEpic> AttackEpic = new List<AttackMonsterEpic>();

        public MonsterEpic(string name, int pv, int mana)
        {
            Name = name;
            Pv = pv;
            Mana = mana;
        }

        public bool IsAliveMonsterEpic()
        {
            return Pv > 0;
        }

        public void DisplayAttacksEpic()
        {
            Console.WriteLine($"Attaques du monstre �pic '{Name}':");
            foreach (var attack in AttackEpic)
            {
                Console.WriteLine($"{attack.Name} - Dommages : {attack.Damage}, Co�t en mana : {attack.ManaCost}");
            }
            Console.WriteLine();
        }

        public static List<MonsterEpic> InitEpic()
        {
            List<MonsterEpic> EpicMonsters = new List<MonsterEpic>
            {
                new MonsterEpic("Golden Hand", 80, 40),
                new MonsterEpic("Paimon", 60, 50),
                new MonsterEpic("Bukayo Saka (jeune prodige)", 80, 100),
            };

            foreach (var monster in EpicMonsters)
            {
                monster.AttackEpic.AddRange(AttackMonsterEpic.GenerateDefaultAttacksEpic());
            }

            foreach (var monster in EpicMonsters)
            {
                monster.DisplayAttacksEpic();
            }

            return EpicMonsters;
        }
    }
}