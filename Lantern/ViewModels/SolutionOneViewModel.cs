using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using System.Runtime.CompilerServices;

using Lantern.Helpers;
using Lantern.Services;

namespace Lantern.ViewModels
{
    class SolutionOneViewModel : BaseViewModel
    {
        public SolutionOneViewModel()
        {
            Level = 100;
            LanternLight = "Black";
            CheckedOnOffLantern = false;

            _lantern = new MyLantern();
            _lantern.BatteryOfLanternConsumerEvent += new BatteryOfLanternConsumerEventHandler(_onBatteryOfLanternConsumer);
        }

        private MyLantern _lantern;

        private bool _CheckedOnOffLantern;
        public bool CheckedOnOffLantern
        {
            get { return _CheckedOnOffLantern; }
            set
            {
                _CheckedOnOffLantern = value;
                OnPropertyChanged("CheckedOnOffLantern");
            }
        }

        private int _Level;
        public int Level
        {
            get { return _Level; }
            set
            {
                _Level = value;
                OnPropertyChanged("Level");
            }
        }

        private string _LanternLight;
        public string LanternLight
        {
            get { return _LanternLight; }
            set
            {
                _LanternLight = value;
                OnPropertyChanged("LanternLight");
            }
        }
        private void _onBatteryOfLanternConsumer(object source, EventArgs e, int level)
        {
            Level = level;

            if(level == 0)
            {
                _lantern.TurnOff();
                LanternLight = "Black";
                CheckedOnOffLantern = false;
            }
        }

        private ICommand lanternOnOffCommand;
        public ICommand LanternOnOffCommand
        {
            get
            {
                if (lanternOnOffCommand == null)
                    lanternOnOffCommand = new RelayCommand(p => onLanternOnOffCommand());
                return lanternOnOffCommand;
            }
        }

        private void onLanternOnOffCommand()
        {
            if(LanternLight == "Black")
            {
                _lantern.TurnOn();
                CheckedOnOffLantern = true;
                LanternLight = "Yellow";
            } 
            else
            {
                _lantern.TurnOff();
                LanternLight = "Black";
                CheckedOnOffLantern = false;
            }
        }

        private ICommand changeBatteryCommand;
        public ICommand ChangeBatteryCommand
        {
            get
            {
                if (changeBatteryCommand == null)
                    changeBatteryCommand = new RelayCommand(p => onChangeBatteryCommand());
                return changeBatteryCommand;
            }
        }

        private void onChangeBatteryCommand()
        {;
            _lantern.Recharge();
        }
    }
}
