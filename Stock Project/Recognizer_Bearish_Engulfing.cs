using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    /// <summary>
    /// Internal class for the Bearish Engulfing recognizer
    /// </summary>
    internal class Recognizer_Bearish_Engulfing : Recognizer
    {
        /// <summary>
        /// Constructor for the Bearish Engulfing recognizer
        /// </summary>
        /// <param name="patternName"></param>
        /// <param name="patternLength"></param>
        public Recognizer_Bearish_Engulfing(string patternName, int patternLength) : base("Bearish Engulfing", 2)
        {

        }

        /// <summary>
        /// Recognize the Bearish Engulfing pattern
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {   
            // Get the smart candle stick object
            smartCandleStick smartCandleStick = data[index];
            // Check if the pattern existed
            bool existed = smartCandleStick.Patterns.TryGetValue("Bearish Engulfing", out bool value);
            // If the pattern does not exist, then check if it is a Bearish Engulfing pattern
            if (!existed)
            {
                // If the index is less than 1, it cannot form a Bearish Engulfing pattern
                if (index - 1 < 0)
                {
                    // Set the pattern to false
                    value = false;
                    // Set the pattern to false
                    smartCandleStick.Patterns["Bearish Engulfing"] = false;
                    // Return the value
                    return value;
                }
                else
                {   
                    // Get the previous candle stick object
                    smartCandleStick previousCandleStick = data[index - 1];
                    // If the previous candle stick is bullish and the current candle stick is bearish, then it is a Bearish Engulfing pattern
                    if ((smartCandleStick.isBearishcs() == true) && (previousCandleStick.isBullishcs() == true))
                    {
                        // If the open price of the current candle stick is greater than the close price of the previous candle stick and the close price of the current candle stick is less than the open price of the previous candle stick, then it is a Bearish Engulfing pattern
                        if ((smartCandleStick.open > previousCandleStick.close) && (smartCandleStick.close < previousCandleStick.open))
                        {
                            // Set the pattern to true
                            value = true;
                            // Add the pattern to the dictionary
                            smartCandleStick.Patterns["Bearish Engulfing"] = true;
                            return value;
                        }
                        else
                        {   
                            // Set the pattern to false
                            value = false;
                            // Add the pattern to the dictionary
                            smartCandleStick.Patterns["Bearish Engulfing"] = false;
                            return value;
                        }
                    } else
                    {   
                        // Set the pattern to false if it is not a Bearish Engulfing pattern
                        value = false;
                        // Add the pattern to the dictionary
                        smartCandleStick.Patterns["Bearish Engulfing"] = false;
                        return value;
                    }
                }
            }
            else
            {   
                // If the pattern existed, return the value
                return value;
            }
        }
 
        }
    }
