using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    /// <summary>
    /// Internal class for the Neutral recognizer
    /// </summary>
    internal class Recognizer_Neutral : Recognizer
    {
        /// <summary>
        /// Constructor for the Neutral recognizer
        /// </summary>
        /// <param name="patternName"></param>
        /// <param name="patternLength"></param>
        public Recognizer_Neutral(string patternName, int patternLength) : base("Neutral", 1)
        {

        }

        /// <summary>
        /// Recognize the Neutral pattern
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {   
            // Get the smart candle stick object
            smartCandleStick smartCandleStick = data[index];
            // Check if the pattern existed
            bool existed = smartCandleStick.Patterns.TryGetValue("Neutral", out bool value);
            // If the pattern existed, return the value
            if (existed)
            {   
                // Return the value
                return true;
            }
            else
            {   
                // Using the isNeutralcs method to check if this is a Neutral pattern
                if (smartCandleStick.isNeutralcs())
                {
                    // Set the pattern to true and add it to the dictionary
                    smartCandleStick.Patterns["Neutral"] = true;
                    return true;
                }
            }
            // Set the pattern to false if this is not a Neutral pattern and add it to the dictionary
            smartCandleStick.Patterns["Neutral"] = false;
            return false;
        }
    }
}
