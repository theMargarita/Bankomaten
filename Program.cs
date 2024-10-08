using System;

namespace Bankomat
{
    internal class Program
    {
        //Users with password
        static string[][] users =
        {
            new string[] {"User00", "0000" },
            new string[] {"User01", "1111" },
            new string[] {"User02", "2222" },
            new string[] {"User03", "3333" },
            new string[] {"User04", "4444" }
        };

        static decimal[][] accountsValue =
        {
            new decimal [] {5000.00m, 50000.00m},
            new decimal [] {100000.00m},
            new decimal [] {5000.00m, 50000.00m, 100000.00m},
            new decimal [] {500.00m, 50000.00m, 50000.00m, 10000.00m},
            new decimal [] {1000.00m, 50000.00m, 50000.00m, 5000.00m, 10000.00m}
        };

        static string[][] accountsName =
        {
            new string[] {"Private account", "Savings"},
            new string[] {"Private account"},
            new string[] {"Private account", "Savings", "Retire Savings"},
            new string[] {"Private account", "Savings", "Retire Savings", "Loans"},
            new string[] {"Private account", "Savings", "Retire Savings", "Loans", "For fun"}
        };


        static void Main(string[] args)
        {
            bool login = true;
            int attempts = 3;

            while (login)
            {
                Console.WriteLine("Welcome to the Margo Bank AB \n");

                //i is tries in attempts
                for (int i = 1; i <= attempts; i++)
                {
                    Console.WriteLine("Enter you username: ");
                    string userInput = Console.ReadLine();

                    //varibalen för metoden som checkar användarnas inlogg
                    int userLogin = ValidateUsername(users, userInput);
                    
                    Console.WriteLine("Enter your password: ");
                    string password = Console.ReadLine();

                    //if the user types wrong
                    if (userLogin == -1)
                    {
                        Console.WriteLine($"Wrong username or password, try again.\n");
                    }
                    //to check if the username is correct 
                    else if (users[userLogin][1] == password)
                    {
                        Console.WriteLine("The login was successful.\n");
                        login = true;
                        TheMenu(userLogin);
                    }
                    //if i (tries) is the same as attempts - shuts the program (something is wrong)
                    if (i == attempts)
                    {
                        Console.WriteLine("Too many failed attempts. Access denied.");
                        login = false;
                    }
                    Console.WriteLine();
                }
            }
        }

        //method to check if the login is correct
        public static int ValidateUsername(string[][] users, string userLogin)
        {
            //int userIndex = -1;
            for (int i = 0; i < users.Length; i++)
            {
                /*i is the index of users to check if only the username is correct*/
                if (users[i][0] == userLogin)
                {
                    return i;
                }
            }
            return -1;
        }


        //method to show the accounts and their value to the correct user (i hope)
        public static void AccountsIndex(int userLogin, string[][] accountsName, decimal[][] accountsValue)
        {
            for (int i = 0; i < accountsName[userLogin].GetLength(0); i++)
            {
                string accname = accountsName[userLogin][i];
                decimal accvalue = accountsValue[userLogin][i];

                Console.WriteLine($"{accname}: {accvalue:C}");
            }
            Console.WriteLine("Press enter to return to menu.");
            Console.ReadKey();
            //wait three seconds before clearing
            System.Threading.Thread.Sleep(100);
            Console.Clear();


        }


        //the menu method, if the users manage to sign in - the menu appears
        public static void TheMenu(int userLogin)
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
                        AccountsIndex(userLogin, accountsName, accountsValue);
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

