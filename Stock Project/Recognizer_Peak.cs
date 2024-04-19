using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    /// <summary>
    /// Internal class for the Peak recognizer
    /// </summary>
    internal class Recognizer_Peak : Recognizer
    {
        /// <summary>
        /// Constructor for the Peak recognizer
        /// </summary>
        /// <param name="patternName"></param>
        /// <param name="patternLength"></param>
        public Recognizer_Peak(string patternName, int patternLength) : base("Peak", 3)
        {

        }

        /// <summary>
        /// Recognize the Peak pattern
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {   
            // Get the smart candle stick object
            smartCandleStick smartCandleStick = data[index];
            // Check if the pattern existed
            bool existed = smartCandleStick.Patterns.TryGetValue("Peak", out bool value);
            if (!existed)
            {   
                // If the index is less than 1 or greater than the length of the data, then it cannot be a peak
                if ((index - 1) < 0 || (index + 1) >= data.Count)
                {
                    // Set the pattern to false and add it to the dictionary
                    smartCandleStick.Patterns["Peak"] = false;
                    return false;
                } else
                {   
                    // Get the previous and next candle stick object
                    smartCandleStick previousCandleStick = data[index - 1];
                    smartCandleStick nextCandleStick = data[index + 1];
                    // If the high of the current candle stick is greater than the high of the previous and next candle stick, then it is a peak
                    if (smartCandleStick.high > previousCandleStick.high && smartCandleStick.high > nextCandleStick.high)
                    {
                        // Set the pattern to true and add it to the dictionary
                        smartCandleStick.Patterns["Peak"] = true;
                        return true;
                    } else
                    {
                        // Set the pattern to false and add it to the dictionary
                        smartCandleStick.Patterns["Peak"] = false;
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
