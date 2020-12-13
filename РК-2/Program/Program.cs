using System;
using System.IO;
using System.Xml.Serialization;

namespace RK_2
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLatrTest obj = new XMLatrTest();
            obj.var1 = 12345;
            obj.var2 = 12.34;
            obj.var3 = true;
            obj.var4 = "Это самая обычная строка!";
            // Текущий каталог
            string currentPath = "A:\\sasha\\YandexDisk\\YandexDisk\\МГТУ\\5-й семестр\\Основные компоненты интернет-технологий\\РК\\2";

            //+++++++++++++++++
            //сериализация //+++++++++++++++++
            Console.WriteLine("До сериализации:");
            Console.WriteLine(obj);
            //Формирование имени файла
            string fileXml2Name = Path.Combine(currentPath, "file2atr.xml");
            //При сериализации файл необходимо открыть с использованием потоков
            Stream TestFileStream1Xml2 = File.Create(fileXml2Name);
            //Создание объекта класса сериализации
            XmlSerializer serializerXml2 = new XmlSerializer(typeof(XMLatrTest));
            //Cериализация объекта в файл
            serializerXml2.Serialize(TestFileStream1Xml2, obj);
            //Закрытие потока
            TestFileStream1Xml2.Close();
            //+++++++++++++++++
            //десериализация //+++++++++++++++++
            //Открытие файла в виде потока на чтение
            Stream TestFileStream2Xml2 = File.OpenRead(fileXml2Name);
            //Десериализация объекта
            XMLatrTest dataXml2Out = (XMLatrTest)serializerXml2.Deserialize(TestFileStream2Xml2);
            //Закрытие потока
            TestFileStream2Xml2.Close();
            Console.WriteLine("После десериализации:");
            Console.WriteLine(dataXml2Out);
        }
    }
}
