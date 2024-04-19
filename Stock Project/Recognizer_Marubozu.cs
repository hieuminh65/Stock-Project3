using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    /// <summary>
    /// Internal class for the Marubozu recognizer
    /// </summary>
    internal class Recognizer_Marubozu : Recognizer
    {
        /// <summary>
        /// Constructor for the Marubozu recognizer
        /// </summary>
        /// <param name="patternName"></param>
        /// <param name="patternLength"></param>
        public Recognizer_Marubozu(string patternName, int patternLength) : base("Marubozu", 1)
        {

        }

        /// <summary>
        /// Recognize the Marubozu pattern
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {   
            // Get the smart candle stick object
            smartCandleStick smartCandleStick = data[index];
            // Check if the pattern existed
            bool existed = smartCandleStick.Patterns.TryGetValue("Marubozu", out bool value);
            // If the pattern existed, return the value
            if (existed)
            {   
                // Return the value
                return true;
            }
            else
            {   
                // Using the isMarubozucs method to check if this is a Marubozu pattern
                if (smartCandleStick.isMarubozucs())
                {
                    // Set the pattern to true and add it to the dictionary
                    smartCandleStick.Patterns["Marobozu"] = true;
                    return true;
                }
            }
            // Set the pattern to false if this is not a Marubozu pattern and add it to the dictionary
            smartCandleStick.Patterns["Marobozu"] = false;
            return false;
        }
    }
}
