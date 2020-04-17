using System;
using System.Threading.Tasks;
using System.IO;
namespace Lab7._1
{
    class Program
    {
        public enum Type { И, А, Т }
        struct Telecast
        {
            public string telecast;
            public string key;
            public int top;
            public Type type;
            public void Print()
            {
                Console.WriteLine("{0,-20}{1,-20}{2,-10}{3,-10}", telecast, key, top, type);
            }
        }
        struct Log
        {
            public DateTime time;
            public string name;
            public string operation;
            public void Print()
            {
                Console.WriteLine("{0,-20} - {1,-20} {2,-15}", time, operation, name);
            }
            
        }
        static async Task Main(string[] args)
        {
            Telecast[] table = new Telecast[50];
            Log[] log = new Log[50];
            int l = 0;

            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;
            TimeSpan interval = time2 - time1;

            string PathTextFile = @"C:\Users\alisa\source\repos\Lab6\lab.dat";

            int i = 0;
            using (StreamReader readTextFile = new StreamReader(PathTextFile))
            {

                while (readTextFile.Peek() > -1)
                {
                    string telecast = await readTextFile.ReadLineAsync();
                    string key = await readTextFile.ReadLineAsync();
                    int top = Convert.ToInt32(await readTextFile.ReadLineAsync());
                    string typeText = await readTextFile.ReadLineAsync();
                    Type type;
                    type = Type.А;
                    if (typeText == "A" || typeText == "А")
                    {
                        type = Type.А;
                    }
                    else if (typeText == "И")
                    {
                        type = Type.И;
                    }
                    else if (typeText == "T" || typeText == "Т")
                    {
                        type = Type.Т;
                    }
                    Telecast newTelecast = new Telecast();
                    newTelecast.telecast = telecast;
                    newTelecast.key = key;
                    newTelecast.top = top;
                    newTelecast.type = type;
                    table[i] = newTelecast;
                    i++;
                }
            }



            bool errorOption = true;
            do
            {
                Console.WriteLine("1 - Просмотр таблицы\n2 - Добавить запись\n3 - Удалить запись\n4 - Обновить запись\n5 - Отсортировать записи\n6 - Просмотреть лог\n7 - Выход");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        for (int k = 0; k < i; k++)
                        {
                            table[k].Print();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Введите название передачи");
                        string telecast = Console.ReadLine();
                        Console.WriteLine("Введите имя ведущего");
                        string key = Console.ReadLine();
                        bool errorTop = false;
                        int top = 0;
                        do
                        {
                            Console.WriteLine("Введите рейтинг");
                            try
                            {
                                top = int.Parse(Console.ReadLine());
                                errorTop = false;
                            }
                            catch
                            {
                                Console.WriteLine("Введите верный рейтинг");
                                errorTop = true;
                            }
                        }
                        while (errorTop);
                        Console.WriteLine("Введите тип передачи(И-Игровая, А - Аналитическая, Т - Ток-шоу)");
                        bool errorType = false;
                        Type type = Type.А;
                        do
                        {
                            string s_type = Console.ReadLine();
                            if (s_type == "И")
                            {
                                type = Type.И;
                                errorType = false;
                            }
                            else if (s_type == "Т")
                            {
                                type = Type.Т;
                                errorType = false;
                            }
                            else if (s_type == "А")
                            {
                                type = Type.А;
                                errorType = false;
                            }
                            else
                            {
                                Console.WriteLine("Введите верный тип : А или И или Т");
                                errorType = true;
                            }
                        }
                        while (errorType);
                        Telecast newTelecast = new Telecast();
                        newTelecast.telecast = telecast;
                        newTelecast.key = key;
                        newTelecast.top = top;
                        newTelecast.type = type;
                        table[i] = newTelecast;
                        i++;

                        Log ADD = new Log();
                        ADD.time = DateTime.Now;
                        ADD.operation = "Добавлена запись";
                        ADD.name = telecast;
                        log[l] = ADD;
                        l++;

                        time1 = DateTime.Now;
                        TimeSpan interval2 = time1 - time2;
                        if (interval < interval2)
                        {
                            interval = interval2;
                        }
                        time2 = ADD.time;
                        break;
                    case 3:
                        Console.WriteLine("Введите номер записи, которую нужно удалить");
                        bool errorDelete = false;
                        do
                        {
                            try
                            {
                                int iForDelete = int.Parse(Console.ReadLine());
                                if (iForDelete < table.Length && iForDelete > 0)
                                {
                                    Log DELETE = new Log();
                                    DELETE.time = DateTime.Now;
                                    DELETE.operation = "Запись удалена";
                                    DELETE.name = table[iForDelete - 1].telecast;
                                    log[l] = DELETE;
                                    l++;
                                    for (int k = iForDelete - 1; k < table.Length - 1; k++)
                                    {
                                        table[k] = table[k + 1];
                                    }
                                    i--;
                                    interval2 = time1 - time2;
                                    if (interval < interval2)
                                    {
                                        interval = interval2;
                                    }
                                    time2 = DELETE.time;
                                    errorDelete = false;
                                }
                                else
                                {
                                    Console.WriteLine("Введите верный номер строки");
                                    errorDelete = true;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Введите верный номер строки");
                                errorDelete = true;
                            }
                        }
                        while (errorDelete);
                        break;
                    case 4:
                        Console.WriteLine("Введите номер строки для обновления");
                        bool errorEdit = false;
                        int iForEdit = 0;
                        do
                        {
                            try
                            {
                                iForEdit = int.Parse(Console.ReadLine());
                                if (iForEdit < table.Length && iForEdit > 0)
                                {
                                    errorEdit = false;
                                }
                                else
                                {
                                    Console.WriteLine("Введите верный номер строки");
                                    errorEdit = true;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Введите верный номер строки");
                                errorEdit = true;
                            }
                        }
                        while (errorEdit);
                        Console.WriteLine("Введите название передачи");
                        string oldTelecast = Console.ReadLine();
                        Console.WriteLine("Введите имя ведущего");
                        string oldKey = Console.ReadLine();
                        int oldTop = 0;
                        do
                        {
                            Console.WriteLine("Введите рейтинг");
                            try
                            {
                                oldTop = int.Parse(Console.ReadLine());
                                errorTop = false;
                            }
                            catch
                            {
                                Console.WriteLine("Введите верный рейтинг");
                                errorTop = true;
                            }
                        }
                        while (errorTop);
                        Console.WriteLine("Введите тип передачи(И-Игровая, А - Аналитическая, Т - Ток-шоу)");
                        errorType = false;
                        Type oldType = Type.А;
                        do
                        {
                            string s_type = Console.ReadLine();
                            if (s_type == "И")
                            {
                                oldType = Type.И;
                                errorType = false;
                            }
                            else if (s_type == "Т")
                            {
                                oldType = Type.Т;
                                errorType = false;
                            }
                            else if (s_type == "А")
                            {
                                oldType = Type.А;
                                errorType = false;
                            }
                            else
                            {
                                Console.WriteLine("Введите верный тип : А или И или Т");
                                errorType = true;
                            }
                        }
                        while (errorType);
                        Telecast EditTelecast = new Telecast();
                        EditTelecast.telecast = oldTelecast;
                        EditTelecast.key = oldKey;
                        EditTelecast.top = oldTop;
                        EditTelecast.type = oldType;
                        table[iForEdit - 1] = EditTelecast;


                        Log UPDATE = new Log();
                        UPDATE.time = DateTime.Now;
                        UPDATE.operation = "Измненена запись";
                        UPDATE.name = oldTelecast;
                        log[l] = UPDATE;
                        l++;

                        time1 = UPDATE.time;
                        interval2 = time1 - time2;
                        if (interval < interval2)
                        {
                            interval = interval2;
                        }
                        time2 = UPDATE.time;
                        break;
                    case 5:
                        for (int t = 1; t < i; t++)
                        {
                            for (int h = t; h > 0 && table[h - 1].top > table[h].top; h--)
                            {
                                table[49] = table[h - 1];
                                table[h - 1] = table[h];
                                table[h] = table[49];

                            }
                        }
                        
                        break;
                    case 6:
                        for (int k = 0; k < l; k++)
                        {
                            log[k].Print();
                        }
                        Console.WriteLine();
                        Console.WriteLine("{0} - Самый долгий период бездействия пользователя", interval);
                        break;
                    case 7:
                        errorOption = false;
                        using (StreamWriter sw = new StreamWriter(PathTextFile, false))
                        {
                            for (int r = 0; r < i; r++)
                            {
                                await sw.WriteLineAsync(table[r].telecast + "\n" + table[r].key + "\n" + table[r].top + "\n" + table[r].type);
                            }
                            sw.Close();
                        }
                        break;
                    default:
                        Console.WriteLine("Введите верную операцию");
                        errorOption = true;
                        break;
                }

            }
            while (errorOption);
        }
    }
}

