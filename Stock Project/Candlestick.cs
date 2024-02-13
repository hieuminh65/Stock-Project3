using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Namespace declaration for the stock project
namespace Stock_Project
{
    /// <summary>
    /// Definition of the Candlestick class
    /// </summary>
    internal class Candlestick
    {
        // Public properties to hold the date, open, close, high, low values, and volume for a candlestick
        public DateTime date { get; set; }
        public decimal open { get; set; }
        public decimal close { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public long volume { get; set; }

        /// <summary>
        /// Constructor that takes a string representing a row of stock data
        /// </summary>
        /// <param name="rowOfData">a row of data in the data file</param>
        public Candlestick(string rowOfData)
        {
            // Define separators for splitting the input string
            char[] separator = new char[] { ',', ' ', '"' };
            // Split the input string into substrings using the defined separators
            string[] subs = rowOfData.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            // Extract the date string from the first substring
            string dateString = subs[0];
            // Parse the date string into a DateTime object
            date = DateTime.Parse(dateString);

            // Temporary variable for parsing decimal values
            decimal temp;
            // Try to parse the 'open' price from the second substring
            bool success = decimal.TryParse(subs[1], out temp);
            // If parsing is successful, set 'open' to the parsed value; otherwise, set to 0
            if (success)
            {
                open = temp;
            }
            else
            {
                open = 0;
            }

            // Try to parse the 'high' price from the third substring
            success = decimal.TryParse(subs[2], out temp);
            // If parsing is successful, set 'high' to the parsed value; otherwise, set to 0
            if (success)
            {
                high = temp;
            }
            else
            {
                high = 0;
            }

            // Try to parse the 'low' price from the fourth substring
            success = decimal.TryParse(subs[3], out temp);
            // If parsing is successful, set 'low' to the parsed value; otherwise, set to 0
            if (success)
            {
                low = temp;
            }
            else
            {
                low = 0;
            }

            // Try to parse the 'close' price from the fifth substring
            success = decimal.TryParse(subs[4], out temp);
            // If parsing is successful, set 'close' to the parsed value; otherwise, set to 0
            if (success)
            {
                close = temp;
            }
            else
            {
                close = 0;
            }

            // Temporary variable for parsing volume as ulong before converting to long
            ulong tempVolume;
            // Try to parse the 'volume' from the seventh substring
            success = ulong.TryParse(subs[6], out tempVolume);
            // If parsing is successful, convert and set 'volume' to the parsed value; otherwise, set to 0
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

