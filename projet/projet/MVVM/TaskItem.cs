using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class TaskItem
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(string title, DateTime date)
        {
            Title = title;
            Date = date;
            IsCompleted = false;
        }
    }

}
