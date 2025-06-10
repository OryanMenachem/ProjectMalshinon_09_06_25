using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMalshinon_09_06_25
{
    internal class SearchingNameInMessage
    {
        public static string[] SearchName(string message)
        {
            string[] fullName = new string[2];
      
            string firstName = "";
            string lastName = "";

            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == ' ')
                {
                 
                    if (message[i + 1].ToString() == message[i + 1].ToString().ToUpper())
                    {
                        for (int j = i + 1; j < message.Length; j++)
                        {
                            if (message[j] == ' ')
                            {
                                for (int u = j + 1; u < message.Length; u++)
                                {
                                    if (message[u] == ' ')
                                    {
                                        fullName[0] = firstName;
                                        fullName[1] = lastName;
                                        return fullName;
                                    }
                                    lastName += message[u];

                                }
                                break;
                            }
                            firstName += message[j];
                        }
                    }
                }
                
            }

            return fullName;

        }
    }
}
