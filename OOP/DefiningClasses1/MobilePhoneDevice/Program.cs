using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneDevice
{
    public class Program
    {
        static void Main(string[] args)
        {
            //GSM gsm = new GSM("model1", "manufacturer1");
            //gsm.AddCall("0897777777", 333);
            //GSMTest newtest = new GSMTest();
            //newtest.GSMTesting();
            GSMCallHistoryTest newcallHistoryTest = new GSMCallHistoryTest();
            newcallHistoryTest.GSMCallHistoryTesting();
        }
    }
}
