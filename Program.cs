using System.Security.Principal;
using System;

namespace Bankomat
{
    internal class Program
    {
        //Users with password
        static string[][] users =
            {
            new string[]{ "User01", "1111" },
            new string[]{"User02", "2222" },
            new string[]{"User03", "3333" },
            new string[]{ "User04", "4444" },
            new string[]{"User05", "5555" }
            };
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank AB. ");


            bool login = true;
            int attempts = 3;

            while (login)
            {


                for (int i = 1; i < attempts; i++)
                {
                    Console.WriteLine("Enter you username:");
                    string input = Console.ReadLine();
                    Console.WriteLine("Enter you password:");
                    string inputPass = Console.ReadLine();

                }
                if (!login)
                {
                    Console.WriteLine("You have failed to login in.");
                    return;
                }
                TheMenu();
            }



        }

        public static bool ValidateUser(string username)
        {
            for (int i = 0; i < users.Length; i++)
            {
                //input = Console.ReadLine();
                //string inputPassword = Console.ReadLine();
                if (users[i][0] == username)
                {
                    return true;

                }
            }
            return false;
        }
        public static void TheMenu()
        {
            bool trueORfalse = true;

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
    }
}

