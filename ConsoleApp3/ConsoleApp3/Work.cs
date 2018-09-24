using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Work:IComparable
    {
        public int time;
        public string name;
        public bool[] Cantbe;
        public int CompareTo(object obj)
        {
            Work temp = (Work)obj;
            return time.CompareTo(temp.time)*-1;
        }
    }
}
