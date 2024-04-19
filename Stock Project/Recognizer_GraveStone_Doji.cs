using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Recognizer_GraveStone_Doji : Recognizer
    {
        public Recognizer_GraveStone_Doji(string patternName, int patternLength) : base("GraveStoneDoji", 1)
        {

        }

        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            smartCandleStick smartCandleStick = data[index];
            bool existed = smartCandleStick.Patterns.TryGetValue("GraveStoneDoji", out bool value);
            if (existed)
            {
                return true;
            }
            else
            {
                if (smartCandleStick.isGraveStoneDojics())
                {
                    smartCandleStick.Patterns["GraveStoneDoji"] = true;
                    return true;
                }
            }
            smartCandleStick.Patterns["GraveStoneDoji"] = false;
            return false;
        }
    }
}
