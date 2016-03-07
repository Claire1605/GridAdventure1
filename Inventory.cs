using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridAdventure1
{
    public class Inventory
    {
        public Dictionary<string, int> dictionary = new Dictionary<string, int>();
        public void Inv()
        {
            dictionary = new Dictionary<string, int>();
        }

        public Dictionary<string, int> getInvDictionary()
        {
            return this.dictionary;
        }
    }
}
