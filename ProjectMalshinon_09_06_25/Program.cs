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




            Console.WriteLine("Enter a Message:");

            string message = Console.ReadLine();

            string[] fullName = SearchingNameInMessage.SearchName(message);





            InsertRowInTablePeople.Insert(fullName[0], fullName[1], CreateSecretCode.GetNewSecretCode(), "target");


            Person reporterId = SelectFromTable.GetPerson("Darya");
            Console.WriteLine(reporterId.FirstName);


            Person targetId = SelectFromTable.GetPerson(fullName[0]);



            InsertRowInTableIntelReports.Insert(reporterId.Id, targetId.Id, message);





        }
    }
}
