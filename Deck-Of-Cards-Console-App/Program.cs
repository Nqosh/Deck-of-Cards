using Deck_Of_Cards_Console_App.Enums;
using Deck_Of_Cards_Console_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deck_Of_Cards_Console_App
{
    public class Card
    {
        private readonly CardSuit suit;
        private readonly CardValue value;

        public Card(int iSuit, int iValue)
        {
            suit = (CardSuit)(iSuit);
            value = (CardValue)(iValue);
        }
        public CardSuit CardSuit
        {
            get { return suit; }
        }

        public CardValue CardValue
        {
            get { return value; }
        }
        static int Main(string[] args)
        {
            // this will be set to 52 since final result
            // has to be 52 cards printed 
            int howManyCards = 52;

            //cardDeck used for Draw function
            IDeck cardDeck = new Deck();
            List<Card> hand = new List<Card>();

            cardDeck.Shuffle();
            hand = cardDeck.Draw(howManyCards);
       
            //Display card list on hand
            Console.WriteLine("\nPrint Card List:");

            for (int i = 0; i < hand.Count; i++)
            {
                Console.WriteLine("{0} of {1}", hand[i].CardValue, hand[i].CardSuit);
            }
            Console.WriteLine("{0} {1}", hand.Count, "Cards Printed");
            Console.ReadKey();
            return 0;

        }
    }
}
