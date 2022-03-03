using Deck_Of_Cards_Console_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deck_Of_Cards_Console_App
{
    public class Deck : IDeck
    {
        public List<Card> CardSet;

        //Random Number generation variables
        private static readonly Random rand = new Random();
        private static readonly object syncLock = new object();

        /// <summary>
        /// Generates random number within the range of min to max-1
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Random Number Integer</returns>
        public int RandomNumber(int min, int max)
        {
            lock (syncLock)
            {
                return rand.Next(min, max);
            }
        }


        /// <summary>
        /// Deck Constructor
        /// </summary>
        public Deck()
        {
            CardSet = new List<Card>();
            for (int i = 0; i < 4; i++)         //Suit values 0-3 (0-clubs, 1-diamonds, 2-hearts, 3-spades)
            {
                for (int j = 1; j < 14; j++)    //Card values 1-13 (values ordered from 2 to Ace, Ace is high)
                {
                    CardSet.Add(new Card(i, j));
                }
            }
        }

        /// <summary>
        /// Shuffle the deck.
        /// </summary>
        public void Shuffle()
        {

            //Knuth Fisher Yates Shuffle in place
            for (int i = 0; i < CardSet.Count; i++)
            {
                var temp = CardSet[i];
                var index = RandomNumber(0, CardSet.Count);
                CardSet[i] = CardSet[index];
                CardSet[index] = temp;
            }
        }


        /// <summary>
        /// Draw a the specified number of cards from the deck.
        /// </summary>
        /// <param name="howMany">how many cards to draw.</param>
        /// <returns>the list of drawn cards</returns>
        public List<Card> Draw(int howManyCards)
        {
            List<Card> userHand = new List<Card>();

            for (int i = 0; i < howManyCards; i++)
            {
                int index = RandomNumber(0, CardSet.Count);

                userHand.Add(new Card((int)CardSet[index].CardSuit, (int)CardSet[index].CardValue));
                CardSet.RemoveAt(index);
            }

            return userHand;
        } 
    }
}
