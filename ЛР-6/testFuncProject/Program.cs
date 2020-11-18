using System;

namespace testFuncProject
{
    class Program
    {

        static Func<int, double, bool> funcTest;

        static bool test(int i1, double d1)
        {
            Console.WriteLine("//// Сравниваем числя");
            return i1 == d1;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Через метод");
            funcTest = test;
            if (funcTest(1, 1.0))
                Console.WriteLine("Равны");
            else
                Console.WriteLine("НЕ равны");

            Console.WriteLine("\nЛямбда-выражение");
            funcTest = (int i, double d) =>
            {
                bool res = i + 100 == d - 200;
                return res;
            };

            if (funcTest(1, 1.0))
                Console.WriteLine("Равны");
            else
                Console.WriteLine("НЕ равны");
        }
    }
}
