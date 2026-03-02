using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grp_C_C_Activity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.WriteLine("\n=======================================================");
                Console.WriteLine("\t      Group C's Deck of Cards!      \t");
                Console.WriteLine("=======================================================");
                Console.WriteLine("     What would you like to do? (Input numbers 1-5)   ");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("1: Create a Deck");
                Console.WriteLine("2: Shuffle Deck");
                Console.WriteLine("3: Make Deal");
                Console.WriteLine("4: Display Current Deck");
                Console.WriteLine("5: Exit");
                Console.WriteLine("-------------------------------------------------------");
                Console.Write("Your Choice: ");

                try
                {
                    int num = Convert.ToInt32(Console.ReadLine());

                    if (num >= 1 && num <= 5)
                    {
                        switch (num)
                        {
                            case 1:
                                Deck.CreateDeck();
                                break;
                            case 2:
                                Deck.ShuffleDeck();
                                break;
                            case 3:
                                Deck.MakeDeal();
                                break;
                            case 4:
                                Deck.DisplayCurrentDeck();
                                break;
                            case 5:
                                Console.WriteLine("\nThank you for using Group C's Deck of Cards!");
                                exitProgram = true;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Please enter a number between 1 and 5.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid input. Please enter a valid number between 1 and 5.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nAn error occurred: {ex.Message}");
                }
            }
        }
    }
}
