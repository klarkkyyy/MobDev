using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grp_C_C_Activity
{
    internal class Deck
    {
        private static List<Card> cards = new List<Card>();
        private static Random random = new Random();

        public static void CreateDeck()
        {
            try
            {
                cards.Clear();
                string[] suits = { "Cloves", "Diamond", "Heart", "Spade" };
                string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Ace", "Jack", "Queen", "King" };

                foreach (string suit in suits)
                {
                    foreach (string rank in ranks)
                    {
                        cards.Add(new Card(suit, rank));
                    }
                }

                Console.WriteLine("\nDeck created successfully! 52 cards have been added to the deck.");
                Console.WriteLine($"Total cards in deck: {cards.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating deck: {ex.Message}");
            }
        }

        public static void ShuffleDeck()
        {
            try
            {
                if (cards.Count == 0)
                {
                    Console.WriteLine("\nError: Cannot shuffle an empty deck! Please create a deck first.");
                    return;
                }

                int n = cards.Count;
                for (int i = n - 1; i > 0; i--)
                {
                    int j = random.Next(0, i + 1);
                    Card temp = cards[i];
                    cards[i] = cards[j];
                    cards[j] = temp;
                }

                Console.WriteLine("\nDeck shuffled successfully!");
                Console.WriteLine($"Total cards in deck: {cards.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error shuffling deck: {ex.Message}");
            }
        }

        public static void MakeDeal()
        {
            try
            {
                if (cards.Count == 0)
                {
                    Console.WriteLine("\nError: Cannot deal from an empty deck! Please create a deck first.");
                    return;
                }

                Console.Write("\nHow many cards would you like to deal? ");
                int numToDeal = Convert.ToInt32(Console.ReadLine());

                if (numToDeal <= 0)
                {
                    Console.WriteLine("Error: Please enter a positive number.");
                    return;
                }

                if (numToDeal > cards.Count)
                {
                    Console.WriteLine($"Error: Not enough cards in the deck! Only {cards.Count} cards remaining.");
                    return;
                }

                Console.WriteLine($"\nDealing {numToDeal} card(s):");
                Console.WriteLine("-------------------------------------------------------");

                List<Card> dealtCards = new List<Card>();
                for (int i = 0; i < numToDeal; i++)
                {
                    Card dealtCard = cards[cards.Count - 1];
                    cards.RemoveAt(cards.Count - 1);
                    dealtCards.Add(dealtCard);
                    Console.WriteLine(dealtCard);
                }

                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($"Cards remaining in deck: {cards.Count}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error dealing cards: {ex.Message}");
            }
        }

        public static void DisplayCurrentDeck()
        {
            try
            {
                if (cards.Count == 0)
                {
                    Console.WriteLine("\nError: The deck is empty! Please create a deck first.");
                    return;
                }

                Console.WriteLine("\n=======================================================");
                Console.WriteLine($"Current Deck - {cards.Count} card(s) remaining:");
                Console.WriteLine("=======================================================");

                for (int i = 0; i < cards.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {cards[i]}");
                }

                Console.WriteLine("=======================================================");
                Console.WriteLine($"Total cards in deck: {cards.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying deck: {ex.Message}");
            }
        }
    }
}
