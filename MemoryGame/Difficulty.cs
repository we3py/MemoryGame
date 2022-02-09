using System;
using System.Linq;


namespace MemoryGame
{
    public class Difficulty
    {
        private Random _random = new Random();
        private TxtReader _gameFile = new TxtReader(@"Words.txt");
        private int _difficulty;
        private readonly string[,] _slogans;
        private readonly bool[,] _markers;

        public TxtReader GameFile { get => _gameFile;}
        public int GetDifficultyType { get => _difficulty; }
        public Difficulty(int difficultyType)
        {            
            _difficulty = difficultyType;
            if (_difficulty == 0)
            {
                _slogans = new string[4, 2];
            } else if (_difficulty == 1)
            {
                _slogans = new string[8, 2];                
            }

            _markers = new bool[_slogans.GetLength(0), _slogans.GetLength(1)];
        }

        // Using SlogansAssign() method we are getting number of words which are depends on difficulty level
        public string [,] AssignSlogans()
        {
            string[] tempArray = SlogansAssign();
            for (int i = 0; i < _slogans.GetLength(0); i++)
            {
                _slogans[i, 0] = tempArray[i];
            }

            tempArray = tempArray.OrderBy(x => _random.Next()).ToArray();

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
                slogan = GameFile.WordsArray()[_random.Next(GameFile.WordsArray().Length - 1)];
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
            return _markers;
        }

        public string[,] GetSlogans()
        {
            return _slogans;
        }

        public bool ResultCheck()
        {
            for (int i = 0; i < _markers.GetLength(1); i++)
            {
                for (int j = 0; j < _markers.GetLength(0); j++)
                {
                    if (!_markers[j,i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public enum difficultyType
        {
            Easy = 0,
            Hard = 0,
        }
    }
}
