using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Program
    {
        static void Main(string[] args)
        {
            void Withdraw(Card user, decimal amount)
            {
                user.SetCurrBalance(user.GetCurrBalance() - amount);
            }

            void Deposit(Card user, decimal amount)
            {
                user.SetCurrBalance(user.GetCurrBalance() + amount);
            }

            List<Card> cards = new List<Card>();

            //Adding a few test cards
            cards.Add(new Card("Sebo", "Zvesk", "4324801497059271", "1234"));
            cards.Add(new Card("Anenechukwu", "Otte", "4101899996427592", "1234"));

            while (true)
            {
                Card user = null;

                //User must input a valid card number (ther card must be included in the cards repository)
                try
                {
                    while (true)
                    {
                        Console.WriteLine("Please insert your card!");
                        string currCardNum = Console.ReadLine();
                        user = cards.FirstOrDefault(x => x.GetCardNum() == currCardNum);

                        if (user != null)
                        {
                            break;
                        }

                        Console.WriteLine("Invalid Card");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid Card");
                }

                if(user.isBlocked()) //If the card is blocked the user wont be allowed to use the card
                {
                    Console.WriteLine("Your card is currently blocked.");
                    continue;
                }

                Console.WriteLine($"Hello {user.GetFirstName()} {user.GetLastName()}! Please enter your PIN!");

                bool correctPIN = false;

                for (int i = 3; i > 0; i--) //The user must enter theirs PIN within 3 tries otherwise the card will be blocked
                {
                    string PIN = Console.ReadLine();

                    if(PIN == user.GetPIN())
                    {
                        correctPIN = true;
                        break;
                    }

                    Console.WriteLine($"Wrong PIN! You have left {i - 1} tries");
                }

                if(!correctPIN) //Blocks card if PIN is not correct
                {
                    Console.WriteLine("Your card has been blocked!");
                    user.BlockCard();
                    continue;
                }

                //user chosses action repeatedly until they want to exit.
                try
                {
                    while (true)
                    {
                        Console.WriteLine("Choose action:");
                        Console.WriteLine("1. Deposit");
                        Console.WriteLine("2. Withdraw");
                        Console.WriteLine("3. Check balance");
                        Console.WriteLine("4. Exit");

                        int action = int.Parse(Console.ReadLine());

                        if (action == 1) //Deposits money
                        {
                            Console.WriteLine("What amount would you like to deposit?");
                            decimal amount = decimal.Parse(Console.ReadLine());

                            if(amount > 0)
                            {
                                Deposit(user, amount);

                                Console.WriteLine($"{amount:f2}lv. deposited!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount!");
                            }
                        }
                        else if (action == 2)//Withdraws money
                        {
                            Console.WriteLine("What amount would you like to withdraw?");
                            decimal amount = decimal.Parse(Console.ReadLine());

                            if(amount <= user.GetCurrBalance())
                            {
                                Withdraw(user, amount);
                                Console.WriteLine($"{amount:f2}lv. withdrawn!");
                            }
                            else
                            {
                                Console.WriteLine("The card does not have that much money!");
                            }

                        }
                        else if (action == 3)//Shows current balance
                        {
                            Console.WriteLine($"Your curent balance is {user.GetCurrBalance():f2}");
                        }
                        else if (action == 4)//Returns the program to its beggining. Redy for the next user.
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid action!");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid action!");
                }
            }
        }
    }
}
