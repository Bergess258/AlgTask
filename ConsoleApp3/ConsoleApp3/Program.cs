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
            int c = 0, max = 0,maxi=0;
            while(true)
            {
                try
                {
                    all = Reader.ReadLine().Split(' ');
                }
                catch { break; }
                Works.Add(new Work() { time= Convert.ToInt32(all[1]) ,name=all[0]});
                if (Works[c].time > max) { max = Works[c].time; maxi = c; }
                c++;
            }
            Reader.Close();
            c = 0;
            for (int i = 0; i < Works.Count; i++)
                c += Works[i].time;
            c = c / Works.Count + 1;
            int limit = 0;
            if (max > c)
                limit = max;
            else
                limit = c;
            Workers[0].Jobs.Add(Works[maxi]);
            Workers[0].TimeLeft = max;
            Works.RemoveAt(maxi);
            Works.Sort();
            for (int i = 0; i < Works.Count; i++)
            {
                Works[i].Cantbe = new bool[limit];
            }
            for(int i = 0; i < Workers.Length; i++)
            {
                if(Workers[i].TimeLeft<=limit)
                for(int a = 0; a < Works.Count; a++)
                {
                    if(Workers[i].TimeLeft+Works[a].time<=limit) { Workers[i].TimeLeft += Works[a].time;Workers[i].Jobs.Add(new Work() { name = Works[a].name, time = Works[a].time }); Works.RemoveAt(a);a = -1; }
                }
            }
            while (Works.Count > 0)
            {
                while (Works[0].time > 0)
                {
                    bool ok = true,check=false;
                    for(int i = 0; i < Workers.Length; i++)
                    {
                        if (Workers[i].TimeLeft < limit)
                        {
                            int temp = limit-Workers[i].TimeLeft;
                            if (check == false)
                            {
                                if (ok == true)
                                {
                                    if (Works[0].time > temp)
                                    {
                                        Workers[i].Jobs.Add(new Work() { name = Works[0].name, time = temp });
                                        Works[0].time -= temp;
                                        for (int te = Workers[i].TimeLeft; te < limit; te++)
                                            Works[0].Cantbe[te] = true;
                                        if (ok != false) ok = false;
                                        else
                                            check = true;
                                    }
                                    else
                                    {
                                        Workers[i].Jobs.Add(Works[0]);
                                        Works.RemoveAt(0);
                                    }
                                }
                                else
                                {
                                    if (Works[0].time > temp)
                                    {
                                        int c1 = limit - Workers[i].TimeLeft;
                                        for (int te = 0; te < c1; te++)
                                            if (Works[0].Cantbe[te] != true)
                                                Works[0].Cantbe[te] = true;
                                            else
                                                c1++;
                                        Workers[i].Jobs.Insert(0, new Work() { name = Works[0].name, time = temp });
                                        Works[0].time -= temp;
                                        Workers[i].Jobs[0].time -= c1;
                                        Works[0].time += c1;
                                        if (ok != false) ok = false;
                                        else
                                            check = true;
                                    }
                                    else
                                    {
                                        Workers[i].Jobs.Insert(0, Works[0]);
                                        Works.RemoveAt(0);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach(Worker i in Workers)
            Console.WriteLine(i);
        }
    }
}