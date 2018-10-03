using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Class1:IComparable
    {
        public List<string> into = new List<string>();
        public List<string> outp = new List<string>();
        public string th;
        public int deep;

        public int CompareTo(object obj)
        {
            Class1 temp = (Class1)obj;
            return deep.CompareTo(temp.deep)*-1;
        }
        public bool Can(List<string> Done)
        {
            int g = 0;
            for(int i = 0; i < Done.Count; i++)
            {
                if (into.Contains(Done[i])) g++;
                if (g == into.Count) return false;
            }
            if (g == into.Count) return false;
            return true;
        }
    }
}
