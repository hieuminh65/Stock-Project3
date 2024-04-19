using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{
    internal class Recognizer_Bearish_Harami : Recognizer
    {
        public Recognizer_Bearish_Harami(string patternName, int patternLength) : base("Bearish Harami", 2)
        {

        }

        public override bool RecognizePattern(List<smartCandleStick> data, int index)
        {
            smartCandleStick smartCandleStick = data[index];
            bool existed = smartCandleStick.Patterns.TryGetValue("Bearish Harami", out bool value);
            if (!existed)
            {
                if (index - 1 < 0)
                {
                    value = false;
                    smartCandleStick.Patterns["Bearish Harami"] = false;
                    return value;
                }
                else
                {
                    smartCandleStick previousCandleStick = data[index - 1];
                    if ((smartCandleStick.isBearishcs() == true) && (previousCandleStick.isBullishcs() == true))
                    {
                        if ((previousCandleStick.close > previousCandleStick.close) && (smartCandleStick.close < smartCandleStick.open))
                        {
                            value = true;
                            smartCandleStick.Patterns["Bearish Harami"] = true;
                            return value;
                        }
                        else
                        {
                            value = false;
                            smartCandleStick.Patterns["Bearish Harami"] = false;
                            return value;
                        }
                    } else
                    {
                        value = false;
                        smartCandleStick.Patterns["Bearish Harami"] = false;
                        return value;
                    }
                }
            }
            else
            {
                return value;
            }
        }   
    }       
}
