using System;
using System.Collections.ObjectModel;

namespace Task
{
    public class TaskListManager
    {
        private Inventorys.Inventory inventory;
        public ObservableCollection<TaskItem> Tasks { get; }
        public int TotalReward { get; private set; } 

        private Random random = new Random(); 

        public int GetRandomReward()
        {
            
            return random.Next(1, 3);
        }

        public TaskListManager(Inventorys.Inventory inventory)
        {
            this.inventory = inventory;
            Tasks = new ObservableCollection<TaskItem>();
            TotalReward = 0; 
        }

        public void AddTask(string title, DateTime date)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                Tasks.Add(new TaskItem(title, date));
            }
        }

        public void CompleteTask(TaskItem task)
        {
            task.IsCompleted = true;        
            int rewardAmount = GetRandomReward();
            ApplyRewardToInventory(rewardAmount);
            TotalReward += rewardAmount;

        }

        public string GetRewardType(int rewardAmount)
        {
            switch (rewardAmount)
            {
                case 1:
                    return "Potion de Vie";
                case 2:
                    return "Potion de Mana";
                case 3:
                    return "Parchemin de Vie";
                case 4:
                    return "Parchemin de Mana";
                default:
                    return "Récompense non spécifiée";
            }
        }


        private void ApplyRewardToInventory(int rewardAmount)
        {
            switch (rewardAmount)
            {
                case 1:
                    inventory.PotionHeal++;
                    break;
                case 2:
                    inventory.PotionMana++;
                    break;
                case 3:
                    inventory.ParchmentPv++;
                    break;
                case 4:
                    inventory.ParchmentMana++;
                    break;
            }
        }
    }
}
