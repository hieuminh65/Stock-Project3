using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    /// <summary>
    /// Internal class for the Valley recognizer
    /// </summary>
    internal class Recognizer_Valley : Recognizer
    {
        /// <summary>
        /// Constructor for the Valley recognizer
        /// </summary>
        /// <param name="patternName"></param>
        /// <param name="patternLength"></param>
        public Recognizer_Valley(string patternName, int patternLength) : base("Valley", 3)
        {

        }

        /// <summary>
        /// Recognize the Valley pattern
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            // Get the smart candle stick object
            smartCandleStick smartCandleStick = data[index];
            // Check if the pattern existed
            bool existed = smartCandleStick.Patterns.TryGetValue("Valley", out bool value);
            // If the pattern existed, return the value
            if (!existed)
            {   
                // Check if the pattern is a valley pattern, if the index is less than 0 or greater than the data count, return false
                if ((index - 1) < 0 || (index + 1) >= data.Count)
                {
                    // Set the pattern to false and add it to the dictionary
                    smartCandleStick.Patterns["Valley"] = false;
                    return false;
                } else
                {
                    // Get the previous and next candle stick object
                    smartCandleStick previousCandleStick = data[index - 1];
                    smartCandleStick nextCandleStick = data[index + 1];
                    // If the low of the current candle stick is less than the low of the previous and next candle stick, then it is a valley
                    if (smartCandleStick.low < previousCandleStick.low && smartCandleStick.low < nextCandleStick.low)
                    {
                        // Set the pattern to true and add it to the dictionary
                        smartCandleStick.Patterns["Valley"] = true;
                        return true;
                    } else
                    {
                        // Set the pattern to false and add it to the dictionary
                        smartCandleStick.Patterns["Valley"] = false;
                        return false;
                    }
                }
                } 
            else
            {
                // If the pattern already existed, then return the value
                return true;
            }
        }   
    }
}
