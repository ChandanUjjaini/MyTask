using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
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

            List<string> data = new List<string>();
            String filepath = "Database.txt";
            data = File.ReadAllLines(filepath).ToList();
            int i = 0;
            //Reading and adding the taks list to a list from a file,
            //This will retain the previous data getting deleted from file by overwriting.
            foreach (string datas in data)
            {

                string[] strings = datas.Split(',');
                bool flag = DateOnly.TryParse(strings[1], out DateOnly string1);
                TaskData Listdata = new TaskData(strings[0], string1, strings[2], strings[3]);
                tasks.Add(Listdata);
            }


            title = MyTaskIO.ReadData("Title").Trim();
            title = Char.ToUpper(title[0]) + title.Substring(1);//Converting first character to uppercase
            Ddate = MyTaskIO.ReadDate("Date");
            //Ddate = DateOnly.Parse(duedate);
            status = MyTaskIO.StatusSel("Status");
            project = MyTaskIO.ReadData("Project Name").Trim();
            project = Char.ToUpper(project[0]) + project.Substring(1);//Converting first character to uppercase
            tasks.Add(new TaskData(title, Ddate, status, project));
            WriteToFile(tasks);
            Console.Clear();

        }

        internal static void Display()
        {
            Console.Clear();
            //Menu outline
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,-10}", "ID".PadRight(3) + "Title".PadRight(20) + "Due Date".PadRight(20) + "Status".PadRight(20)
                  + "Project Name |"));
            Console.WriteLine("-----------------------------------------------------------------------------");


            //Creating list to add list data converted to string to write in file.
            List<string> data = new List<string>();
            List<TaskData> tasks = new List<TaskData>();
            String filepath = "Database.txt";
            data = File.ReadAllLines(filepath).ToList();// reading all data from file and converting it to list
            int i = 0;
            foreach (string datas in data)// converting the data in string array components to objects
            {

                string[] strings = datas.Split(',');
                bool flag = DateOnly.TryParse(strings[1], out DateOnly string1);
                TaskData Listdata = new TaskData(strings[0], string1, strings[2], strings[3]);
                tasks.Add(Listdata);
            }

            foreach (TaskData p in tasks)
            {
                i++;
                string id = $"{i}.";

                if (p.Status == "Hold" || p.DueDate.Year < DateAndTime.Now.Year)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    CommonOp.PrintData(id, p.Title, p.DueDate, p.Status, p.Project);
                    Console.ResetColor();
                }

                else if (p.Status == "In Progress")
                {
                    CommonOp.PrintData(id, p.Title, p.DueDate, p.Status, p.Project);
                }

                else if (p.Status == "Completed")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    CommonOp.PrintData(id, p.Title, p.DueDate, p.Status, p.Project);
                    Console.ResetColor();
                }

                else if (p.Status == "Open")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    CommonOp.PrintData(id, p.Title, p.DueDate, p.Status, p.Project);
                    Console.ResetColor();
                }


            }

            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;// Color legend information.
            Console.Write("Open >");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Hold or Crossed Deadline >");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Completed");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------------------------");
        }

        internal static void WriteToFile(List<TaskData> tasks)
        {
            String filepath = "Database.txt";
            //Sorting list by Date
            List<TaskData> SortTask = tasks.OrderBy(tasks => tasks.DueDate).ToList();

            //Creating list to add list data converted to string to write in file.
            List<string> data = new List<string>();

            foreach (TaskData task in SortTask)
            {
                string tasksToString = task.Title + "," + task.DueDate + "," + task.Status + "," + task.Project;
                data.Add(tasksToString); // Adding data to a list of string.
            }


            File.WriteAllLines(filepath, data);

        }

        internal static void EditTask(List<TaskData> tasks)
        {
            List<string> data = new List<string>();
            List<TaskData> task = new List<TaskData>();
            String filepath = "Database.txt";
            data = File.ReadAllLines(filepath).ToList();// reading all data from file and converting it to list

            foreach (string datas in data) // converting the data in string array components to objects
            {
                string[] strings = datas.Split(',');
                bool flag = DateOnly.TryParse(strings[1], out DateOnly string1);
                TaskData Listdata = new TaskData(strings[0], string1, strings[2], strings[3]);
                task.Add(Listdata);
            }

            Display(); // Displying contents of document
            int id = MyTaskIO.ReadSel("ID", task.Count); //gettinig Id from used to edit task
            id--;

            int Sel;
            Console.WriteLine("________________________________________");
            Console.WriteLine("| Please Select Your Task Status \t|");
            Console.WriteLine("________________________________________");
            Console.WriteLine("| Delete Task\t\t\t- 1\t|\n| Chandge status\t\t- 2\t|");
            Console.WriteLine("________________________________________");

            Sel = MyTaskIO.ReadSel("Selection", 2); // Getting type of edit from user.

            if (Sel == 1)
            {
                if (task[id].Status == "Completed")
                {
                    //Deleting task from list
                    task.RemoveAt(id);
                    TaskOp.WriteToFile(task);
                    Console.Clear();
                }
                else

                {
                    //Error Message
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCannot Delete task, Only Completed task can be deleted\n");
                    Console.ResetColor();

                }
            }

            else if (Sel == 2)
            {
                //Updating status in list
                string status = MyTaskIO.StatusSel("Status");
                task[id].Status = status;
                TaskOp.WriteToFile(task);
                Console.Clear();
            }
        }

        internal static void SeedData() // Option to add sample data if the document is empty.
        {
            List<TaskData> seedData = new List<TaskData>();

            //Creating list to add list data converted to string to write in file.

            bool flag = DateOnly.TryParse("05/20/2021", out DateOnly Tdate);
            seedData.Add(new TaskData("BugFix", Tdate, "Completed", "ShareBOT"));
            flag = DateOnly.TryParse("09/21/2022", out Tdate);
            seedData.Add(new TaskData("Server restart", Tdate, "In Progress", "ShareBOT"));
            flag = DateOnly.TryParse("11/15/2022", out Tdate);
            seedData.Add(new TaskData("Heap Clear", Tdate, "Hold", "ShareBOT"));
            flag = DateOnly.TryParse("12/25/2022", out Tdate);
            seedData.Add(new TaskData("Server Update", Tdate, "open", "ShareBOT"));

            WriteToFile(seedData);

        }



    }
}
