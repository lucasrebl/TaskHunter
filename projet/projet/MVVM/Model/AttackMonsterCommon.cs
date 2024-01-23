namespace AttackMonstersCommon
{
    class AttackMonsterCommon
    {
        public string Name { get; }

        public int Damage { get; private set; }

        public int ManaCost { get; private set; }

        public AttackMonsterCommon(string name, int damage, int manaCost)
        {
            Name = name;
            Damage = damage;
            ManaCost = manaCost;
        }

        public static List<AttackMonsterCommon> GenerateDefaultAttacksCommon()
        {
            return new List<AttackMonsterCommon>
            {
                new AttackMonsterCommon("Crachat", 1, 0),
                new AttackMonsterCommon("Roul�-boul�", 2, 0),
                new AttackMonsterCommon("Coup de pied", 3, 0),
                new AttackMonsterCommon("Flamm�che", 6, 5),
                new AttackMonsterCommon("Attaque �l�mentaire", 7, 5),
                new AttackMonsterCommon("Invocation(plante grimpante)", 15, 10)
            };
        }
    }
}