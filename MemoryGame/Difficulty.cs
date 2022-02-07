using System;

namespace MemoryGame
{
    public class Difficulty
    {
        private Random random = new Random();
        private TxtReader _gameFile = new TxtReader(@"C:\Words.txt");
        private readonly string[,] _slogans;

        //"N" means NO - not guessed and it is assigned to every slogan in array
        private string _sloganMarker = "N";
        public Difficulty(int difficultyType)
        {            
            if (difficultyType == 0)
            {
                _slogans = new string[8, 2];
            } else if (difficultyType == 1)
            {
                _slogans = new string[16, 2];
                
            }
        }

        //Assigning slogans to array cells
        public string [,] getSlogans()
        {
            for (int i = 0; i < _slogans.GetLength(0) / 2; i++)
            {
                _slogans[i, 0] = _gameFile.WordsArray()[random.Next(_gameFile.WordsArray().Length - 1)];
            }

            for (int i = _slogans.GetLength(0) / 2; i < _slogans.GetLength(0); i++)
            {
                Array.
                _slogans[i, 0] = _slogans[random.Next(0, _slogans.GetLength(0) / 2 - 1), 0];
            }

            for (int i = 0; i < _slogans.GetLength(0); i++)
            {
                _slogans[i, 1] = _sloganMarker;
            }

            return _slogans;
        }
    }
}
