using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyExtensions
{
    public static class StringExtensions
    {
        public static StringBuilder Substring(this StringBuilder text, int start, int length)
        {
            StringBuilder result = new StringBuilder();

            for (int i = start; i < start + length; i++)
            {
                result.Append(text[i]);
            }
            return result;
        }

    }
}
