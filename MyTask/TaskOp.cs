using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTask;

namespace MyTask
{
    internal class TaskOp
    {
        internal static void Input(List<TaskData> tasks)
        {
            string title;
            string duedate;
            string status;
            string project;
            DateOnly Ddate;


            title = MyTaskIO.ReadData("Title").Trim();
            title = Char.ToUpper(title[0]) + title.Substring(1);//Converting first character to uppercase
            Ddate = MyTaskIO.ReadDate("Date");
            //Ddate = DateOnly.Parse(duedate);
            status = MyTaskIO.StatusSel("Status");
            project = MyTaskIO.ReadData("Project Name").Trim();
            project = Char.ToUpper(project[0]) + project.Substring(1);//Converting first character to uppercase
            tasks.Add(new TaskData(title, Ddate, status, project));
            WriteToFile(tasks);

        }

        internal static void Output()
        {
            Console.Clear();
            //Menu outline
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,-10}", "Title".PadRight(12) + "Due Date".PadRight(20) + "Status".PadRight(20)
                  + "Project Name"));
            Console.WriteLine("-----------------------------------------------------------------");


            //Creating list to add list data converted to string to write in file.
            List<string> data = new List<string>();
            List<TaskData> tasks = new List<TaskData>();
            String filepath = "Database.txt";
            data = File.ReadAllLines(filepath).ToList();

            foreach (string datas in data)
            {
                string[] strings = datas.Split(',');
                bool flag = DateOnly.TryParse(strings[1], out DateOnly string1);
                TaskData Listdata = new TaskData(strings[0], string1, strings[2], strings[3]);
                tasks.Add(Listdata);
            }

            foreach (TaskData p in tasks)
            {
                CommonOp.PrintData(p.Title, p.DueDate, p.Status, p.Project);

            }

            //foreach (TaskData task in tasks)
            //{
            //    CommonOp.PrintData(task.Title, task.DueDate, task.Status, task.Project);
            //    string tasksToString = task.Title + "," + task.DueDate + "," + task.Status + "," + task.Project;
            //    data.Add(tasksToString); // Adding data to a list of string.
            //}
            //File.WriteAllLines(filepath, data);
            Console.WriteLine("-----------------------------------------------------------------");
        }

        internal static void WriteToFile(List<TaskData> tasks)
        {
            List<TaskData> SortTask = tasks.OrderBy(tasks => tasks.DueDate).ToList();
            
            //Creating list to add list data converted to string to write in file.
            List<string> data = new List<string>();
            String filepath = "Database.txt";
            foreach (TaskData task in SortTask)
            {
                string tasksToString = task.Title + "," + task.DueDate + "," + task.Status + "," + task.Project;
                data.Add(tasksToString); // Adding data to a list of string.
            }
            File.WriteAllLines(filepath, data);
        }
    }
}
