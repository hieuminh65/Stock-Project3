using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Recognizer_Bullish : Recognizer
    {
        public Recognizer_Bullish(string patternName, int patternLength) : base("Bullish", 1)
        {

        }

        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            smartCandleStick smartCandleStick = data[index];
            bool existed = smartCandleStick.Patterns.TryGetValue("Bullish", out bool value);
            if (existed)
            {
                return true;
            }
            else
            {
                if (smartCandleStick.open < smartCandleStick.close)
                {
                    if (smartCandleStick.open < smartCandleStick.close)
                    {
                        smartCandleStick.Patterns["Bullish"] = true;
                        return true;
                    }
                }
                smartCandleStick.Patterns["Bullish"] = false;   
                return false;

            }
        }
    }
}
