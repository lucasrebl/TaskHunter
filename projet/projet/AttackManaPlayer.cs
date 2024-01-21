namespace AttackManaPlayers
{
    class AttackManaPlayer
    {
        public string Name { get; }

        public int Damage { get; }

        public int ManaCost { get; }

        public AttackManaPlayer(string name, int damage, int manaCost)
        {
            Name = name;
            Damage = damage;
            ManaCost = manaCost;
        }
    }
}