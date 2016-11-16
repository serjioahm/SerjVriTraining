using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneDevice
{
    public class Battery
    {
        private string model;
        private uint hoursIdle;
        private uint hoursTalk;
        // 3. Add an enumeration BatteryType(Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.
        // enumumeration for Battery Types - not in a seperate class because only this class uses it
        public enum BatType
        {
            LiIon,
            NiMH,
            NiCd,
            LiPo,
            AlienTech
        }

        //Problem 2. -> constructor
        public Battery(string model, uint hoursIdle, uint hoursTalk, BatType batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        public Battery()
        {
        }

        //Properties
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The battery model can not be null or emtpy.");
                }
                this.model = value;
            }
        }

        public uint HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Idle hours must be a possitive number.");
                }
                this.hoursIdle = value;
            }
        }

        public uint HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Hours of talk time must be a possitive number.");
                }
                this.hoursTalk = value;
            }
        }
        public BatType BatteryType { get; set; }

    }

}
