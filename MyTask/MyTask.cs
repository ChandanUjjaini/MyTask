using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask
{
    internal class TaskData
    {
        public TaskData(string title, DateOnly dueDate, string status, string project)
        {
            Title = title;
            DueDate = dueDate;
            Status = status;
            Project = project;
        }

        public string Title { get; set; }
        public DateOnly DueDate { get; set; }
        public string Status { get; set; }
        public string Project { get; set; }
    }
}
