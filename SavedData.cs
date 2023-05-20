using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR7
{
    internal class SavedData
    {
        protected List<string> linesToWrite = new List<string>();
        public void Add(string line)
        {
            linesToWrite.Add(line);
        }
        public void Save(string way)
        {
            File.WriteAllLines(way, linesToWrite);
        }
        public void Clear()
        {
            linesToWrite.Clear();
        }
    }
}
