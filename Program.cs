using System.Security.Principal;
using System;

namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Users with pin
            string[] username = ["User01", "User02", "User03", "User04", "User05"];
            int[] password = [1111, 2222, 3333, 4444, 5555];

            bool trueORfalse = true;
            Console.WriteLine("Welcome to the Bank. ");
            Console.WriteLine("Please enter you username and password: ");
            int attempt = 3;


            for (int typo = 1; typo < attempt; typo++)
            {

            }

            while (trueORfalse)
            {
                Console.WriteLine("Here are your options.\n");
                Console.WriteLine("1: View your accounts and balance");
                Console.WriteLine("2: Transfer between accounts");
                Console.WriteLine("3: Withdraw money");
                Console.WriteLine("4: Sign out");
                int userChoice = Convert.ToInt32(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    default:
                        Console.WriteLine("Invaild choice, try again.");
                        break;
                }

            }

        }

        //private static int Authenticate(string[] username, string[] password)
        //{
        //    Console.WriteLine("UserName: ");
        //    string user = Console.ReadLine();
        //    Console.WriteLine("Password: ");
        //    string userPass = Console.ReadLine();
        //    if (int i = 0; i < username.Length; i++) 
        //    {
        //        if (username[i] == user && password[i] == userPass)
        //        {
        //            return i;
        //        }
        //    }

        //}


    }
}

