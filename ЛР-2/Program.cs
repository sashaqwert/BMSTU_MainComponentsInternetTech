using System;

namespace LAB_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Прямоугольник --------\n");
            Rectangle r = new Rectangle(1, 2);
            //Console.WriteLine(r);
            r.Print();
            Console.WriteLine("Квадрат --------\n");
            Square s = new Square(1);
            //Console.WriteLine(s);
            s.Print();
            Console.WriteLine("Круг --------\n");
            Round o = new Round(1);
            //Console.WriteLine(o);
            o.Print();
        }
    }
}
