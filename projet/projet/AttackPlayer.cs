namespace AttackPlayers
{
    class AttackPlayer
    {
        public string Name { get; }

        public int Damage { get; }

        public AttackPlayer(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
    }
}