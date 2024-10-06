using System.Security.Principal;
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
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Margo Bank AB. \n");

            bool login = true;
            int attempts = 3;

            //for int i is 1 and if i is smaller than attempts, i rises with 1
            //while (login) { }

            for (int i = 1; i <= attempts; i++)
            {
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
                //if the user uses all the attempts - program shuts down
                if (i == attempts)
                {
                    Console.WriteLine("Too many failed attempts. Access denied.");
                    break;
                }//if the user types wrong
                else if (!ValidatePassword(input, inputPassword))
                {
                    Console.WriteLine($"Wrong username or password, try again.\n");
                }
                Console.WriteLine();
            }
        }

        //method to check if the username is correct
        public static bool ValitadeUser(string username)
        {
            for (int i = 0; i < users.Length; i++)
            {
                /*när första index i idexen är noll och andra index är noll
                 då är gäller den första användarnamnet och om den är korrekt 
                är det sant annars är det falskt*/
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
                /*när första index i idexen är noll och andra index är noll
                då är gäller den första användarnamnet och om den är korrekt 
                är det sant annars är det falskt
                gäller desamma med lösenord och användarnamn*/
                if (users[i][0] == username && users[i][1] == password)
                {
                    return true;
                }
            }
            return false;
        }

        //the menu method, if the users manage to sign in
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

