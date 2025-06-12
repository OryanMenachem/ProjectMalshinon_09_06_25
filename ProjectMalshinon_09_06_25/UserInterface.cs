using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace ProjectMalshinon_09_06_25
{
    internal class UserInterface : DAL
    {
        private static bool flag = true;

        
        public static void Run()
        {
            Console.WriteLine("Welcome to the Malshinon software\n");
            Console.WriteLine("Please select one of the following options:\n");

            
            while (flag)
            {
                ShowMenu();
                MainHandleChoice(Console.ReadLine());
            }
        }





      




        private static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;


            Console.WriteLine();
            Console.WriteLine("* ********************************************* *");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*                 Analysis Menu                 *");
            Console.WriteLine("*                                               *");
            Console.WriteLine("* ********************************************* *");
            Console.WriteLine("*                                               *");
            Console.WriteLine("* 1. Enter the name of the reporter.            *");
            Console.WriteLine("* 2. Report a target.                           *");                          
            Console.WriteLine("* 3. Showing all potential agents.              *");
            Console.WriteLine("* 4. Show all dangerous destinations.           *");
            Console.WriteLine("* 5. Show all people who have been reported     *");
            Console.WriteLine("*    more than twenty times.                    *");
            Console.WriteLine("* 6.                                            *");
            Console.WriteLine("* 7. Exit                                       *");
            Console.WriteLine("*                                               *");
            Console.WriteLine("* ********************************************* *");


            Console.ResetColor();

            Console.WriteLine();
        }

          
        private static void MainHandleChoice(string choice)
        {
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    HandleChoice1();
                    break;
                case "2":
                    HandleChoice2();
                    break;            
                case "3":
                    HandleChoice3();
                    break;
                case "4":
                    HandleChoice4();
                    break;
                case "5":
                    HandleChoice5();
                    break;
                case "6":
                    HandleChoice6();
                    break;
                case "7":
                    HandleChoice7();
                    break;


                default:
                TextColors.ErrorColor("Please enter a valid input!");
                MainHandleChoice(Console.ReadLine());
                break;
            
            }
        }

        private static void HandleChoice1()
        {
            string[] fullName = { FullName.FirstName(), FullName.LastName() };
       
            InsertPersonInPeople.Insert(fullName[0], fullName[1], CreateSecretCode.GetNewSecretCode());
        }
         
               
            


        private static void HandleChoice2()
        {
            string[] reporterName = {FullName.FirstName(), FullName.LastName()};

            string message = InputMessage.GetMessage();

            string[] fullName = SearchNameInMessage.SearchName(message);  // 
         


            InsertPersonInPeople.Insert(fullName[0], fullName[1], CreateSecretCode.GetNewSecretCode(), "target"); //
               
          

            Person reporter = FromPeopleSelectBy.GetSelectByFirstName(reporterName[0]); 
       
            Person target = FromPeopleSelectBy.GetSelectByFirstName(fullName[0]);


            InsertRowInTableIntelReports.Insert(reporter.Id, target.Id, message); //

            UpdateNumReports.UpdateReports(reporter.Id); //

            UpdateNumMention.Update(target.Id); //




        }



        private static void HandleChoice3()
        {
            List<Person> listPerson = FromPeopleSelectBy.GetSelectByType("potential_agent");

            if (listPerson != null)
            {
                int i = 1;

                Console.WriteLine($"{listPerson.Count} potential agents found\n");
               
                foreach (Person person in listPerson)
                {
                    Console.WriteLine($"Agent {i}: \n");
                    Console.WriteLine($"First Name: {person.FirstName}");
                    Console.WriteLine($"Last Name: {person.LastName}");
                    Console.WriteLine($"Num of reports: {person.Num_reports}");
                    Console.WriteLine($"The average number of characters in all reporting: {GetNumOfCharacters(person.Id) / person.Num_reports}");
                    Console.WriteLine("--------------------\n");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("No potential agents found.");
            }
        }

        private static int GetNumOfCharacters(int Reporter_id)
        {
            List<IntelReports> listIntelReports = FromIntelReportsSelectBy.GetIntelReportsList(Reporter_id);
            string text = "";

            foreach (IntelReports report in listIntelReports)
            {
                text += report.Text;
            }
            return text.Length;

        }

        private static void HandleChoice4()
        {

        }
        private static void HandleChoice5()
        {
            List <Person> personList = SelectByNumMentions.GetPersonList();

            Console.WriteLine($"{personList.Count} dangerous targets found\n");

        

            foreach (Person person in personList)
            {
                Console.WriteLine("\n--------------------\n");
                Console.WriteLine(person);
                Console.WriteLine("\n--------------------\n");
             
            }

            

            
        }
        private static void HandleChoice6()
        {

        }
        private static void HandleChoice7()
        {
            Console.Clear();

            TextColors.SuccessfullColor("\nGood bye");

            flag = false;
        }
    
    }
}
