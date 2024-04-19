using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Recognizer_Bearish_Engulfing : Recognizer
    {
        public Recognizer_Bearish_Engulfing(string patternName, int patternLength) : base("Bearish Engulfing", 2)
        {

        }

        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            smartCandleStick smartCandleStick = data[index];
            bool existed = smartCandleStick.Patterns.TryGetValue("Bearish Engulfing", out bool value);
            if (!existed)
            {
                if (index - 1 < 0)
                {
                    value = false;
                    smartCandleStick.Patterns["Bearish Engulfing"] = false;
                    return value;
                }
                else
                {
                    smartCandleStick previousCandleStick = data[index - 1];
                    if ((smartCandleStick.isBearishcs() == true) && (previousCandleStick.isBullishcs() == true))
                    {
                        if ((smartCandleStick.open > previousCandleStick.close) && (smartCandleStick.close < previousCandleStick.open))
                        {
                            value = true;
                            smartCandleStick.Patterns["Bearish Engulfing"] = true;
                            return value;
                        }
                        else
                        {
                            value = false;
                            smartCandleStick.Patterns["Bearish Engulfing"] = false;
                            return value;
                        }
                    } else
                    {
                        value = false;
                        smartCandleStick.Patterns["Bearish Engulfing"] = false;
                        return value;
                    }
                }
            }
            else
            {
                return value;
            }
        }
 
        }
    }
