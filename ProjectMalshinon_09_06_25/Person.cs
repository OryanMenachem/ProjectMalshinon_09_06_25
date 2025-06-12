using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMalshinon_09_06_25
{
    internal class Person
    {

        public int Id { get; set; }
        public string FirstName { get; set; } 
	    public string LastName {  get; set; }
        public int SecretCode { get; set; } 

	    public string Type {  get; set; }
	    public int Num_reports {  get; set; }

	    public int Num_mentions {  get; set; }

        public Person(int id, string firstName, string lastName, int secretCode, string type = "reporter",int num_reports = 0,int num_mentions = 0) 
        { 
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SecretCode = secretCode;
            Type = type;
            Num_reports = num_reports;
            Num_mentions = num_mentions;

        
        }

        public override string ToString()
        {
            return $"id: {Id}\n" +
                $"firstName: {FirstName}\n" +
                $"lastName:  {LastName}\n" +
                $"secretCode: {SecretCode}\n" +
                $"type:  {Type}\n" +
                $"num_reports: {Num_reports}\n" +
                $"num_mentions:  {Num_mentions}\n";

        }








    }
}










