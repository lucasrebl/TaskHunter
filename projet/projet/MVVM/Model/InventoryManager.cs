using Inventorys;
using System.ComponentModel;

namespace projet.MVVM.Model
{
    public class InventoryManager : INotifyPropertyChanged
    {
        private static InventoryManager instance = new InventoryManager();

        public Inventory Inventory { get; private set; }

        public TaskListManager TaskListManager { get; private set; }

        private InventoryManager()
        {
            InventoryManager.instance = this;
            Inventory = new Inventory();
            TaskListManager = new TaskListManager();
        }

        public static InventoryManager Instance
        {
            get { return instance; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
