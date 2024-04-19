using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    /// <summary>
    /// Internal class for the Bullish Engulfing recognizer
    /// </summary>
    internal class Recognizer_Bullish_Engulfing: Recognizer
    {
        /// <summary>
        /// Constructor for the Bullish Engulfing recognizer
        /// </summary>
        /// <param name="patternName"></param>
        /// <param name="patternLength"></param>
        public Recognizer_Bullish_Engulfing(string patternName, int patternLength) : base("Bullish Engulfing", 2)
        {

        }

        /// <summary>
        /// Recognize the Bullish Engulfing pattern
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            // Get the smart candle stick object
            smartCandleStick smartCandleStick = data[index];
            // Check if the pattern existed
            bool existed = smartCandleStick.Patterns.TryGetValue("Bullish Engulfing", out bool value);
            // If the pattern does not exist, then check if it is a Bullish Engulfing pattern
            if (!existed)
            {   
                // If the index is less than 1, it cannot form a Bullish Engulfing pattern
                if (index - 1 < 0)
                {   
                    // Set the pattern to false and add it to the dictionary
                    value = false;
                    smartCandleStick.Patterns["Bullish Engulfing"] = false;
                    return value;
                }
                else
                {   
                    // Get the previous candle stick object
                    smartCandleStick previousCandleStick = data[index - 1];
                    // If the previous candle stick is bearish and the current candle stick is bullish, then it is a Bullish Engulfing pattern
                    if ((smartCandleStick.isBullishcs() == true) && (previousCandleStick.isBearishcs() == true))
                    {
                        // If the open price of the current candle stick is less than the close price of the previous candle stick and the close price of the current candle stick is greater than the open price of the previous candle stick, then it is a Bullish Engulfing pattern
                        if ((smartCandleStick.open < previousCandleStick.close) && (smartCandleStick.close > previousCandleStick.open))
                        {
                            // Set the pattern to true and add it to the dictionary
                            value = true;
                            smartCandleStick.Patterns["Bullish Engulfing"] = true;
                            return value;
                        }
                        else
                        {   
                            // Set the pattern to false and add it to the dictionary if it is not a Bullish Engulfing pattern
                            value = false;
                            smartCandleStick.Patterns["Bullish Engulfing"] = false;
                            return value;
                        }
                    } else
                    {   
                        // Set the pattern to false and add it to the dictionary if it is not a Bullish Engulfing pattern
                        value = false;
                        smartCandleStick.Patterns["Bullish Engulfing"] = false;
                        return value;
                    }
                }
            }
            else
            {   
                // Return the value if the pattern existed
                return value;
            }
        }
    }
}
