namespace Inventorys
{
    [Serializable]
    public class Inventory
    {
        public int PotionHeal { get; set; }
        public int PotionMana { get; set; }
        public int ParchmentMana { get; set; }
        public int ParchmentPv { get; set; }

        public Inventory(int potionHeal, int potionMana, int parchmentMana, int parchmentPv)
        {
            PotionHeal = potionHeal;
            PotionMana = potionMana;
            ParchmentMana = parchmentMana;
            ParchmentPv = parchmentPv;
        }
    }
}
