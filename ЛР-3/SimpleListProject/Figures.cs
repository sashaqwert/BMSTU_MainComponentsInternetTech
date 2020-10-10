using System;

/*
 * Копия файла из проекта LAB_3
 */

namespace LAB_3
{

    public interface IPrint
    {
        void Print();
    }

    public abstract class Figure : IComparable
    {
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Figure f = obj as Figure;
            double a = ploshad();
            double b = f.ploshad();
            return a.CompareTo(b);
        }

        public abstract double ploshad();
    }

    public class Rectangle : Figure, IPrint //Прямоугольник
    {
        protected double a, b;

        public Rectangle(double A, double B)
        {
            a = A;
            b = B;
        }

        public override double ploshad()
        {
            return a * b;
        }

        public override string ToString()
        {
            string result = "";
            result += "Длинна = ";
            result += a.ToString() + " \n";
            result += "Ширина = ";
            result += b.ToString() + " \n";
            result += "Площадь = ";
            result += ploshad().ToString() + " \n";
            return result;
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }

    public class Square : Rectangle //Квадрат
    {
        public Square(double A) : base(A, A)
        {
        }

        public override string ToString()
        {
            string result = "";
            result += "Сторона = ";
            result += a.ToString() + " \n";
            result += "Площадь = ";
            result += ploshad().ToString() + " \n";
            return result;
        }

        public new void Print() //new убирает предупреждение о скрытии
        {
            Console.WriteLine(ToString());
        }
    }


    public class Round : Figure //Круг
    {
        private double r;

        public Round(double R)
        {
            r = R;
        }

        public override double ploshad()
        {
            return Math.PI * r * r;
        }

        public override string ToString()
        {
            string result = "";
            result += "Радиус = ";
            result += r.ToString() + " \n";
            result += "Площадь = ";
            result += ploshad().ToString() + " \n";
            return result;
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
