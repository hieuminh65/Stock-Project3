using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Recognizer_Bearish : Recognizer
    {
        public Recognizer_Bearish(string patternName, int patternLength) : base("Bearish", 1)
        {

        }

        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            smartCandleStick smartCandleStick = data[index];
            bool existed = smartCandleStick.Patterns.TryGetValue("Bearish", out bool value);
            if (existed)
            {
                return true;
            }
            else
            {
                if (smartCandleStick.open > smartCandleStick.close)
                {
                    if (smartCandleStick.open > smartCandleStick.close)
                    {
                        smartCandleStick.Patterns["Bearish"] = true;
                        return true;
                    }
                }
                smartCandleStick.Patterns["Bearish"] = false;   
                return false;

            }
        }
    }
}
