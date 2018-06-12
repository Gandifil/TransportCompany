using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany
{
    abstract class AirTransport : Transport
    {
        public new static readonly string TypeName = "Воздушный";

        public AirTransport(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount) : base(brand, speed, carrying, personalCount, passangerCount)
        {
        }
    }

    class Helicopter : WaterTransport
    {
        public Helicopter(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount) : base(brand, speed, carrying, personalCount, passangerCount)
        {
        }

        public new static readonly string Name = "Вертолет";
    }

    class Airplane : WaterTransport
    {
        public Airplane(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount) : base(brand, speed, carrying, personalCount, passangerCount)
        {
        }

        public new static readonly string Name = "Самолет";
    }
}
