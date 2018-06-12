using System;

namespace TransportCompany
{
    public abstract class Transport
    {
        public ulong Speed { get; set; }
        public ulong Carrying { get; set; }
        public int PersonalCount { get; set; }
        public int PassengerCount { get; set; }
        public string Brand { get; set; }

        public Transport(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount)
        {
            Brand = brand;
            Speed = speed;
            Carrying = carrying;
            if (personalCount < 1)
                throw new Exception("Слишком мало персонала!");
            if (passangerCount < 0)
                throw new Exception("Отрицательное кол-во пассажиров!");

            PersonalCount = personalCount;
            PassengerCount = passangerCount;
        }
        public override string ToString()
        {
            return String.Format("Марка: {0}\nСкорость: {1}\nГрузоподъемность: {2}\nКоличество персонала: {3}\nКоличество пассажиров: {4}\n",
                Brand, Speed, Carrying, PersonalCount, PassengerCount);
        }

        public void ShowInfo()
        {
            Console.WriteLine(ToString());
        }

        public void Move(string items, ulong km, ulong kg)
        {
            if (kg < 0)
                Console.WriteLine("Отрицательная масса груза, неверный ввод");
            else
                if (kg > Carrying)
                Console.WriteLine("Слишком тяжелый груз для данного транспорта");
            else
                Console.WriteLine("{0} перевез {1} на расстояние {2} в течении {3} часов",
                    ShortName(), items, km, (double)km / Speed);
        }
        
        // и.в. "наземный", "воздушный и т.д.
        public static readonly string TypeName = "Undefined";
        // название типа транспорта для пользователя
        public static readonly string Name = "Undefined";

        //краткое обозначение транспорта
        public string ShortName()
        {
            Type t = this.GetType();
            return String.Format("{0}({1}) марки {2}", t.GetField("Name").GetValue(null).ToString(),
                t.BaseType.GetField("TypeName").GetValue(null).ToString(), Brand);
        }
    }
}
