namespace AttackMonstersBoss
{
    class AttackMonsterBoss
    {
        public string Name { get; }

        public int Damage { get; private set; }

        public int ManaCost { get; private set; }

        public AttackMonsterBoss(string name, int damage, int manaCost)
        {
            Name = name;
            Damage = damage;
            ManaCost = manaCost;
        }

        public static List<AttackMonsterBoss> GenerateDefaultAttacksBoss()
        {
            return new List<AttackMonsterBoss>
            {
                new AttackMonsterBoss("Draco-Ascension", 120, 70),
                new AttackMonsterBoss("ExpelledΑραβικά", 120, 200),
                new AttackMonsterBoss("Colere", 80, 50),
            };
        }
    }
}