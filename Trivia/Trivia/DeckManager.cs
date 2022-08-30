using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class DeckManager
    {
        private readonly Dictionary<Categories, Deck> _decks = new Dictionary<Categories, Deck>();

        public void AddQuestion(Question question, Categories pop)
        {
            if (_decks.GetValueOrDefault(pop) == null)
            {
                _decks.Add(pop, new Deck());
            }
            _decks.GetValueOrDefault(pop)!.AddQuestion(question);
        }

        public Question DrawQuestion(Categories pop)
        {
            return _decks.GetValueOrDefault(pop)!.DrawQuestion();
        }
    }
}