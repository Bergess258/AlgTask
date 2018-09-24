using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Worker
    {
        public List<Work> Jobs=new List<Work>();
        public int TimeLeft = 0;
        public override string ToString()
        {
            int previos = 0;
            string s = "";
            for(int i = 0; i < Jobs.Count - 1; i++)
            {
                s += Jobs[i].name + "(" + previos + "-" + (Jobs[i].time + previos) + "),";
                previos += Jobs[i].time;
            }
            s += Jobs[Jobs.Count - 1].name + "(" + previos + "-" + (Jobs[Jobs.Count - 1].time + previos) + ")";
            return s;
        }
    }
}