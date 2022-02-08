using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Program
    {
        //Testing game
        static void Main(string[] args)
        {
            
            Difficulty difficulty = new Difficulty(0);
            Board board = new Board();


            board.DrawBoard(difficulty);
            Console.WriteLine(Console.BufferWidth);

           
            
            Console.WriteLine();

            
            



        }
    }
}
