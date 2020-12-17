using System;
using System.Linq;
using System.Collections.Generic;

namespace HMW
{
    public class Worker
    {
        public int ID;
        public string LastName;
        public int OtdelID;

        public Worker(int id, string lastName, int otdelID)
        {
            this.ID = id;
            this.LastName = lastName;
            this.OtdelID = otdelID;
        }

        public override string ToString()
        {
            return $"(ID = {ID}; LastName = {LastName}; OtdelID = {OtdelID})";
        }
    }

    public class Otdel
    {
        public int ID;
        public string Name;

        public Otdel(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"(ID = {ID}; Name = {Name})";
        }
    }

    public class MkM_Link
    {
        public int WorkerID;
        public int OtdelID;

        public MkM_Link(int workerID, int OtdelID) => (WorkerID, OtdelID) = (workerID, OtdelID);
    }

    public class Program
    {
        static List<Worker> list_worker = new List<Worker>()
        {
            new Worker(0, "Аникеев", 0),
            new Worker(1, "Архангельский", 0),
            new Worker(2, "Иванов", 0),
            new Worker(3, "Петров", 1),
            new Worker(4, "Сидоров", 1)
        };

        static List<Otdel> list_otdel = new List<Otdel>()
        {
            new Otdel(0, "Главного механника"),
            new Otdel(1, "Художественный"),
            new Otdel(2, "Законодательный")
        };

        static readonly List<MkM_Link> list_MkM = new List<MkM_Link>()
        {
            new MkM_Link(0, 1),
            new MkM_Link(0, 0),
            new MkM_Link(1, 1),
            new MkM_Link(2, 0),
            new MkM_Link(2, 1),
            new MkM_Link(3, 0),
            new MkM_Link(4, 1)
        };

        static void sort_by_otdel()
        {
            Console.WriteLine("Cписок всех сотрудников и отделов, отсортированный по отделам:");
            var res_otdel = from otdel in list_otdel orderby otdel.ID ascending select otdel;

            foreach (var otdel in res_otdel)
            {
                Console.WriteLine("Отдел " + otdel);

                var workers = from worker in list_worker where worker.OtdelID == otdel.ID select worker;

                foreach (var worker in workers)
                    Console.WriteLine("\t" + worker);
            }
        }

        static void Worker_LastName_FirstChar(char firstChar)
        {
            Console.WriteLine($"Список всех сотрудников, фамилия которых начинается на: {firstChar}");

            var workers = from worker in list_worker where worker.LastName[0] == firstChar select worker;

            foreach (var worker in workers)
                Console.WriteLine("\t" + worker);
        }

        static void Otdels_workersCount()
        {
            Console.WriteLine("Список всех отделов и количество сотрудников в каждом отделе");
            foreach (var otdel in list_otdel)
            {
                Console.Write("\t" + otdel + " : ");

                var workers = from worker in list_worker where worker.OtdelID == otdel.ID select worker;
                Console.WriteLine(workers.Count());
            }
        }

        static void Otdels_allWorkers_beginChar(char firstChar)
        {
            Console.WriteLine($"Cписок отделов, в которых у всех сотрудников фамилия начинается с буквы {firstChar}");
            foreach (var otdel in list_otdel)
            {
                var workers = from worker in list_worker where worker.OtdelID == otdel.ID select worker;
                if (workers.All(worker => worker.LastName[0] == firstChar))
                    Console.WriteLine("\t" + otdel);
            }
        }
        static void Otdels_OnePlus_FirstChar(char firstChar)
        {
            Console.WriteLine($"Cписок отделов, в которых хотя бы у одного сотрудника фамилия начинается с буквы {firstChar}");
            foreach (var otdel in list_otdel)
            {
                var workers = from worker in list_worker where worker.OtdelID == otdel.ID select worker;
                if (workers.Any(worker => worker.LastName[0] == firstChar))
                    Console.WriteLine($"\t{otdel}");
            }
        }

        static void FullListMkM()
        {
            Console.WriteLine("Список всех отделов и список сотрудников в каждом отделе (связь много-ко-многим)");
            foreach (var otdel in list_otdel)
            {
                Console.WriteLine($"\t{otdel}:");

                var workers = from worker in list_MkM
                              from worker_MkM in list_worker
                              where worker.OtdelID == otdel.ID && worker.WorkerID == worker_MkM.ID
                              select worker_MkM;

                foreach (var worker in workers)
                    Console.WriteLine($"\t\t{worker}");
            }
        }

        private static void Otdel_workersCount_MkM()
        {
            Console.WriteLine("Список всех отделов и количество сотрудников в каждом отделе (связь много-ко-многим)");
            foreach (var otdel in list_otdel)
            {
                Console.Write("\t" + otdel + ": ");

                var workers = from worker_MkM in list_MkM
                              from worker in list_worker
                              where worker_MkM.OtdelID == otdel.ID && worker_MkM.WorkerID == worker.ID
                              select worker;

                Console.WriteLine(workers.Count());
            }
        }

        public static void Main()
        {
            Console.WriteLine("Чиварзин А. Е. ИУ5Ц-52Б\n");

            sort_by_otdel();
            Console.WriteLine();

            Worker_LastName_FirstChar('А');
            Console.WriteLine();

            Otdels_workersCount();
            Console.WriteLine();

            Otdels_allWorkers_beginChar('А');
            Console.WriteLine();
            
            Otdels_OnePlus_FirstChar('А');
            Console.WriteLine("---------------------------------------------------------------------------------------");

            FullListMkM();
            Console.WriteLine();

            Otdel_workersCount_MkM();
        }
    }
}