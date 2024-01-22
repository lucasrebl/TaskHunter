using System;
using System.Collections.ObjectModel;

namespace Task
{
    public class TaskListManager
    {
        public ObservableCollection<TaskItem> Tasks { get; }

        public TaskListManager()
        {
            Tasks = new ObservableCollection<TaskItem>();
        }

        public void AddTask(string title, DateTime date)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                Tasks.Add(new TaskItem(title, date));
            }
        }

        public void CompleteTask(TaskItem task, int rewardAmount)
        {
            task.IsCompleted = true;
            task.Reward = rewardAmount;
        }
    }
}
