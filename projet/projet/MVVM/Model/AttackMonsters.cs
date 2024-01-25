namespace AttackMonsters
{
    public class AttackMonster
    {
        public string? Name { get; }

        public int Damage { get; private set; }

        public int ManaCost { get; private set; }

        public string? OtherEffect { get; }

        public string Category { get; }

        public AttackMonster(string? name, int damage, int manaCost, string? otherEffect, string category)
        {
            Name = name;
            Damage = damage;
            ManaCost = manaCost;
            OtherEffect = otherEffect;
            Category = category;
        }
    }
}