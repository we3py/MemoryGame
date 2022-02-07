using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class BoardLook
    {
        private char _gameField = '?';
        public char GameField => _gameField;
        public enum Rows
        {
            A = 0,
            B = 1
        }

    }
}
