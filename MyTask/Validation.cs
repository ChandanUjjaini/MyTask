using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask
{
    internal class Validation
    {
        public static bool DataVal(string read)//Validation input all string
        {
            bool Flag;

            Flag = int.TryParse(read, out int num);

            if (Flag == false)
            {
                Flag = (String.IsNullOrWhiteSpace(read));
            }
            return Flag;
        }

        internal static bool DateVal(String read)
        {
            DateTime Data;
            bool Flag;

            Flag = (String.IsNullOrWhiteSpace(read));//Checking for null string
            if (Flag == false)
            {
                try
                {
                    Flag = !DateTime.TryParse(read, out Data);
                    
                }
                catch (FormatException DateExp)
                {
                    Flag = true;
                    Console.WriteLine(DateExp.Message);
                }
            }

            //if (Flag == false)
            //{
            //    Flag = DateTime.TryParse(read, out Data);
            //    Flag = Data <= DateTime.Now;
            //}
            return Flag;
        }


    }
}
