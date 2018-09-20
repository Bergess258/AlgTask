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
            Worker[] Workers = new Worker[countEmp];
            string[] all = Reader.ReadToEnd().Split(' ');
            List<Work> Works = new List<Work>(all.Length / 2);
            int c = 0, max = 0,maxi=0;
            for(int i = 0; i < all.Length; i += 2)
            {
                Works[c].time = Convert.ToInt32(all[i+1]);
                if (Works[c].time > max) { max = Works[c].time; maxi = c; }
                Works[c++].name = all[i];
            }
            c = 0;
            for (int i = 0; i < Works.Count; i++)
                c += Works[i].time;
            c = c / Works.Count + 1;
            if (max > c)
            {
                int limit = max;
                Workers[0].Jobs.Add(Works[maxi]);
                Works.RemoveAt(maxi);
                int numb = 1;
                while (Works.Count > 0)
                {
                    if (Works[0].time > limit)
                    {
                        Workers[numb++].Jobs.Add(new Work() { time = limit, name = Works[0].name });
                        Works[0].time -= limit;
                        int time = 0;
                        for(int i = 0; i < Works.Count-1; i++)
                            time += Works[i].time;

                    }
                    else
                        if (Works[0].time == limit) { Workers[numb].Jobs.Add(Works[0]); Works.RemoveAt(0); }
                    else

                }
            }
        }
    }
}
