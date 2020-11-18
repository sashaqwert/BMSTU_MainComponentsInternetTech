using System;

namespace LAB_6
{
    class Program
    {
        delegate bool CorrectObject(int ID, double dID);

        static bool oEquals(int i1, double d2)
        {
            return Convert.ToDouble(i1) == d2;
        }

        static void test(int i1, double d1, string str, CorrectObject co)
        {
            Console.WriteLine(str + "//// Сравниваем числя");
            bool coResult = co(i1, d1);

            if (coResult)
                Console.WriteLine("Равны");
            else
                Console.WriteLine("НЕ равны");

        }

        ////////////////////////////////////////////
        

        

        static void Main(string[] args)
        {
            Console.WriteLine("Чиварзин А. Е. ИУ5Ц-52Б\n");

            Console.WriteLine("Через метод");
            test(1, 1.0, "12345", oEquals);

            Console.WriteLine("\nЛямбда-выражение");
            CorrectObject coL = (int i, double d) =>
            {
                bool res = i + 100 == d - 200;
                return res;
            };
            Console.WriteLine(coL(-100, 200.0));
        }
    }
}
