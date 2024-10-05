using System.Security.Principal;
using System;

namespace Bankomat
{
    internal class Program
    {
        //Users with password
        static string[][] users = { ["User01", "1111"], ["User02", "2222"], ["User03", "3333"], ["User04", "4444"], ["User05", "5555"] };
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank AB. ");

            string input = Console.ReadLine();
            string inputPass = Console.ReadLine();


            bool login = true;
            int attempts = 3;

            while (login)
            {
                Console.WriteLine("Enter you username:");
                string user = Console.ReadLine();
                Console.WriteLine("Enter you password:");
                string userPass = Console.ReadLine();

                for (int i = 1; i < attempts; i++)
                {
                    for (int j = 0; j < users.Length; j++)
                    {

                        if (users[j][0] == input && users[j][1] == inputPass)
                        {
                            Console.WriteLine(users);

                        }
                    }
                }

            }



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

