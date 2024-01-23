namespace AttackMonstersEpic
{
    class AttackMonsterEpic
    {
        public string Name { get; }

        public int Damage { get; private set; }

        public int ManaCost { get; private set; }

        public AttackMonsterEpic(string name, int damage, int manaCost)
        {
            Name = name;
            Damage = damage;
            ManaCost = manaCost;
        }

        public static List<AttackMonsterEpic> GenerateDefaultAttacksEpic()
        {
            return new List<AttackMonsterEpic>
            {
                new AttackMonsterEpic("Tir canon", 65, 65),
                new AttackMonsterEpic("Lame d'aire", 40, 20),
                new AttackMonsterEpic("Insulte", 50, 30),
                new AttackMonsterEpic("RN Attack'", 55, 30),
                new AttackMonsterEpic("Nova Solaire", 75, 50),
            };
        }
    }
}
