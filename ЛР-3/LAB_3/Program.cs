using System;
using System.Collections;
using System.Collections.Generic;

namespace LAB_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Чиварзин А. Е. ИУ5Ц-52Б");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Проект LAB_3 [1/3]");
            Console.ResetColor();

            ArrayList al = new ArrayList();
            al.Add(new Rectangle(1.0, 2.0));
            al.Add(new Square(100.0));
            al.Add(new Round(1.0));
            for (int i = 0; i < al.Count; i++)
            {
                Console.Write("[");
                Console.Write(i);
                Console.WriteLine("] ------------------");
                Console.WriteLine(al[i]);
            }
            al.Sort();
            Console.WriteLine(">>>>>> СОРТИРОВКА <<<<<");
            for (int i = 0; i < al.Count; i++)
            {
                Console.Write("[");
                Console.Write(i);
                Console.WriteLine("] ------------------");
                Console.WriteLine(al[i]);
            }

            Console.WriteLine("### LIST ###");
            List<Figure> l = new List<Figure>();
            l.Add(new Rectangle(1.0, 2.0));
            l.Add(new Square(100.0));
            l.Add(new Round(1.0));
            for (int i = 0; i < l.Count; i++)
            {
                Console.Write("[");
                Console.Write(i);
                Console.WriteLine("] ------------------");
                Console.WriteLine(l[i]);
            }
            l.Sort();
            Console.WriteLine(">>>>>> СОРТИРОВКА <<<<<");
            for (int i = 0; i < l.Count; i++)
            {
                Console.Write("[");
                Console.Write(i);
                Console.WriteLine("] ------------------");
                Console.WriteLine(l[i]);
            }
        }
    }
}
