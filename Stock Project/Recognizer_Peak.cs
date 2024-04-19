using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Recognizer_Peak : Recognizer
    {
        public Recognizer_Peak(string patternName, int patternLength) : base("Peak", 3)
        {

        }

        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            smartCandleStick smartCandleStick = data[index];
            bool existed = smartCandleStick.Patterns.TryGetValue("Peak", out bool value);
            if (!existed)
            {
                if ((index - 1) < 0 || (index + 1) >= data.Count)
                {
                    smartCandleStick.Patterns["Peak"] = false;
                    return false;
                } else
                {
                    smartCandleStick previousCandleStick = data[index - 1];
                    smartCandleStick nextCandleStick = data[index + 1];
                    if (smartCandleStick.high > previousCandleStick.high && smartCandleStick.high > nextCandleStick.high)
                    {
                        smartCandleStick.Patterns["Peak"] = true;
                        return true;
                    } else
                    {
                        smartCandleStick.Patterns["Peak"] = false;
                        return false;
                    }
                }
                } 
            else
            {
                    return true;
            }
            }
        }   
}
