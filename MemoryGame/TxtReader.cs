using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class TxtReader
    {
        private static string _path = null;
        private StreamReader _pathToRead = null;
        private readonly string[] _allWordsTab;

        public static string GetPath { get => _path; }

        public TxtReader(string input)
        {
            _path = input;
            _pathToRead = File.OpenText(_path);
            _allWordsTab = _pathToRead.ReadToEnd().Split('\n');
            _pathToRead.Close();

        }

        public string[] WordsArray()
        {
            return _allWordsTab;
        }

        
    }
   
}
