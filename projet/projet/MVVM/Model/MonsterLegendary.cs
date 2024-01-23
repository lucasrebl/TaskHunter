using AttackMonstersLegendary;

namespace MonstersLegendary
{
    class MonsterLegendary
    {
        public string Name { get; }

        public int Pv { get; private set; }

        public int Mana { get; private set; }

        public List<AttackMonsterLegendary> AttackLegendary { get; } = new List<AttackMonsterLegendary>();

        public MonsterLegendary(string name, int pv, int mana)
        {
            Name = name;
            Pv = pv;
            Mana = mana;
        }

        public bool IsAliveMonsterLegendary()
        {
            return Pv > 0;
        }

        public void DisplayAttacksLegendary()
        {
            Console.WriteLine($"Attaques du monstre l�gendaire '{Name}':");
            foreach (var attack in AttackLegendary)
            {
                Console.WriteLine($"{attack.Name} - Dommages : {attack.Damage}, Co�t en mana : {attack.ManaCost}, Mana voler : {attack.StealMana}, Pv voler : {attack.StealPv}, Co�t en Pv : {attack.PvCost}");
            }
            Console.WriteLine();
        }

        public static void InitLengendary()
        {
            // cr�er une listes de monstres l�gendaires
            List<MonsterLegendary> legendaryMonsters = new List<MonsterLegendary>
            {
                new MonsterLegendary("Marie", 100, 200),
                new MonsterLegendary("Krokmou", 110, 70),
                new MonsterLegendary("Mewtwo", 150, 150),
                new MonsterLegendary("Pieds", 120, 100),
            };
            //init les attaques pour les monstres l�gendaire
            foreach (var monster in legendaryMonsters)
            {
                monster.AttackLegendary.AddRange(AttackMonsterLegendary.GenerateDefaultAttacksLegendary());
            }
            // Affichage des attaques de chaque monstre l�gendaire
            foreach (var monster in legendaryMonsters)
            {
                monster.DisplayAttacksLegendary();
            }
        }
    }
}