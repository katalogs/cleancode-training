namespace Trivia
{
    public class Question
    {
        private string _content;
        public Question(string content)
        {
           _content = content;
        }

        public override string ToString()
        {
            return _content;
        }
    }
}