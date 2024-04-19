using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Recognizer_DragonFly_Doji : Recognizer
    {
        public Recognizer_DragonFly_Doji(string patternName, int patternLength) : base("DragonFlyDoji", 1)
        {

        }

        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            smartCandleStick smartCandleStick = data[index];
            bool existed = smartCandleStick.Patterns.TryGetValue("DragonFlyDoji", out bool value);
            if (existed)
            {
                return true;
            }
            else
            {
                if (smartCandleStick.isDragonFlyDojics())
                {
                    smartCandleStick.Patterns["DragonFlyDoji"] = true;
                    return true;
                }
            }
            smartCandleStick.Patterns["DragonFlyDoji"] = false;
            return false;
        }
    }
}
