using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader Reader = new StreamReader("input.txt");
            int countEmp = Convert.ToInt32(Reader.ReadLine());
            string[] Emp = new string[countEmp];
            List<Class1> main = new List<Class1>();
            {
                string[] all = new string[2];
                while (true)
                {
                    try
                    {
                        all = Reader.ReadLine().Split(' ');
                    }
                    catch { break; }
                    bool ok1 = false, ok2 = false;
                    for (int i = 0; i < main.Count; i++)
                    {
                        if (main[i].th == all[0])
                        {
                            main[i].outp.Add(all[1]);
                            if (ok2 == true) break;
                            ok1 = true;
                        }
                        else
                            if (main[i].th == all[1])
                        {
                            main[i].into.Add(all[0]);
                            if (ok1 == true) break;
                            ok2 = true;
                        }
                    }
                    if (ok1 == false)
                    {
                        main.Add(new Class1() { th = all[0] });
                        main[main.Count - 1].outp.Add(all[1]);
                    }
                    if (ok2 == false)
                    {
                        main.Add(new Class1() { th = all[1] });
                        main[main.Count - 1].into.Add(all[0]);
                    }
                }
            }
            Reader.Close();
            {
                List<int> treeWO = new List<int>();
                for (int i = 0; i < main.Count; i++)
                    if (main[i].outp.Count == 0) { treeWO.Add(i); main[i].deep = 0; }
                foreach (int i in treeWO)
                {
                    foreach (string s in main[i].into)
                        Fill(ref main, s, 1);
                }
            }
            main.Sort();
            int c = main[0].deep,stop = 0;
            List<string> Done = new List<string>();
            List<int> shouldBeD = new List<int>();
            while (Done.Count<main.Count)
            {
                int t = 0;
                List<string> doneInThisStep = new List<string>();
                if (shouldBeD.Count != 0)
                {
                    for(int i=0;i<shouldBeD.Count;i++)
                    {
                        if (t >= countEmp) break;
                        if (main[shouldBeD[i]].Can(Done) == false) { Emp[t++] += main[shouldBeD[i]].th; doneInThisStep.Add(main[shouldBeD[i]].th); shouldBeD.RemoveAt(i); }
                    }
                }
                if(t<countEmp)
                for(int j = t; j< countEmp&&stop<main.Count; j++)
                {
                    while (main[stop].Can(Done)) shouldBeD.Add(stop++);
                    Emp[j] += main[stop].th;
                    doneInThisStep.Add(main[stop++].th);
                }
                foreach(string s in doneInThisStep)
                {
                    Done.Add(s);
                }
            }
            foreach(string s in Emp)
            {
                for (int i = 0; i < s.Length - 1; i++)
                    Console.Write("{0,3}", s[i]);
                Console.WriteLine("{0,3}", s[s.Length - 1]);
            }

        }
        static void Fill(ref List<Class1> main,string name,int c)
        {
            for (int i = 0; i < main.Count; i++)
            {
                if (main[i].th == name) if (main[i].deep < c)
                    {
                        main[i].deep = c++;
                        foreach (string s in main[i].into)
                            Fill(ref main, s, c);
                    }
            }
        }
    }
}
