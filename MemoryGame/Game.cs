using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class Game
    {
        private Difficulty difficulty;
        private BoardLook boardLook;
        private Board board;
        private HighScore highscore;

        public Game(int level)
        {            
            difficulty = new Difficulty(level);
            boardLook = new BoardLook(difficulty);           
            highscore = new HighScore(difficulty);
            board = new Board(boardLook, highscore);
        }
        public void Run()
        {           
            
            while (true)
            {
                
                board.DrawBoard(difficulty);
                Console.WriteLine();

                Console.WriteLine("Choose your FIRST answer: ");
                string first = Console.ReadLine();

                
                if (!ShowAnswer(first))
                {
                    continue;
                }
                
                Console.WriteLine("Choose your SECOND answer: ");
                string second = Console.ReadLine();
               
                if (!ShowAnswer(first, second))
                {
                    HideAnswer(first);
                    continue;
                }

                if (!AnswerComparison(boardLook.GetDifficulty.GetSlogans(), first, second))
                {
                    highscore.LifePoints = highscore.LifePoints - 1;
                }

                highscore.TotalAttempts += 1;

                if (highscore.LifePoints == 0)
                {
                    Console.WriteLine("U LOSE - GAME OVER");
                    
                    break;
                }
                else if (difficulty.ResultCheck())
                {
                    int time;
                    Console.WriteLine("Congratulations! U WON");
                    Console.WriteLine("You play {0} seconds", time = highscore.GetGameTime());
                    Console.WriteLine("Type your name: ");
                    highscore.Name = Console.ReadLine().Trim();
                    Console.WriteLine(highscore.finalScore(time));
                    
                    break;

                }
            }
        }

        // Covering word 
        private void HideAnswer(string firstTry)
        {
            var firstAnswer = AnswerRead(firstTry);
            var markers = difficulty.GetMarkers();
            markers[firstAnswer[0], firstAnswer[1]] = false;
        }

        // Uncovering first word after choose
        private bool ShowAnswer(string firstTry)
        {
            var firstAnswer = AnswerRead(firstTry);
            var markers = difficulty.GetMarkers();

            if (firstAnswer == null)
            {
                return false;
            }

            if (markers[firstAnswer[0], firstAnswer[1]])
            {
                Console.WriteLine("U already guess it!");
                Thread.Sleep(2000);
                return false;
            }


            markers[firstAnswer[0], firstAnswer[1]] = true;
            board.DrawBoard(difficulty);

            Console.WriteLine();

            return true;
        }

        // Uncovering second word, int this method additionaly checks if we choose wrod from the same row
        private bool ShowAnswer(string firstTry, string secondTry)
        {

            var firstAnswer = AnswerRead(firstTry);
            var secondAnswer = AnswerRead(secondTry);
            var markers = difficulty.GetMarkers();

            if (secondAnswer == null)
            {
                return false;
            }

            if (markers[secondAnswer[0], secondAnswer[1]])
            {
                Console.WriteLine("U already guess it!");
                Thread.Sleep(2000);
                return false;
            }

            if (secondAnswer[1] == firstAnswer[1])
            {
                return true;
            }

            markers[secondAnswer[0], secondAnswer[1]] = true;
            board.DrawBoard(difficulty);

            Console.WriteLine();

            return true;
        }

        // Converts given coordinates to int array. [0] - column; [1] = row
        private int[] AnswerRead(string answerGiven)
        {
            string answerToRead = answerGiven.Trim();
            string pattern = @"^[a-bA-B1-" + difficulty.GetSlogans().GetLength(0) + "]*$";
            var regex = new Regex(pattern);
            int[] answer = new int[2];
            
            if ((!regex.IsMatch(answerToRead) || (String.IsNullOrEmpty(answerToRead)) || ( answerToRead.Length < 2|| answerToRead.Length > 2)))
            {
                Console.WriteLine("WRONG COORDINATES");
                Thread.Sleep(2000);

                return null;
            }

            int column = Int32.Parse(new String(answerToRead.Where(Char.IsDigit).ToArray()));
            int row = (int)Enum.Parse(typeof(BoardLook.Rows), new string(answerToRead.Where(Char.IsLetter).ToArray()).ToUpper());

            answer[0] = column - 1;
            answer[1] = row;
      
            return answer;
        }

        // Comparising two answers and returning bool value whether it is correct (true) answer or not (false)
        private bool AnswerComparison(string[,] array, string firstTry, string secondTry)
        {
            var firstAnswer = AnswerRead(firstTry);
            var secondAnswer = AnswerRead(secondTry);

            if (firstAnswer == null || secondAnswer == null)
            {
                return true;
            }
            var markers = difficulty.GetMarkers();
            var comparison = array[firstAnswer[0], firstAnswer[1]] == array[secondAnswer[0], secondAnswer[1]];
            
            // Checks if given coordinates are in valid range
            if (firstAnswer[0] < 0 || secondAnswer[0] < 0)
            {
                markers[firstAnswer[0], firstAnswer[1]] = false;
                markers[secondAnswer[0], secondAnswer[1]] = false;
                Console.WriteLine("WRONG COORDINATES");
                Thread.Sleep(2000);
                return true;

            }

            // Checks if given coordinates are from the same row
            if (firstAnswer[1] == secondAnswer[1])
            {
                markers[firstAnswer[0], firstAnswer[1]] = false;
                markers[secondAnswer[0], secondAnswer[1]] = false;
                Console.WriteLine("U can't pick words form same ROW");
                Thread.Sleep(2000);
                return true;
                    
            }

            // Checks if result of comparison is true or false                               
            if(comparison) 
            {
                Console.WriteLine("Good job, u FOUND IT!");
                Thread.Sleep(2000);
                markers[firstAnswer[0], firstAnswer[1]] = true;
                markers[secondAnswer[0], secondAnswer[1]] = true;
                return true;
            }
            else
            {
                Console.WriteLine("Wrong ANSWER!");
                Thread.Sleep(2000);
                markers[firstAnswer[0], firstAnswer[1]] = false;
                markers[secondAnswer[0], secondAnswer[1]] = false;
                return false;
            }
            
        }
    }
}
