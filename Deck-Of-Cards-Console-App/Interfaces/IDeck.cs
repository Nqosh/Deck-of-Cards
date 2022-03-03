using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deck_Of_Cards_Console_App.Interfaces
{
    public interface IDeck
    {
        int RandomNumber(int min, int max);
        void Shuffle();
        List<Card> Draw(int howManyCards);
    }
}
