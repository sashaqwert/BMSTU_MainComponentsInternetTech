using System;
using System.Linq;
using System.Reflection;

namespace Part2
{
    class Program
    {
        /// <summary>
        /// Проверка, что у свойства есть атрибут заданного типа
        /// </summary> /// <returns>Значение атрибута</returns>
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false; attribute = null;
            //Поиск атрибутов с заданным типом
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }
            return Result;
        }

        // ////////////////////////////////////////////////////////

        static void Main(string[] args)
        {
            Console.WriteLine("Чиварзин А. Е. ИУ5Ц-52Б\n");

            Rectangle obj = new Rectangle(1, 2);

            Type t = obj.GetType();
            Console.WriteLine("\nИнформация о типе:");
            Console.WriteLine("Тип " + t.FullName + " унаследован от " + t.BaseType.FullName);
            Console.WriteLine("Пространство имен " + t.Namespace);
            Console.WriteLine("Находится в сборке " + t.AssemblyQualifiedName);
            Console.WriteLine("\nКонструкторы:");
            foreach (var x in t.GetConstructors()) { Console.WriteLine(x); }
            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nСвойства:");
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nПоля данных (public):");
            foreach (var x in t.GetFields())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nRectangle реализует IComparable -> " + t.GetInterfaces().Contains(typeof(IComparable)));

            Console.WriteLine("\n========================================\n");
            Console.WriteLine("\nСвойства, помеченные атрибутом:");
            foreach (var x in t.GetProperties())
            {
                object lab6;
                if (GetPropertyAttribute(x, typeof(AttributeC), out lab6))
                {
                    AttributeC attr = lab6 as AttributeC;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }

            Console.WriteLine("\n========================================\n");
            Console.WriteLine("\nВызов метода:");
            //Создание объекта //ForInspection fi = new ForInspection(); //Можно создать объект через рефлексию
            Rectangle fi = (Rectangle)t.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });
            //Параметры вызова метода
            object[] parameters = new object[] { 1, 2 };
            //Вызов метода
            object Result = t.InvokeMember("setAB", BindingFlags.InvokeMethod,null, fi, parameters);
            Console.WriteLine("setAB(1,2)={0}", Result);

        }
    }
}

//Деасемблирование CTRL + ALT + D в режиме отладки