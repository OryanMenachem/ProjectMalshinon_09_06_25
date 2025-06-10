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
            Console.WriteLine("Hello what your name? ");

            string[] name = Console.ReadLine().Split(' ');

            if (!SearchValueInMalshinonDB.GetResult("People", "FirstName", name[0]))
            {
                InsertRowInTablePeople.Insert(name[0],name[1],CreateSecretCode.GetNewSecretCode());
            }


                //Console.WriteLine("Enter a Message:");

                string message = ('a' * 100000) + "PLM WQ";

                string[] fullName = SearchingNameInMessage.SearchName(message);
            





            InsertRowInTablePeople.Insert(fullName[0], fullName[1], CreateSecretCode.GetNewSecretCode(), "target");


            Person reporterId = SelectFromTable.GetPerson("Doron");
            Console.WriteLine(reporterId.FirstName);


            Person targetId = SelectFromTable.GetPerson(fullName[0]);



            InsertRowInTableIntelReports.Insert(reporterId.Id, targetId.Id, message);

            UpdateNumberOfReports.UpdateReports(reporterId.Id);

            ReporterPromotion reporterPromotion = new ReporterPromotion(reporterId.FirstName, reporterId.Id);

            reporterPromotion.Reporter_promotion_to_potential_agent();





        }
    }
}
