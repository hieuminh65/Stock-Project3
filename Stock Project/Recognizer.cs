using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Project
{   
    /// <summary>
    /// The abstract class for the Recognizer, this class is used to recognize patterns in the stock data
    /// </summary>
    abstract class Recognizer
    {   
        // Public properties for the pattern name
        public string patternName;
        // The length of the pattern
        public int patternLength;

        /// <summary>
        /// Abstract method to recognize a pattern in the stock data
        /// </summary>
        /// <param name="data">A list of smart candle stick object</param>
        /// <param name="index">The index of the candle stick where user choose to see</param>
        /// <returns>Whether it form a pattern</returns>
        public abstract bool RecognizePattern(List<smartCandleStick> data, int index);
        /// <summary>
        /// The method to recognize all patterns in the stock data
        /// </summary>
        /// <param name="data">A list of smart candle stick object</param>
        public void RecognizeAllPatterns(List<smartCandleStick> data)
        {   
            // Loop through all the candle sticks in the data
            for (int i = 0; i < data.Count; i++)
            {   
                // Call the RecognizePattern method to recognize the pattern
                RecognizePattern(data, i);
            }
        }

        /// <summary>
        /// A constructor for the recognizer class
        /// </summary>
        /// <param name="patternName">The name of the pattern</param>
        /// <param name="patternLength">The length of the pattern</param>
        public Recognizer(string patternName, int patternLength)
        {   
            // Set the pattern name
            this.patternName = patternName;
            // Set the pattern length
            this.patternLength = patternLength;
        }
    }
}
