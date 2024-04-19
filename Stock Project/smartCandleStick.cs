﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Stock_Project
{
    internal class smartCandleStick : Candlestick
    {
        // Declaring public properties for additional candlestick data
        public Decimal range { get; set; }
        public Decimal bodyRange { get; set; }
        public Decimal topPrice { get; set; }
        public Decimal bottomPrice { get; set; }
        public Decimal topTail { get; set; }
        public Decimal bottomTail { get; set; }
        

        // Initialize Dictionary for Patterns
        public Dictionary<string, bool> Patterns { get; private set; }

        // Static variable for doji buffer
        static Decimal dojiBuffer = 0.05M;

        // Constructor that takes an existing candlestick (cs) and initializes properties
        public smartCandleStick(Candlestick cs)
        {
            this.volume = cs.volume;
            this.open = cs.open;
            this.close = cs.close;
            this.high = cs.high;
            this.low = cs.low;
            this.date = cs.date;

            // initialize the dictionaries, calculate additional properties and patterns
            initializePatternsDictionary();
            computeHigherProperties();
            computePatterns();
        }

        /// <summary>
        /// Function to initialize the patterns dictionary
        /// </summary>
        void initializePatternsDictionary()
        {
            Patterns = new Dictionary<string, bool>
            {
                { "Bullish", false },
                { "Bearish", false },
                { "Neutral", false },
                { "Marubozu", false },
                { "Doji", false },
                { "DragonFlyDoji", false },
                { "GraveStoneDoji", false },
                { "Hammer", false },
            };
        }

        // Compute higher-level properties of the candlestick
        void computeHigherProperties()
        {
            range = high - low;
            bodyRange = Math.Abs(open - close);
            topPrice = Math.Max(open, close);
            bottomPrice = Math.Min(open, close);
            topTail = Math.Max(high - topPrice, 0);
            bottomTail = Math.Max(bottomPrice - low, 0);
        }

        // Compute candlestick patterns
        void computePatterns()
        {
            
            Patterns["Bullish"] = isBullishcs();
            
            Patterns["Bearish"] = isBearishcs();
            
            Patterns["Neutral"] = isNeutralcs();
            
            Patterns["Marubozu"] = isMarubozucs();
            
            Patterns["Doji"] = isDojics();
            
            Patterns["DragonFlyDoji"] = isDragonFlyDojics();
            
            Patterns["GraveStoneDoji"] = isGraveStoneDojics();

            Patterns["Hammer"] = isHammercs();

        }

        // Check if the candlestick is bullish
        public Boolean isBullishcs()
        {
            return open < close;
        }

        // Check if the candlestick is neutral
        public Boolean isNeutralcs()
        {
            return (bodyRange <= 0.3M * range);
        }

        // Check if the candlestick is bearish
        public Boolean isBearishcs()
        {
            return open > close;
        }

        // Check if the candlestick is a Marubozu
        public Boolean isMarubozucs()
        {
            return bodyRange == range;
        }

        // Check if the candlestick is a Doji
        public Boolean isDojics()
        {
            return bodyRange < dojiBuffer * open;
        }

        // Check if the candlestick is a Hammer
        public Boolean isHammercs()
        {
            return topTail < 0.03M * range && bodyRange >= 0.2M * range && bodyRange <= 0.3M * range;
        }



        // Check if the candlestick is a Dragonfly Doji
        public Boolean isDragonFlyDojics()
        {
            return (bodyRange < 0.1M * range) && (bottomTail <= 0.1M * range) && (topTail >= 2 * bottomTail);
        }

        // Check if the candlestick is a Gravestone Doji
        public Boolean isGraveStoneDojics()
        {
            return (bodyRange < 0.1M * range) && (topTail <= 0.1M * range) && (bottomTail >= 2 * topTail);
        }
    }

}
