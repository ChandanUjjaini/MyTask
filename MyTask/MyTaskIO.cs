using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask
{
    internal class MyTaskIO
    {
        //Method to input and validate menu selection
        public static int ReadSel(string read, int count)
        {
            bool Flag;
            int Data = 0;
            String Input;
            do
            {
                Input = CommonOp.ReadData(read);
                Flag = Validation.DataVal(Input);
                if (Flag == false)
                {
                    CommonOp.ErrorMessage(read);
                    Flag = true;
                }
                else if (Flag == true)
                {
                    Data = int.Parse(Input);
                    Flag = (Data > count);
                    if (Flag == true)
                        CommonOp.ErrorMessage(read); 

                }
            } while (Flag == true);

            return Data;
        }

        //Method to input and validate data input
        public static string ReadData(string read)// method to input data
        {
            bool Flag;
            string Data;
            do
            {
                Data = CommonOp.ReadData(read);
                Flag = Validation.DataVal(Data);
               
                if (Flag == true)

                    CommonOp.ErrorMessage(read);

            } while (Flag == true);
            GC.Collect();
            return Data;
        }

        public static DateOnly ReadDate(string read) // Method to input date
        {
            bool Flag;
            string ReadDate;

            //bool valDate;
            do
            {
                ReadDate = CommonOp.ReadData(read + "in \"mm/dd/yyyy\" format");
                Flag = Validation.DateVal(ReadDate);
                if (Flag == true)
                {
                    CommonOp.ErrorMessage(read);
                }
            } while (Flag == true);
            Flag = DateOnly.TryParse(ReadDate, out DateOnly Data);
            


            return Data;

        }

        internal static string StatusSel(String read)
        {
            string Data = null;
            int Sel;
            Console.Clear();
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Please Select Your Task Status \t*");
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Open\t\t\t- 1\t\t*\n* In Progress\t\t- 2\t\t*\n* On Hold\t\t- 3\t\t*\n* Completed\t\t- 4\t\t*");
            Console.WriteLine("*****************************************");
            
            Sel = MyTaskIO.ReadSel("Selection", 4);

            List<TaskData> MyTask = new List<TaskData>(); // Creating Task List

            if (Sel == 1)
            {
                Data = "Open";
            }

            else if (Sel == 2)
            {
                Data = "In Progress";
            }
            else if (Sel == 3)
            {
                Data = "On Hold";

            }
            else if (Sel == 4)
            {
                Data = "Completed";

            }

            return Data;
        }

    }
}
