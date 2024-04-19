using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    /// <summary>
    /// Internal class for the Bullish recognizer
    /// </summary>
    internal class Recognizer_Bullish : Recognizer
    {
        /// <summary>
        /// Constructor for the Bullish recognizer
        /// </summary>
        /// <param name="patternName"></param>
        /// <param name="patternLength"></param>
        public Recognizer_Bullish(string patternName, int patternLength) : base("Bullish", 1)
        {

        }

        /// <summary>
        /// Recognize the Bullish pattern
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            // Get the smart candle stick object
            smartCandleStick smartCandleStick = data[index];
            // Check if the pattern existed
            bool existed = smartCandleStick.Patterns.TryGetValue("Bullish", out bool value);
            // If the pattern existed, return the value
            if (existed)
            {   
                // Return the value
                return true;
            }
            else
            {   
                // If the open price is less than the close price, then it is a bullish pattern
                if (smartCandleStick.open < smartCandleStick.close)
                {
                    // Set the pattern to true if this is a bullish pattern
                    if (smartCandleStick.open < smartCandleStick.close)
                    {   
                        // Set the pattern to true and add it to the dictionary
                        smartCandleStick.Patterns["Bullish"] = true;
                        return true;
                    }
                }
                // Set the pattern to false if this is not a bullish pattern and add it to the dictionary
                smartCandleStick.Patterns["Bullish"] = false;   
                return false;

            }
        }
    }
}
