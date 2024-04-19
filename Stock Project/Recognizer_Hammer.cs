using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Recognizer_Hammer : Recognizer
    {
        public Recognizer_Hammer(string patternName, int patternLength) : base("Hammer", 1)
        {

        }

        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            smartCandleStick smartCandleStick = data[index];
            bool existed = smartCandleStick.Patterns.TryGetValue("Hammer", out bool value);
            if (existed)
            {
                return true;
            }
            else
            {
                if (smartCandleStick.isHammercs())
                {
                    smartCandleStick.Patterns["Hammer"] = true;
                    return true;
                }
            }
            smartCandleStick.Patterns["Hammer"] = false;
            return false;
        }
    }
}
