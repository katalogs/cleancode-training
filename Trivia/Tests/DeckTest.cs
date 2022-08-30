using Trivia;
using Xunit;

namespace Tests
{
    public class DeckTest
    {
        [Fact]
        public void DrawQuestionShouldReturnTheFirstQuestionOfTheDeck()
        {
            // arrange
            var deck = new Deck();
            const string expected = "test";
            deck.AddQuestion(new Question(expected));
            deck.AddQuestion(new Question("toto"));
            
            // act
            var question = deck.DrawQuestion();
            // assert
            Assert.Equal(expected, question.ToString());
        }  
        
        [Fact]
        public void DrawTwoQuestionShouldReturnTwoDifferentText()
        {
            // arrange
            var deck = new Deck();
            const string expected = "test";
            deck.AddQuestion(new Question(expected));
            var expected2 = "toto";
            deck.AddQuestion(new Question(expected2));
            
            // act
            var question1 = deck.DrawQuestion();
            var question2 = deck.DrawQuestion();
            // assert
            Assert.Equal(expected, question1.ToString());
            Assert.Equal(expected2, question2.ToString());
        }  
    }
}