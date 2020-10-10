using LAB_3;
using System;

namespace SimpleListProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!"); Console.WriteLine("Чиварзин А. Е. ИУ5Ц-52Б");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Проект SimpleListProject [3/3]");
            Console.ResetColor();

            SimpleStack<Figure> fList = new SimpleStack<Figure>();
            fList.push(new Rectangle(1.0, 10.0));
            fList.push(new Square(25.0));
            fList.push(new Round(35.5));

            Console.WriteLine("POP ------");
            Console.WriteLine(fList.pop());
            Console.WriteLine("POP ------");
            Console.WriteLine(fList.pop());
            Console.WriteLine("POP ------");
            Console.WriteLine(fList.pop());
        }
    }
}
