using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Recognizer_Bullish_Engulfing: Recognizer
    {
        public Recognizer_Bullish_Engulfing(string patternName, int patternLength) : base("Bullish Engulfing", 2)
        {

        }

        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            smartCandleStick smartCandleStick = data[index];
            bool existed = smartCandleStick.Patterns.TryGetValue("Bullish Engulfing", out bool value);
            if (!existed)
            {
                if (index - 1 < 0)
                {
                    value = false;
                    smartCandleStick.Patterns["Bullish Engulfing"] = false;
                    return value;
                }
                else
                {
                    smartCandleStick previousCandleStick = data[index - 1];
                    if ((smartCandleStick.isBullishcs() == true) && (previousCandleStick.isBearishcs() == true))
                    {
                        if ((smartCandleStick.open < previousCandleStick.close) && (smartCandleStick.close > previousCandleStick.open))
                        {
                            value = true;
                            smartCandleStick.Patterns["Bullish Engulfing"] = true;
                            return value;
                        }
                        else
                        {
                            value = false;
                            smartCandleStick.Patterns["Bullish Engulfing"] = false;
                            return value;
                        }
                    } else
                    {
                        value = false;
                        smartCandleStick.Patterns["Bullish Engulfing"] = false;
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
