using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany
{

    abstract class WaterTransport : Transport
    {
        public new static readonly string TypeName = "Водный";

        public WaterTransport(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount) : base(brand, speed, carrying, personalCount, passangerCount)
        {
        }
    }

    class Liner: WaterTransport
    {
        public Liner(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount) : base(brand, speed, carrying, personalCount, passangerCount)
        {
        }

        public new static readonly string Name = "Лайнер";
    }

    class Tanker : WaterTransport
    {
        public Tanker(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount) : base(brand, speed, carrying, personalCount, passangerCount)
        {
        }

        public new static readonly string Name = "Танкер";
    }


    class Boat : WaterTransport
    {
        public Boat(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount) : base(brand, speed, carrying, personalCount, passangerCount)
        {
        }

        public new static readonly string Name = "Лодка";
    }


    class Cutter : WaterTransport
    {
        public Cutter(string brand, ulong speed, ulong carrying, int personalCount, int passangerCount) : base(brand, speed, carrying, personalCount, passangerCount)
        {
        }

        public new static readonly string Name = "Катер";
    }
}
