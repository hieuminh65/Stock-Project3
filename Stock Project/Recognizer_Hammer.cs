using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    /// <summary>
    /// Internal class for the Hammer recognizer
    /// </summary>
    internal class Recognizer_Hammer : Recognizer
    {   
        /// <summary>
        /// Constructor for the Hammer recognizer
        /// </summary>
        /// <param name="patternName"></param>
        /// <param name="patternLength"></param>
        public Recognizer_Hammer(string patternName, int patternLength) : base("Hammer", 1)
        {

        }

        /// <summary>
        /// Recognize the Hammer pattern
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {   
            // Get the smart candle stick object
            smartCandleStick smartCandleStick = data[index];
            // Check if the pattern existed
            bool existed = smartCandleStick.Patterns.TryGetValue("Hammer", out bool value);
            // If the pattern existed, return the value
            if (existed)
            {   
                // Return the value
                return true;
            }
            else
            {   
                // Using the isHammercs method to check if this is a Hammer pattern
                if (smartCandleStick.isHammercs())
                {   
                    // Set the pattern to true and add it to the dictionary
                    smartCandleStick.Patterns["Hammer"] = true;
                    return true;
                }
            }
            // Set the pattern to false if this is not a Hammer pattern and add it to the dictionary
            smartCandleStick.Patterns["Hammer"] = false;
            return false;
        }
    }
}
