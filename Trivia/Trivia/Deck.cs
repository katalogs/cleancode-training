using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Deck
    {
        private LinkedList<Question> _questions { get; set; }

        public Deck()
        {
            _questions = new LinkedList<Question>();
        }

        public void AddQuestion(Question question)
        {
            _questions.AddLast(question);
        }

        public Question DrawQuestion()
        {
            var firstQuestion = _questions.First();
            _questions.RemoveFirst();
            return firstQuestion;
        }
    }
}