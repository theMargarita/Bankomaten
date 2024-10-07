using System;

namespace Bankomat
{
    internal class Program
    {
        //Users with password
        static string[][] users =
        {
            new string[] {"User01", "1111" },
            new string[] {"User02", "2222" },
            new string[] {"User03", "3333" },
            new string[] {"User04", "4444" },
            new string[] {"User05", "5555" }
        };

        static decimal[][] accounts =
        {
            new decimal [] {5000.00m, 50000.00m},
            new decimal [] {100000.00m},
            new decimal [] {5000.00m, 50000.00m, 100000.00m},
            new decimal [] {500.00m, 50000.00m, 50000.00m, 10000.00m},
            new decimal [] {1000.00m, 50000.00m, 50000.00m, 5000.00m, 10000.00m}
        };
        static void Main(string[] args)
        {

            bool login = true;
            int attempts = 3;

            while (login)
            {
                //i is tries in attempts
                for (int i = 1; i <= attempts; i++)
                {
                    Console.WriteLine("Welcome to the Margo Bank AB \n");
                    Console.WriteLine("Enter you username: ");
                    string input = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    string inputPassword = Console.ReadLine();

                    //to check if the username is correct 
                    if (ValitadeUser(input))
                    {
                        //to check the username and the password, if correct and in the same index
                        if (ValidatePassword(input, inputPassword))
                        {
                            Console.WriteLine("The login was successful.\n");
                            login = true;
                            TheMenu();
                        }
                    }
                    //if i (tries) is the same as attempts 
                    if (i == attempts)
                    {
                        Console.WriteLine("Too many failed attempts. Access denied.");
                        login = false;
                    }
                    //if the user types wrong
                    else if (!ValidatePassword(input, inputPassword))
                    {
                        Console.WriteLine($"Wrong username or password, try again.\n");
                    }
                    Console.WriteLine();
                }
            }
        }

        //method to check if the username is correct
        public static bool ValitadeUser(string username)
        {
            for (int i = 0; i < users.Length; i++)
            {
                /*i is the index of users to check if only the username is correct*/
                if (users[i][0] == username)
                {
                    return true;
                }
            }
            return false;
        }

        //method to check is the password is correct witht he right user
        public static bool ValidatePassword(string username, string password)
        {
            for (int i = 0; i < users.Length; i++)
            {
                /*i is the index of users and checks if the username and password of the correct 
                 if yes then it is true, else false*/
                if (users[i][0] == username && users[i][1] == password)
                {
                    return true;
                }
            }
            return false;
        }

        //the menu method, if the users manage to sign in - the menu appears
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
                        //while lopp not true, return to login 
                        Console.WriteLine("Signing out...");
                        //wait three seconds before clearing
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        trueORfalse = false;
                        break;

                    default:
                        Console.WriteLine("Invaild choice, try again.");
                        break;
                }
            }
        }
    }
}

