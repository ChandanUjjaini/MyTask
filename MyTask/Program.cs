//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5


using MyTask;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;




int Sel;

List<TaskData> TaskList = new List<TaskData>();
do
{
    
    Console.WriteLine("*****************************************");
    Console.WriteLine("* Welcome to My Task App \t\t*");
    Console.WriteLine("*****************************************");
    Console.WriteLine("* Show Task List\t- 1\t\t*\n* " +
                      "Add New Task\t\t- 2\t\t*\n* " +
                      "Edit Task\t\t- 3\t\t*\n* " +
                      "Add Sample Data\t- 4\t\t*\n* " +
                      "Exit\t\t\t- 5\t\t*");
    Console.WriteLine("*****************************************");
    Console.WriteLine("Note:\n>> Add Sample Data-\n Use when file is empty or not created " +
        "\n When running program for first time \n This feature will erase all previous data in file and load sample data\n");
    Console.WriteLine("File will be saved in \"projectfolder\"\\bin\\Debug\\net6.0");
    Sel= MyTaskIO.ReadSel("Task", 5);

    List<TaskData> MyTask = new List<TaskData>(); // Creating Task List

    switch (Sel)
    {
        case 1:
            {
                // Display Tasks
                Console.Clear();
                TaskOp.Display();
                break;
            }
        case 2:
            {
                // Code to Display Tasks
                Console.Clear();
                TaskOp.Input(TaskList);
               
                break;
            }
        case 3:
            {
                // Code to Display asset
                Console.Clear();
                TaskOp.EditTask(TaskList);

                break;
            }
        case 4:
            {
                // Code to Display asset
                Console.Clear();
                TaskOp.SeedData();
                TaskOp.Display();

                break;
            }
    }
} while (Sel != 5);



