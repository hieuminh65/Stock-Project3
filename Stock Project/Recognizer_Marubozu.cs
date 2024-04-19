using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Recognizer_Marubozu : Recognizer
    {
        public Recognizer_Marubozu(string patternName, int patternLength) : base("Marubozu", 1)
        {

        }

        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            smartCandleStick smartCandleStick = data[index];
            bool existed = smartCandleStick.Patterns.TryGetValue("Marubozu", out bool value);
            if (existed)
            {
                return true;
            }
            else
            {
                if (smartCandleStick.isMarubozucs())
                {
                    smartCandleStick.Patterns["Marobozu"] = true;
                    return true;
                }
            }
            smartCandleStick.Patterns["Marobozu"] = false;
            return false;
        }
    }
}
