using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMalshinon_09_06_25
{
    internal class SearchNameInMessage 
    {
        public static string[] SearchName(string message)
        {
            string[] fullName = new string[2];

            int cuonter = 0 ;

            bool flag = false;

            while (true)
            {

         
                for (int i = 0; i < message.Length; i++)
                {
                    if ((char.IsLetter(message[i]) && message[i].ToString() == message[i].ToString().ToUpper()) || flag)
                    {
                        flag = true;

                        if (cuonter == 2)
                        {
                            break;
                        }

                        fullName[cuonter] += message[i];

                        if (message[i] == ' ')
                        {
                            cuonter++;
                        }
                    }

                }

                if (FullName.IsNotEmpty(fullName[0]))
                {
                    if (FullName.IsNotEmpty(fullName[1]))
                    {
                        return fullName;
                    }
                } 
                

            }

            

            
        }
  
    }
}
