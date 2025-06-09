using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMalshinon_09_06_25
{
    internal class CreateSecretCode
    {
       
        /// <summary>
        /// Generates a random eight-digit code.
        /// </summary>
        /// <returns></returns>
        private static int GeneratSecretCode() 
        {
            Random rnd = new Random();
                     
            int newSecretCode = rnd.Next(10000000, 100000000);

            SearchSecretCodeInPeople searchSecretCodeInPeople = new SearchSecretCodeInPeople();

   
            while (searchSecretCodeInPeople.SecretCodeExistsInTabla(newSecretCode))
            {
                newSecretCode = rnd.Next(10000000, 100000000);
            }

            return newSecretCode;
        }

        /// <summary>
        /// Returns a random eight-digit code.
        /// </summary>
        /// <returns></returns>
        public static int GetNewSecretCode()
        {
            int newSecretCode = GeneratSecretCode();
            return newSecretCode;
        }
    }
}




