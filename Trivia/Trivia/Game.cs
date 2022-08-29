﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private const int NumberMaxOfPlayer = 6;
        private const int NumberOfQuestionByCategories = 50;

        private readonly bool[] _inPenaltyBox = new bool[NumberMaxOfPlayer];

        private readonly int[] _places = new int[NumberMaxOfPlayer]; //Place of each player

        private readonly List<string> _players = new List<string>();
        private readonly int[] _purses = new int[NumberMaxOfPlayer]; 

        private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();


        private int _currentPlayer;
        private bool _isGettingOutOfPenaltyBox;

        public Game()
        {
            for (var i = 0; i < NumberOfQuestionByCategories; i++)
            {
                _popQuestions.AddLast($"{Categories.Pop} Question {i}");
                _scienceQuestions.AddLast($"{Categories.Science} Question {i}");
                _sportsQuestions.AddLast($"{Categories.Sports} Question {i}");
                _rockQuestions.AddLast($"{Categories.Rock} Question {i}");
            }
        }


        public bool Add(string playerName)
        {
            _players.Add(playerName);
            _places[_players.Count] = 0;
            _purses[_players.Count] = 0; 
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
                    NewMethod(roll);
                }
                else
                {
                    Console.WriteLine(_players[_currentPlayer] + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                NewMethod(roll);
            }
        }

        private void NewMethod(int roll)
        {
            _places[_currentPlayer] += roll;
            if (_places[_currentPlayer] > 11) _places[_currentPlayer] -= 12;

            Console.WriteLine(_players[_currentPlayer]
                              + "'s new location is "
                              + _places[_currentPlayer]);
            Console.WriteLine("The category is " + CurrentCategory());
            AskQuestion();
        }

        private void AskQuestion()
        {
            if (CurrentCategory() == Categories.Pop.ToString())
            {
                Console.WriteLine(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }

            if (CurrentCategory() == Categories.Science.ToString())
            {
                Console.WriteLine(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }

            if (CurrentCategory() == Categories.Sports.ToString())
            {
                Console.WriteLine(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }

            if (CurrentCategory() == Categories.Rock.ToString())
            {
                Console.WriteLine(_rockQuestions.First());
                _rockQuestions.RemoveFirst();
            } 
        }

        private string CurrentCategory()
        {
            return _places[_currentPlayer] switch
            {
                0 => Categories.Pop.ToString(),
                4 => Categories.Pop.ToString(),
                8 => Categories.Pop.ToString(),
                1 => Categories.Science.ToString(),
                5 => Categories.Science.ToString(),
                9 => Categories.Science.ToString(),
                2 => Categories.Sports.ToString(),
                6 => Categories.Sports.ToString(),
                10 => Categories.Sports.ToString(),
                _ => Categories.Rock.ToString()
            };
        }

        public bool WasCorrectlyAnswered()
        {
            if (_inPenaltyBox[_currentPlayer])
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    _purses[_currentPlayer]++;
                    Console.WriteLine(_players[_currentPlayer]
                                      + " now has "
                                      + _purses[_currentPlayer]
                                      + " Gold Coins.");

                    var winner = _purses[_currentPlayer] != 6;
                    _currentPlayer++;
                    if (_currentPlayer == _players.Count) _currentPlayer = 0;

                    return winner;
                }

                _currentPlayer++;
                if (_currentPlayer == _players.Count) _currentPlayer = 0;
                return true;
            }
            else
            {
                Console.WriteLine("Answer was corrent!!!!");
                _purses[_currentPlayer]++;
                Console.WriteLine(_players[_currentPlayer]
                                  + " now has "
                                  + _purses[_currentPlayer]
                                  + " Gold Coins.");

                var winner = _purses[_currentPlayer] != 6;
                _currentPlayer++;
                if (_currentPlayer == _players.Count) _currentPlayer = 0;

                return winner;
            }
        }

        /// <summary>
        ///     To call when the answer is right
        /// </summary>
        /// <returns></returns>
        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players[_currentPlayer] + " was sent to the penalty box");
            _inPenaltyBox[_currentPlayer] = true;

            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
            //Must always return false 
            return true;
        }
    }
}