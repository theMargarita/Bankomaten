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

                    Console.WriteLine("Enter your password: ");
                    string password = Console.ReadLine();

                    //varibalen för metoden som checkar användarnas inlogg
                    int userLogin = ValidateUsername(users, userInput);


                    //if - the user types the wrong username or password
                    if (userLogin == -1 || users[userLogin][1] != password)
                    {
                        Console.WriteLine($"Wrong username or password, try again.\n");
                        //if - i (tries) is the same as attempts - shutsdown the program 
                        if (i == attempts)
                        {
                            Console.WriteLine("Too many failed attempts. Access denied.");
                            login = false;
                        }
                        //whitespace counts as wrong input
                        else if (string.IsNullOrWhiteSpace(userInput) || string.IsNullOrWhiteSpace(password))
                        {
                        }
                    }
                    //to check if the username is correct 
                    else if (users[userLogin][1] == password)
                    {
                        Console.WriteLine("The login was successful.\n");
                        login = true;
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        TheMenu(userLogin);
                    }

                }
            }

        }

        //login checker method
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

        //accounts & values method for the correct user
        public static void AccountsIndex(int userLogin, string[][] accountsName, decimal[][] accountsValue)
        {
            for (int i = 0; i < accountsName[userLogin].Length; i++)
            {
                string accname = accountsName[userLogin][i];
                decimal accvalue = accountsValue[userLogin][i];
                Console.WriteLine($"{accname}: {accvalue:C}");
            }
            Console.WriteLine("\nPress enter to return to menu.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void TransferMoney(int userLogin)
        {
            //loop to show the users accounts
            for (int i = 0; i < accountsName[userLogin].Length; i++)
            {
                string accname = accountsName[userLogin][i];
                decimal accvalue = accountsValue[userLogin][i];
                Console.WriteLine($"{i + 1}: {accname}: {accvalue:C}");
            }

            Console.WriteLine("\nEnter the number of the account you want to transfer from");
            //-1 is for subtracting from the chosen index to the actual index
            int fromIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.WriteLine("\nEnter the number of account you want to transfer to");
            int toIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine();

            Console.WriteLine("\nHow much do you want to transfer");
            decimal theAmountInput = Convert.ToDecimal(Console.ReadLine());

            if (fromIndex == toIndex)
            {
                Console.WriteLine("\nYou can not transfer between one account");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                return;
            }
            //statement for trensfering between accounts
            else if (accountsValue[userLogin][fromIndex] >= theAmountInput)
            {
                //first part subtracts from the chosen account 
                accountsValue[userLogin][fromIndex] -= theAmountInput;
                //second part adds to the chosen account
                accountsValue[userLogin][toIndex] += theAmountInput;
                Console.WriteLine("The transfer is now complete\n");
            }
            else if (accountsValue[userLogin][fromIndex] > toIndex)
            {
                Console.WriteLine("\nYou do not have enough money to transfer");
                return;
            }
            else
            {
                Console.WriteLine("\nSomething went wrong");
                return;
            }
            Console.WriteLine("Press enter to return to menu.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void WithDrawMoney(int userLogin)
        {
            for (int i = 0; i < accountsName[userLogin].Length; i++)
            {
                string accname = accountsName[userLogin][i];
                decimal accvalue = accountsValue[userLogin][i];
                Console.WriteLine($"{i + 1}: {accname}: {accvalue:C}");
            }

            Console.WriteLine("\nEnter the account index number you want to withdraw from");
            int indexAccount = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.WriteLine("\nEnter the number you want to withdraw from your account?");
            decimal theAmount = Convert.ToDecimal(Console.ReadLine());

            if (accountsValue[userLogin][indexAccount] >= theAmount)
            {
                //first part subtracts from the chosen account 
                accountsValue[userLogin][indexAccount] -= theAmount;
                Console.WriteLine("The withdrawal is now complete!\n");
                Console.WriteLine($"{accountsName[userLogin][indexAccount]}: {accountsValue[userLogin][indexAccount]:C}");
            }
            else if (accountsValue[userLogin][indexAccount] < theAmount)
            {
                Console.WriteLine("\nNot enough money to withdraw\n");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                return;
            }
            Console.WriteLine("\nPress enter to return to menu");
            Console.ReadKey();
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
                Console.Clear();

                switch (userChoice)
                {
                    case 1:
                        AccountsIndex(userLogin, accountsName, accountsValue);
                        break;

                    case 2:
                        TransferMoney(userLogin);
                        break;

                    case 3:
                        WithDrawMoney(userLogin);
                        break;

                    case 4:
                        //while lopp not true, return to login 
                        Console.WriteLine("Signing out...");
                        //pause 1 second before clearing
                        System.Threading.Thread.Sleep(1000);
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

