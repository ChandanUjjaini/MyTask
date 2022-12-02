using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask
{
    internal class CommonOp
    {
        public static string ReadData(String read) // Common code to read data from console
        {
            Console.Write($"Please Enter {read}: ");
            String Data = Console.ReadLine();
            Data = Data.Trim();
            return Data;
        }

        // Common code to print data to console
        public static void PrintData(string Title, DateOnly DueDate, string Status, string Project)
        {
            Console.WriteLine(String.Format("{0,-10}", Title.PadRight(12) + DueDate.ToString().PadRight(20) + Status.PadRight(20)
                    + Project));
        }

        internal static void ErrorMessage(String data) // Common code to display error message
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Please Enter Valid {data}");// Error Message
            Console.ResetColor();
        }

        

    }
}
