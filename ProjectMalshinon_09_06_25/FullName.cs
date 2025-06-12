using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectMalshinon_09_06_25
{
    internal class FullName
    {

        public static string FirstName()
        {
            string firstName = string.Empty;


            while (true)
            {
                Console.Write("Enter your first name: ");
                
                firstName = Console.ReadLine();

                if (IsNotEmpty(firstName) && Onlyletters(firstName) && FirsrLeetrIsUpper(firstName)) { break; }

            }
            return firstName;
                
        }

        public static string LastName()
        {
            string lastName = string.Empty;

            while (true)
            {
                Console.Write("Enter your last name: ");

                lastName = Console.ReadLine();

                if (IsNotEmpty(lastName) && Onlyletters(lastName) && FirsrLeetrIsUpper(lastName)) { break; }

            }
            return lastName;

        }

      
   
        
        public static bool IsNotEmpty(string name)
        {
            if (name == string.Empty)
            {
                TextColors.ErrorColor("The report must contain the full name of the target!");
                return false;
            }
            return true;
             
             

        }

        public static bool Onlyletters(string name)
        {
            foreach (char s in name)
            {
                if (!char.IsLetter(s))
                {
                    TextColors.ErrorColor("The name must contain only letters, no numbers, spaces, etc!");
                    return false;
                }
            }
            return true;
        }

        public static bool FirsrLeetrIsUpper(string name)
        {
            if (name[0] == char.ToUpper(name[0])) { return true; }
            TextColors.ErrorColor("First letter must be uppercase!");
            return false;

        }

      
    }
}
