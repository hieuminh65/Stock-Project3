using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Recognizer_Neutral : Recognizer
    {
        public Recognizer_Neutral(string patternName, int patternLength) : base("Neutral", 1)
        {

        }

        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            smartCandleStick smartCandleStick = data[index];
            bool existed = smartCandleStick.Patterns.TryGetValue("Neutral", out bool value);
            if (existed)
            {
                return true;
            }
            else
            {
                if (smartCandleStick.isNeutralcs())
                {
                    smartCandleStick.Patterns["Neutral"] = true;
                    return true;
                }
            }
            smartCandleStick.Patterns["Neutral"] = false;
            return false;
        }
    }
}
