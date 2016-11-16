using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneDevice
{
    class GSMCallHistoryTest
    {
        public void GSMCallHistoryTesting()
        {
            // Create an instance of the GSM class.
            GSM testGsm = new GSM("Nokia", "TelerikCorp");

            // Add few calls.
            testGsm.AddCall("9873432142", 53);
            testGsm.AddCall("9811433144", 123);
            testGsm.AddCall("9872411149", 41);

            // Display the information about the calls.
            testGsm.ShowCallHistory();

            // Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
            Console.WriteLine("Total call price: " + testGsm.TotalCallPrice());

            //  Remove the longest call from the history and calculate the total price again.
            testGsm.DeleteCall(2);
            Console.WriteLine("Removed Longest call!");
            Console.WriteLine("Total call price: " + testGsm.TotalCallPrice());

            //// Clear the call history and print it.
            //testGsm.ClearCallHistory();
            //Console.WriteLine("Cleared call history!");
            //testGsm.ShowCallHistory();
        }
    }
}
