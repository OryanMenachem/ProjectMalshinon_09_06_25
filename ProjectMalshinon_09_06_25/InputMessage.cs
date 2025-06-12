using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMalshinon_09_06_25
{
    internal class InputMessage
    {
  

        public static string GetMessage()
        {
            string message = string.Empty;

            Console.WriteLine("What do your have to report?:");

            while (true)
            { 
                message = Console.ReadLine();

                if (message != string.Empty) {return message; }

                TextColors.ErrorColor("No input was entered.");
            }

        }
    }
}
