namespace Inventorys
{
    public class Inventory
    {
        public int PotionPv { get; set; }
        public int PotionMana { get; set; }
        public int ParchmentMana { get; set; }
        public int ParchmentPv { get; set; }

        public Inventory(int potionPv, int potionMana, int parchmentMana, int parchmentPv)
        {
            PotionPv = potionPv;
            PotionMana = potionMana;
            ParchmentMana = parchmentMana;
            ParchmentPv = parchmentPv;
        }
    }
}
