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
    Console.WriteLine("* Show task List\t- 1\t\t*\n* Add New Task\t\t- 2\t\t*\n* Edit Task\t\t- 3\t\t*\n* Save and Exit\t\t- 4\t\t*");
    Console.WriteLine("*****************************************");
    Sel= MyTaskIO.ReadSel("Selection", 4);

    List<TaskData> MyTask = new List<TaskData>(); // Creating Task List

    switch (Sel)
    {
        case 1:
            {
                // Display Tasks
                Console.Clear();
                TaskOp.Output();
                break;
            }
        case 2:
            {
                // Code to Display Tasks
                Console.Clear();
                TaskOp.Input(TaskList);
                TaskOp.WriteToFile(TaskList);
                break;
            }
        case 3:
            {
                // Code to Display asset
                Console.Clear();
                Console.WriteLine("Edit Task");

                break;
            }
    }
} while (Sel != 4);
Console.ReadLine();


