using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lantern.Services
{
    public delegate void BatteryConsumerEventHandler(object source, EventArgs e, int level);
    class Battery
    {
        public Battery()
        {
            Level = 100;
        }
        public int Level { get; set; }

        public void Recharge()
        {
            Level = 100;
        }

    }
}
