using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneDevice
{
    public class Demo
    {
        public int State1 { get; set; }
        public string State2 { get; set; }

        public Demo()
        {

        }

        public Demo(int st1, string st2)
        {
            this.State1 = st1;
            this.State2 = st2;
        }
    }
}
