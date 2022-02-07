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
        private StreamReader _path = null;
        private string[] _allWordsTab;

        public TxtReader(string input)
        {
            _path = File.OpenText(input);
            _allWordsTab = _path.ReadToEnd().Split('\n');

        }

        public string[] WordsArray()
        {
            return _allWordsTab;
        }
    }
}
