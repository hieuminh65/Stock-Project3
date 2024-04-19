using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Recognizer_Doji: Recognizer
    {
        public Recognizer_Doji(string patternName, int patternLength) : base("Doji", 1)
        {

        }

        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            smartCandleStick smartCandleStick = data[index];
            bool existed = smartCandleStick.Patterns.TryGetValue("Doji", out bool value);
            if (existed)
            {
                return true;
            }
            else
            {
                if (smartCandleStick.bodyRange < smartCandleStick.open * 0.05M)
                {
                    smartCandleStick.Patterns["Doji"] = true;
                    return true;
                }
            }
            smartCandleStick.Patterns["Doji"] = false;
            return false;
        }
    }
}
