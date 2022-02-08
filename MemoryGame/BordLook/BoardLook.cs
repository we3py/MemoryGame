using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class BoardLook
    {
        private string _gameField;
        public string GameField { get => _gameField; set => _gameField =  "?"; }
        public enum Rows
        {
            A = 0,
            B = 1
        }

    }
}
