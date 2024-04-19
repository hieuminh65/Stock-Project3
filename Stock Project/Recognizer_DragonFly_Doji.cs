using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    /// <summary>
    /// Internal class for the DragonFlyDoji recognizer
    /// </summary>
    internal class Recognizer_DragonFly_Doji : Recognizer
    {
        /// <summary>
        /// Constructor for the DragonFlyDoji recognizer
        /// </summary>
        /// <param name="patternName"></param>
        /// <param name="patternLength"></param>
        public Recognizer_DragonFly_Doji(string patternName, int patternLength) : base("DragonFlyDoji", 1)
        {

        }

        /// <summary>
        /// Recognize the DragonFlyDoji pattern
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {   
            // Get the smart candle stick object
            smartCandleStick smartCandleStick = data[index];
            // Check if the pattern existed
            bool existed = smartCandleStick.Patterns.TryGetValue("DragonFlyDoji", out bool value);
            // If the pattern existed, return the value
            if (existed)
            {   
                // Return the value
                return true;
            }
            else
            {   
                // Using the isDragonFlyDojics method to check if this is a DragonFlyDoji pattern
                if (smartCandleStick.isDragonFlyDojics())
                {
                    // Set the pattern to true and add it to the dictionary
                    smartCandleStick.Patterns["DragonFlyDoji"] = true;
                    return true;
                }
            }
            // Set the pattern to false if this is not a DragonFlyDoji pattern and add it to the dictionary
            smartCandleStick.Patterns["DragonFlyDoji"] = false;
            return false;
        }
    }
}
