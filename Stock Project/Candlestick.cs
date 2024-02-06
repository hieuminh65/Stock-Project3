using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Candlestick
    {
        public DateTime date { get; set; }
        public decimal open { get; set; }
        public decimal close { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public long volume { get; set; }


        public Candlestick(string rowOfData)
        {
            char[] separator = new char[] { ',', ' ', '"' };
            string[] subs = rowOfData.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            string dateString = subs[0];

            date = DateTime.Parse(dateString);

            decimal temp;
            bool success = decimal.TryParse(subs[1], out temp);
            if (success)
            {
                open = temp;
            }
            else
            {
                open = 0;
            }

            success = decimal.TryParse(subs[2], out temp);
            if (success)
            {
                high = temp;
            }
            else
            {
                high = 0;
            }

            success = decimal.TryParse(subs[3], out temp);
            if (success)
            {
                low = temp;
            }
            else
            {
                low = 0;
            }

            success = decimal.TryParse(subs[4], out temp);
            if (success)
            {
                close = temp;
            }
            else
            {
                close = 0;
            }

            ulong tempVolume;
            success = ulong.TryParse(subs[6], out tempVolume);
            if (success)
            {
                volume = (long)tempVolume;
            }
            else
            {
                volume = 0;
            }
        }
    }
}
