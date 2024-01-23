namespace AttackMonstersRare
{
    class AttackMonsterRare
    {
        public string Name { get; }

        public int Damage { get; private set; }

        public int ManaCost { get; private set; }


        public AttackMonsterRare(string name, int damage, int manaCost)
        {
            Name = name;
            Damage = damage;
            ManaCost = manaCost;
        }

        public static List<AttackMonsterRare> GenerateDefaultAttacksRare()
        {
            return new List<AttackMonsterRare>
            {
                new AttackMonsterRare("Saut", 10, 0),
                new AttackMonsterRare("Boom Boom Bakudan", 20, 20),
                new AttackMonsterRare("Bordel", 40, 0),
                new AttackMonsterRare("Grosse patate", 15, 5),
                new AttackMonsterRare("Boule de neige", 20, 15),
                new AttackMonsterRare("Vibraqua", 10, 5),
            };
        }
    }
}