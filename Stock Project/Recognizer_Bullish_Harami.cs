using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Recognizer_Bullish_Harami : Recognizer
    {
        public Recognizer_Bullish_Harami(string patternName, int patternLength) : base("Bullish Harami", 2)
        {

        }

        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            smartCandleStick smartCandleStick = data[index];
            bool existed = smartCandleStick.Patterns.TryGetValue("Bullish Harami", out bool value);
            if (!existed)
            {
                if (index - 1 < 0)
                {
                    value = false;
                    smartCandleStick.Patterns["Bullish Harami"] = false;
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
                            smartCandleStick.Patterns["Bullish Harami"] = true;
                            return value;
                        }
                        else
                        {
                            value = false;
                            smartCandleStick.Patterns["Bullish Harami"] = false;
                            return value;
                        }
                    } else
                    {
                        value = false;
                        smartCandleStick.Patterns["Bullish Harami"] = false;
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
