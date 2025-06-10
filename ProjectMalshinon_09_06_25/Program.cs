using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace ProjectMalshinon_09_06_25
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //InsertRowInTable insertRowInTable = new InsertRowInTable("Nehoray","Menachem", CreateSecretCode.GetNewSecretCode());


            //if (SearchValueInMalshinonDB.GetResult("People","FirstName","Darya"))
            //{
            //    Console.WriteLine("cascas");
            //}
            Console.WriteLine("Enter a Message:");

            string message = Console.ReadLine();

            string[] fullName = SearchingNameInMessage.SearchName(message);

            if (!SearchValueInMalshinonDB.GetResult("People", "FirstName", fullName[0]))
            {
                InsertRowInTable.Insert(fullName[0], fullName[1], CreateSecretCode.GetNewSecretCode(), "target");
            }
           



        }
    }
}
