using System;
using System.Text;
using rules;
using view;
using crypt;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Rules rule = new Rules(args);
            RandomCrypt hmac;
            if (Rules.Combs != null)
            {
                bool isNext = true;
                while (isNext)
                {
                    Console.Clear();
                    hmac = new RandomCrypt();
                    int index = RandomCrypt.getComputerMove();
                    string compMove = args[index];
                    hmac.HMAC.ComputeHash(Encoding.UTF8.GetBytes(compMove));
                    View.showMenu(args, hmac);
                    Console.Write("Your move: ");
                    string choice = Console.ReadLine();

                    if (int.TryParse(choice, out int num))
                    {
                        if (num >= 1 && num <= Rules.Combs.Count)
                        {
                            string userMove = args[num - 1];
                            Conditions userState = Rules.Combs[userMove][index];
                            string state = "";
                            if (userState == Conditions.win)
                            {
                                state = "You win!";
                            }
                            else if (userState == Conditions.lose)
                            {
                                state = "You lose!";
                            }
                            else
                            {
                                state = "Nobody wins";
                            }
                            View.showResult(userMove, compMove, state, hmac);
                            Console.WriteLine("Нажмите любую клавишу...");
                            Console.ReadKey();
                            
                        }
                        else if (num == 0)
                        {
                            isNext = false;
                        }
                    }
                    else if (choice == "?")
                    {
                        View.showTable();
                        Console.WriteLine("Нажмите любую клавишу...");
                        Console.ReadKey();
                    }
                    
                }
                
                
            }
                    
            Console.WriteLine();
        }
    }
}