using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{   
    /// <summary>
    /// Internal class for the GraveStoneDoji recognizer
    /// </summary>
    internal class Recognizer_GraveStone_Doji : Recognizer
    {
        /// <summary>
        /// Constructor for the GraveStoneDoji recognizer
        /// </summary>
        /// <param name="patternName"></param>
        /// <param name="patternLength"></param>
        public Recognizer_GraveStone_Doji(string patternName, int patternLength) : base("GraveStoneDoji", 1)
        {

        }

        /// <summary>
        /// Recognize the GraveStoneDoji pattern
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {   
            // Get the smart candle stick object
            smartCandleStick smartCandleStick = data[index];
            // Check if the pattern existed
            bool existed = smartCandleStick.Patterns.TryGetValue("GraveStoneDoji", out bool value);
            if (existed)
            {   
                // Return the value if the pattern existed
                return true;
            }
            else
            {   
                // Using the isGraveStoneDojics method to check if this is a GraveStoneDoji pattern
                if (smartCandleStick.isGraveStoneDojics())
                {
                    // Set the pattern to true and add it to the dictionary
                    smartCandleStick.Patterns["GraveStoneDoji"] = true;
                    return true;
                }
            }
            // Set the pattern to false if this is not a GraveStoneDoji pattern and add it to the dictionary
            smartCandleStick.Patterns["GraveStoneDoji"] = false;
            return false;
        }
    }
}
