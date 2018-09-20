using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader Reader = new StreamReader("input.txt");
            int countEmp = Convert.ToInt32(Reader.ReadLine());
            string[] all = Reader.ReadToEnd().Split(' ');
            Work[] Works = new Work[all.Length / 2];
            int c = 0;
            for(int i = 0; i < all.Length; i += 2)
            {
                Works[c].time = Convert.ToInt32(all[i]);
                Works[c].name = all[i + 1];
            }
        }
    }
}
