using System;

namespace TransportCompany
{
    public abstract class GroundTransport : Transport
    {
        public GroundTransport(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount) : base(brand, speed, carrying, personalCount, passangerCount)
        {
        }

        public new static readonly string TypeName = "Наземный";
    }

    class Train : GroundTransport
    {
        public Train(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount) : base(brand, speed, carrying, personalCount, passangerCount)
        {
        }

        public new static readonly string Name = "Поезд";
    }

    class Car : GroundTransport
    {
        public Car(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount) : base(brand, speed, carrying, personalCount, passangerCount)
        {
        }

        public new static readonly string Name = "Легковой автомобиль";
    }

    class Bicycle : GroundTransport
    {
        public new static readonly string Name = "Велосипед";

        public Bicycle(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount) : base(brand, speed, carrying, personalCount, passangerCount)
        {
        }
    }

    class Bike : GroundTransport
    {
        public new static readonly string Name = "Мотоцикл";

        public Bike(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount) : base(brand, speed, carrying, personalCount, passangerCount)
        {
        }
    }


    class Truck : GroundTransport
    {
        public new static readonly string Name = "Грузовик";

        public Truck(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount) : base(brand, speed, carrying, personalCount, passangerCount)
        {
        }
    }
}
