using System;
using System.Linq;


namespace MemoryGame
{
    public class Difficulty
    {
        private Random random = new Random();
        private TxtReader _gameFile = new TxtReader(@"C:\Words.txt");
        private readonly string[,] _slogans;
        private readonly bool[,] _markers;

        public TxtReader GameFile { get => _gameFile;}

        public Difficulty(int difficultyType)
        {            
            if (difficultyType == 0)
            {
                _slogans = new string[4, 2];
            } else if (difficultyType == 1)
            {
                _slogans = new string[8, 2];                
            }

            _markers = new bool[_slogans.GetLength(0), _slogans.GetLength(1)];
        }

        // Using SlogansAssign() method we are getting number of words which are depends on difficulty level
        public string [,] GetSlogans()
        {
            string[] tempArray = SlogansAssign();
            for (int i = 0; i < _slogans.GetLength(0); i++)
            {
                _slogans[i, 0] = tempArray[i];
            }

            tempArray = tempArray.OrderBy(x => random.Next()).ToArray();

            for (int i = 0; i < _slogans.GetLength(0); i++)
            {
                _slogans[i, 1] = tempArray[i];
            }

            return _slogans;
        }

        // Assigning slogans to array
        private string[] SlogansAssign()
        {
            string slogan;
            string[] tempArray = new string[_slogans.GetLength(0)];
            for (int i = 0; i < tempArray.Length; i++)
            {
                slogan = GameFile.WordsArray()[random.Next(GameFile.WordsArray().Length - 1)];
                if (Array.Find(tempArray, x => x == slogan) != null)
                {
                    i--;
                } else
                {
                    tempArray[i] = slogan;
                }
                
            }

            return tempArray;
        }

        public bool[,] GetMarkers()
        {
            
            for (int i = 0; i < _markers.GetLength(1); i++)
            {
                for (int j = 0; j < _markers.GetLength(0); j++)
                {
                    _markers[j, i] = true;
                }
            }

            return _markers;
        }

        public bool AnswerCheck(string answerOne, string answerTwo)
        {

            return true;
        }
    }
}
