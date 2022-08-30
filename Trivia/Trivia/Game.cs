using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private const int NumberMaxOfPlayer = 6;
        private const int NumberOfQuestionByCategories = 50;
        private const int ScoreToWin = 6;
        private const int NumberOfBoardBox = 12;
        private readonly bool[] _inPenaltyBox = new bool[NumberMaxOfPlayer];
        private readonly int[] _places = new int[NumberMaxOfPlayer]; //Place of each player
        private readonly List<string> _players = new List<string>();
        private readonly LinkedList<Question> _popQuestions = new LinkedList<Question>();
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly int[] _scores = new int[NumberMaxOfPlayer];
        private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();

        private int _currentPlayer;
        private bool _isGettingOutOfPenaltyBox;

        public Game()
        {
            for (var i = 0; i < NumberOfQuestionByCategories; i++)
            {
                _popQuestions.AddLast(new Question($"{Categories.Pop} Question {i}"));
                _scienceQuestions.AddLast($"{Categories.Science} Question {i}");
                _sportsQuestions.AddLast($"{Categories.Sports} Question {i}");
                _rockQuestions.AddLast($"{Categories.Rock} Question {i}");
            }
        }


        public bool Add(string playerName)
        {
            _players.Add(playerName);
            _places[_players.Count] = 0;
            _scores[_players.Count] = 0;
            _inPenaltyBox[_players.Count] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(_players[_currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);


            if (_inPenaltyBox[_currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    //User is getting out of penalty box
                    _isGettingOutOfPenaltyBox = true;
                    //Write that user is getting out
                    Console.WriteLine(_players[_currentPlayer] + " is getting out of the penalty box");
                    PlayTurn(roll);
                }
                else
                {
                    Console.WriteLine(_players[_currentPlayer] + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                _isGettingOutOfPenaltyBox = false;
                PlayTurn(roll);
            }
        }

        private void PlayTurn(int roll)
        {
            _places[_currentPlayer] += roll;
            if (_places[_currentPlayer] > (NumberOfBoardBox-1)) _places[_currentPlayer] -= NumberOfBoardBox;

            Console.WriteLine(_players[_currentPlayer]
                              + "'s new location is "
                              + _places[_currentPlayer]);
            Console.WriteLine("The category is " + CurrentCategory());
            AskQuestion();
        }

        private void AskQuestion()
        {
            switch (CurrentCategory())
            {
                case Categories.Pop:
                    Console.WriteLine(_popQuestions.First());
                    _popQuestions.RemoveFirst();
                    break;
                case Categories.Science:
                    Console.WriteLine(_scienceQuestions.First());
                    _scienceQuestions.RemoveFirst();
                    break;
                case Categories.Sports:
                    Console.WriteLine(_sportsQuestions.First());
                    _sportsQuestions.RemoveFirst();
                    break;
                case Categories.Rock:
                    Console.WriteLine(_rockQuestions.First());
                    _rockQuestions.RemoveFirst();
                    break;
            }
        }

        private Categories CurrentCategory()
        {
            return _places[_currentPlayer] switch
            {
                0 => Categories.Pop,
                4 => Categories.Pop,
                8 => Categories.Pop,
                1 => Categories.Science,
                5 => Categories.Science,
                9 => Categories.Science,
                2 => Categories.Sports,
                6 => Categories.Sports,
                10 => Categories.Sports,
                _ => Categories.Rock
            };
        }

        public bool WasCorrectlyAnswered()
        {
            if (IsInPenaltyBoxOrIsGettingOutOf())
            {
                IncrementScore();
                Console.WriteLine("Answer was correct!!!!");
                Console.WriteLine(_players[_currentPlayer]
                                    + " now has "
                                    + _scores[_currentPlayer]
                                    + " Gold Coins.");

            }

            bool isNotWinner = HasNoWinner();
            PassToTheNextPlayer();
            return isNotWinner;

        }

        public bool IsInPenaltyBoxOrIsGettingOutOf()
        {
            return !_inPenaltyBox[_currentPlayer] || (_isGettingOutOfPenaltyBox && _inPenaltyBox[_currentPlayer]);
        }

        private bool HasNoWinner()
        {
            return _scores[_currentPlayer] != ScoreToWin;
        }

        private void IncrementScore()
        {
            _scores[_currentPlayer]++;
        }

        private void PassToTheNextPlayer()
        {
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }
        
        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players[_currentPlayer] + " was sent to the penalty box");
            _inPenaltyBox[_currentPlayer] = true;

            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
            return true;
        }
    }
}