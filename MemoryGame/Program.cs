using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Program
    {
        
        static void Main(string[] args)
        {


            Regex regex = new Regex("^[0-2]");
            Regex difficultyRegex = new Regex("^[0-1]");
            bool isPlaying = true;
            while (isPlaying)
            {
                Console.WriteLine(BoardLook.GetLogo());
                Console.WriteLine(BoardLook.GetDescription());
                Console.WriteLine(BoardLook.GetMenu());
                

                string command = Console.ReadLine().Trim();
                if (!regex.IsMatch(command) || String.IsNullOrEmpty(command) || command.Length > 1)
                {
                    Console.Clear();
                    continue;
                }


                switch (Int32.Parse(command))
                {
                    case 0:

                        Console.Clear();
                        Console.WriteLine(BoardLook.GetDifficultyQuestion());
                        string level = Console.ReadLine();
                        Console.Clear();

                        while (true)
                        {    
                            if (!difficultyRegex.IsMatch(level) || String.IsNullOrEmpty(level) || level.Length > 1)
                            {
                                Console.WriteLine("Choose level");
                                level = Console.ReadLine();
                                Console.Clear();                               
                                continue;
                            } else
                                break;
                        }
                        

                        Game newGame = new Game(Int32.Parse(level));
                        Console.Clear();
                        newGame.Run();
                        Console.WriteLine("If u want start a new game, press ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    case 1:
                        Console.WriteLine("Showing highscore");
                        break;
                    case 2:
                        isPlaying = false;
                        break;
                        
                }

                break;
                
            }








        
        
           
            
            
            



        }
        

    }
}
