namespace AttackMonstersLegendary
{
    class AttackMonsterLegendary
    {
        public string Name { get; }

        public int Damage { get; private set; }

        public int ManaCost { get; private set; }

        public int StealMana {  get; private set; }

        public int StealPv { get; private set; }

        public int PvCost { get; private set; }

        public AttackMonsterLegendary(string name, int damage, int manaCost, int stealMana, int stealPv, int pvCost)
        {
            Name = name;
            Damage = damage;
            ManaCost = manaCost;
            StealMana = stealMana;
            StealPv = stealPv;
            PvCost = pvCost;
        }

        public static List<AttackMonsterLegendary> GenerateDefaultAttacksLegendary()
        {
            return new List<AttackMonsterLegendary>
            {
                new AttackMonsterLegendary("Frappe Sismique", 90, 65, 0, 0, 0),
                new AttackMonsterLegendary("Double Baffe", 70, 60, 0, 0, 0),
                new AttackMonsterLegendary("CurryAttack'", 35, 20, 0, 0, 0),
                new AttackMonsterLegendary("Recinqu�te", 0, 20, 0, 10, 0),
                new AttackMonsterLegendary("Danse Endiabl�e", 55, 40, 0, 0, 0),
                new AttackMonsterLegendary("Vol de Mana", 0, 0, 20, 0, 40),
            };
        }
    }
}