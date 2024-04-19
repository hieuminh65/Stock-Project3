using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    /// <summary>
    /// Internal class for the Doji recognizer
    /// </summary>
    internal class Recognizer_Doji: Recognizer
    {   
        /// <summary>
        /// Constructor for the Doji recognizer
        /// </summary>
        /// <param name="patternName"></param>
        /// <param name="patternLength"></param>
        public Recognizer_Doji(string patternName, int patternLength) : base("Doji", 1)
        {

        }

        /// <summary>
        /// Recognize the Doji pattern
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            // Get the smart candle stick object
            smartCandleStick smartCandleStick = data[index];
            // Check if the pattern existed
            bool existed = smartCandleStick.Patterns.TryGetValue("Doji", out bool value);
            // If the pattern existed, return the value
            if (existed)
            {
                // Return the value
                return true;
            }
            else
            {   
                // If the body range is less than 5% of the open price, then it is a Doji pattern
                if (smartCandleStick.bodyRange < smartCandleStick.open * 0.05M)
                {
                    // Set the pattern to true and add it to the dictionary
                    smartCandleStick.Patterns["Doji"] = true;
                    return true;
                }
            }
            // Set the pattern to false if this is not a Doji pattern and add it to the dictionary
            smartCandleStick.Patterns["Doji"] = false;
            return false;
        }
    }
}
