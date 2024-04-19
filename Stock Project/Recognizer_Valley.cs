using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Recognizer_Valley : Recognizer
    {
        public Recognizer_Valley(string patternName, int patternLength) : base("Valley", 3)
        {

        }

        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            smartCandleStick smartCandleStick = data[index];
            bool existed = smartCandleStick.Patterns.TryGetValue("Valley", out bool value);
            if (!existed)
            {
                if ((index - 1) < 0 || (index + 1) >= data.Count)
                {
                    smartCandleStick.Patterns["Valley"] = false;
                    return false;
                } else
                {
                    smartCandleStick previousCandleStick = data[index - 1];
                    smartCandleStick nextCandleStick = data[index + 1];
                    if (smartCandleStick.low < previousCandleStick.low && smartCandleStick.low < nextCandleStick.low)
                    {
                        smartCandleStick.Patterns["Valley"] = true;
                        return true;
                    } else
                    {
                        smartCandleStick.Patterns["Valley"] = false;
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
