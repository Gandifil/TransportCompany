using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TransportCompany
{
    class Program
    {
        static List<Transport> transportList = new List<Transport>();
        static Type[] transportTypes;

        static void Create()
        {
            Console.WriteLine("Введите тип транспорта из предложенных:");
            foreach (var t in transportTypes)
            {
                Console.WriteLine(t.GetField("Name").GetValue(null).ToString());
            }

            try
            {
                string answer = Console.ReadLine();

                var target = transportTypes.Where(t => t.Name == answer || t.GetField("Name").GetValue(null).ToString() == answer).First();

                Console.Write("Введите марку: ");
                string brand = Console.ReadLine();

                Console.Write("Грузоподъемность (в кг): ");
                ulong carrying = Convert.ToUInt64(Console.ReadLine());

                Console.WriteLine("Скорость (в км): ");
                ulong speed = Convert.ToUInt64(Console.ReadLine());

                Console.WriteLine("Количество персонала: ");
                int personalCount = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Количество пассажиров: ");
                int passengerCount = Convert.ToInt32(Console.ReadLine());

                Transport item = (Transport)Activator.CreateInstance(target, brand, speed, carrying, personalCount, passengerCount);
                transportList.Add(item);
            }
            catch (Exception m)
            {
                Console.WriteLine("Некорректный ввод!");
                Console.WriteLine(m.ToString());
                Pause();
            }
        }

        static void Show()
        {
            Console.Clear();

            ShowTransportList();

            Console.WriteLine("Введите номер транспорта:");
            try
            {
                int target = Convert.ToInt32(Console.ReadLine());
                transportList[target].ShowInfo();
                Pause();
            }
            catch (Exception m)
            {
                Console.WriteLine("Некорректный ввод!");
                Console.WriteLine(m.ToString());
                Pause();
            }
        }

        static void Move()
        {
            Console.Clear();

            ShowTransportList();

            Console.WriteLine("Введите номер транспорта:");
            try
            {
                int target = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите название груза: ");
                string items = Console.ReadLine();

                Console.WriteLine("Масса груза (в кг): ");
                ulong kg = Convert.ToUInt64(Console.ReadLine());

                Console.WriteLine("Расстояние (в км): ");
                ulong km = Convert.ToUInt64(Console.ReadLine());

                transportList[target].Move(items, km, kg);
                Pause();
            }
            catch (Exception m)
            {
                Console.WriteLine("Некорректный ввод!");
                Console.WriteLine(m.ToString());
                Pause();
            }
        }

        static void ShowTransportList()
        {
            Console.WriteLine("Транспорт в наличии: ");
            int i = 0;
            transportList.ForEach(x => Console.WriteLine("{0}. {1}", i++, x.ShortName()));
            if (i == 0) Console.WriteLine("пусто");
        }

        static void Main(string[] args)
        {
            Init();

            string cmd;
            do
            {
                Console.Clear();
                ShowTransportList();
                Console.WriteLine(@"Набор команд:
создать/create - новый транспорт
показать/show - показать информацию
перевезти/move - перевезти груз
выход/exit - выйти из программы
Введите команду:
");

                cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "create":
                    case "создать":
                        Create();
                        break;
                    case "show":
                    case "показать":
                        Show();
                        break;
                    case "move":
                    case "перевезти":
                        Move();
                        break;
                    default:
                        Console.WriteLine("Нет такой команды");
                        Pause();
                        break;
                }
            } while (cmd != "exit" && cmd != "выход");
        }

        static void Pause()
        {
            Console.WriteLine("(нажмите любую клавишу чтобы продолжить)");
            Console.ReadKey();
        }
        
        static void Init()
        {
            //подготовим список возможных транспортов
            Type parent = typeof(Transport);
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            // это позволит нам при добавлении нового вида транспорта не изменять какой-либо другой код
            transportTypes = types.Where(t => parent.IsAssignableFrom(t) && !t.IsAbstract).ToArray<Type>();
        }
    }
}
