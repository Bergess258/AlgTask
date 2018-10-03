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
            for (int i = 0; i < countEmp; i++)
                Workers[i] = new Worker();
            string[] all = new string[1];
            List<Work> Works = new List<Work>();
            int c = 0, max = 0;
            while(true)
            {
                try
                {
                    all = Reader.ReadLine().Split(' ');
                }
                catch { break; }
                Works.Add(new Work() { time= Convert.ToInt32(all[1]) ,name=all[0]});
                if (Works[c].time > max) max = Works[c].time;
                c++;
            }
            Reader.Close();
            c = 0;
            for (int i = 0; i < Works.Count; i++)
                c += Works[i].time;
            int add = c % Workers.Length;
            c = Convert.ToInt32(Math.Ceiling(1.0*c / countEmp));
            int limit = 0;
            if (max > c)
                limit = max;
            else
                limit = c;
            c = 0;
            for(int i = 0; i < Works.Count; i++)
            {
                while (Works[i].time > 0)
                {
                    if (Workers[c].TimeLeft + Works[i].time <= limit) { Workers[c].TimeLeft += Works[i].time; Workers[c].Jobs.Add(new Work() { name = Works[i].name, time = Works[i].time }); Works[i].time = 0 ;}
                    else
                    {
                        int temp = limit - Workers[c].TimeLeft;
                        Workers[c].TimeLeft = limit;
                        Works[i].time -= temp;
                        Workers[c].Jobs.Add(new Work() { name = Works[i].name, time = temp });
                    }
                    if(Workers[c].TimeLeft==limit)
                    c++;
                }
            }
            foreach(Worker i in Workers)
            Console.WriteLine(i);
        }
    }
}