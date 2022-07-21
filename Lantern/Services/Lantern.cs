using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lantern.Services
{
    public delegate void BatteryOfLanternConsumerEventHandler(object source, EventArgs e, int level);

    class MyLantern
    {
        public event BatteryOfLanternConsumerEventHandler BatteryOfLanternConsumerEvent;

        public MyLantern()
        {
            _battery = new Battery();
            OnePercentConsume = 1000;
            IsConsuming = false;
            isOn = false;
        }

        private Battery _battery;

        public bool isOn { get; private set; }
        public int OnePercentConsume { get; private set; }
        public bool IsConsuming { get; private set; }
        private void _onConsumerBattery (object source, EventArgs e, int level)
        {
            BatteryOfLanternConsumerEvent?.Invoke(this, new EventArgs(), level);
        }
        public void TurnOn()
        {
            isOn = true;

            if (_battery.Level < 1)
            {
                return;
            }

            IsConsuming = true;

            Consuming();

            return;
        }
        public void TurnOff()
        {
            isOn = false;
            IsConsuming = false;
        }
        public async void Consuming()
        {
            if (!IsConsuming)
            {
                return;
            }

            while (_battery.Level > 0)
            {
                await Task.Delay(OnePercentConsume);
                _battery.Level--;

                BatteryOfLanternConsumerEvent?.Invoke(this, new EventArgs(), _battery.Level);

                if (!IsConsuming)
                {
                    break;
                }
            }

            if(_battery.Level == 0)
            {
                IsConsuming = false;
                isOn = false;
            }

            return ;
        }
        public int GetLevel()
        {
            return _battery.Level;
        }
        public void Recharge()
        {
            if(!isOn || _battery.Level == 0)
            {
                _battery.Recharge();

                BatteryOfLanternConsumerEvent?.Invoke(this, new EventArgs(), 100);
            }

            return;
        }
    }
}
