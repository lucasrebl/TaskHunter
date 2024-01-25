namespace AttackPlayers
{
    public class AttackPlayer
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
    }
}