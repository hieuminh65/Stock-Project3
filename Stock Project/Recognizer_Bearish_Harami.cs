using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    /// <summary>
    /// Internal class for the Bearish Harami recognizer
    /// </summary>
    internal class Recognizer_Bearish_Harami : Recognizer
    {
        /// <summary>
        /// Constructor for the Bearish Harami recognizer
        /// </summary>
        /// <param name="patternName"></param>
        /// <param name="patternLength"></param>
        public Recognizer_Bearish_Harami(string patternName, int patternLength) : base("Bearish Harami", 2)
        {

        }

        /// <summary>
        /// Recognize the Bearish Harami pattern
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            // Get the smart candle stick object
            smartCandleStick smartCandleStick = data[index];
            // Check if the pattern existed
            bool existed = smartCandleStick.Patterns.TryGetValue("Bearish Harami", out bool value);
            // If the pattern does not exist, then check if it is a Bearish Harami pattern
            if (!existed)
            {   
                // If the index is less than 1, it cannot form a Bearish Harami pattern
                if (index - 1 < 0)
                {   
                    // Set the pattern to false and add it to the dictionary
                    value = false;
                    smartCandleStick.Patterns["Bearish Harami"] = false;
                    return value;
                }
                else
                {   
                    // Get the previous candle stick object
                    smartCandleStick previousCandleStick = data[index - 1];
                    // If the previous candle stick is bullish and the current candle stick is bearish, then it is a Bearish Harami pattern
                    if ((smartCandleStick.isBearishcs() == true) && (previousCandleStick.isBullishcs() == true))
                    {   
                        // If the open price of the current candle stick is greater than the close price of the previous candle stick and the close price of the current candle stick is less than the open price of the previous candle stick, then it is a Bearish Harami pattern
                        if ((previousCandleStick.close > previousCandleStick.close) && (smartCandleStick.close < smartCandleStick.open))
                        {
                            // Set the pattern to true and add it to the dictionary
                            value = true;
                            smartCandleStick.Patterns["Bearish Harami"] = true;
                            return value;
                        }
                        else
                        {   
                            // Set the pattern to false and add it to the dictionary if it is not a Bearish Harami pattern
                            value = false;
                            smartCandleStick.Patterns["Bearish Harami"] = false;
                            return value;
                        }
                    } else
                    {   
                        // Set the pattern to false and add it to the dictionary if it is not a Bearish Harami pattern
                        value = false;
                        smartCandleStick.Patterns["Bearish Harami"] = false;
                        return value;
                    }
                }
            }
            else
            {
                // If the pattern already existed, then return the value
                return value;
            }
        }   
    }       
}
