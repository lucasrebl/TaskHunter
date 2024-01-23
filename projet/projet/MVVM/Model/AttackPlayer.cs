namespace AttackPlayers
{
    class AttackPlayer
    {
        public string Name { get; }

        public int Damage { get; private set; }

        public int ManaCost { get; private set; }


        public AttackPlayer(string name, int damage, int manaCost)
        {
            Name = name;
            Damage = damage;
            ManaCost = manaCost;
        }

        public static List<AttackPlayer> GenerateDefaultAttacksPlayer()
        {
            return new List<AttackPlayer>
            {
                new AttackPlayer("Coup de pied", 10, 0),
                new AttackPlayer("Coup de poign", 10, 0),
                new AttackPlayer("FireBall", 25, 10),
                new AttackPlayer("Thunder", 30, 15),
            };
        }
    }
}