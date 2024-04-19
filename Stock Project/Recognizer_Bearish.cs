using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    /// <summary>
    /// Internal class for the Bearish recognizer
    /// </summary>
    internal class Recognizer_Bearish : Recognizer
    {
        /// <summary>
        /// Constructor for the Bearish recognizer
        /// </summary>
        /// <param name="patternName"></param>
        /// <param name="patternLength"></param>
        public Recognizer_Bearish(string patternName, int patternLength) : base("Bearish", 1)
        {

        }

        /// <summary>
        /// Recognize the Bearish pattern
        /// </summary>
        /// <param name="data">The list of smart Candle Stick</param>
        /// <param name="index">The index choosen to recognize</param>
        /// <returns></returns>
        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            // Get the smart candle stick object
            smartCandleStick smartCandleStick = data[index];
            // Check if the pattern existed
            bool existed = smartCandleStick.Patterns.TryGetValue("Bearish", out bool value);
            // If the pattern existed, return the value
            if (existed)
            {
                return true;
            }
            else
            {   // If the open price is greater than the close price, then it is a bearish pattern
                if (smartCandleStick.open > smartCandleStick.close)
                {
                    // Set the pattern to true if this is a bearish pattern
                    if (smartCandleStick.open > smartCandleStick.close)
                    {
                        // Set the pattern to true
                        smartCandleStick.Patterns["Bearish"] = true;
                        return true;
                    }
                }
                // Set the pattern to false if this is not a bearish pattern
                smartCandleStick.Patterns["Bearish"] = false;   
                return false;

            }
        }
    }
}
