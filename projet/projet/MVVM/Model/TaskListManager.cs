using System;
using System.Collections.ObjectModel;

namespace projet.MVVM.Model
{
    public class TaskListManager
    {
        private InventoryManager inventoryManager;

        public ObservableCollection<TaskItem> Tasks { get; }
        public int TotalReward { get; private set; }

        private Random random = new Random();

        public int GetRandomReward()
        {
            return random.Next(1, 3);
        }

        public TaskListManager()
        {
            inventoryManager = InventoryManager.Instance;
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
            if (inventoryManager != null && inventoryManager.Inventory != null)
            {
                switch (rewardAmount)
                {
                    case 1:
                        inventoryManager.Inventory.PotionPv += TotalReward;
                        break;
                    case 2:
                        inventoryManager.Inventory.PotionMana += TotalReward;
                        break;
                    case 3:
                        inventoryManager.Inventory.ParchmentPv += TotalReward;
                        break;
                    case 4:
                        inventoryManager.Inventory.ParchmentMana += TotalReward;
                        break;
                }
                inventoryManager.OnPropertyChanged(nameof(InventoryManager.Inventory));
            }   
        }

    }
}
