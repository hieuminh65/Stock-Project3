using System;
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
        public Boolean isBullish { get; set; }
        public Boolean isBearish { get; set; }
        public Boolean isNeutral { get; set; }
        public Boolean isMarubozu { get; set; }
        public Boolean isDoji { get; set; }
        public Boolean isDragonFlyDoji { get; set; }
        public Boolean isGraveStoneDoji { get; set; }
        public Boolean isHammer { get; set; }
        public Boolean isInvertedHammer { get; set; }

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

            // Calculate additional properties and patterns
            computeHigherProperties();
            computePatterns();
        }

        // Method to compute higher-level properties of the candlestick
        void computeHigherProperties()
        {
            range = high - low;
            bodyRange = Math.Abs(open - close);
            topPrice = Math.Max(open, close);
            bottomPrice = Math.Min(open, close);
            topTail = Math.Max(high - topPrice, 0);
            bottomTail = Math.Max(bottomPrice - low, 0);
        }

        // Method to compute candlestick patterns
        void computePatterns()
        {
            isBullish = isBullishcs();
            isBearish = isBearishcs();
            isNeutral = isNeutralcs();
            isMarubozu = isMarubozucs();
            isDoji = isDojics();
            isDragonFlyDoji = isDragonFlyDojics();
            isGraveStoneDoji = isGraveStoneDojics();
            isHammer = isHammercs();
            isInvertedHammer = isInvertedHammercs();
        }

        // Method to check if the candlestick is bullish
        Boolean isBullishcs()
        {
            return open < close;
        }

        // Method to check if the candlestick is neutral
        Boolean isNeutralcs()
        {
            return (bodyRange <= 0.5M * range) && (topTail <= 0.1M * range) && (bottomTail <= 0.1M * range);
        }

        // Method to check if the candlestick is bearish
        Boolean isBearishcs()
        {
            return open > close;
        }

        // Method to check if the candlestick is a Marubozu
        Boolean isMarubozucs()
        {
            return bodyRange == range;
        }

        // Method to check if the candlestick is a Doji
        Boolean isDojics()
        {
            return bodyRange < dojiBuffer * open;
        }

        // Method to check if the candlestick is a Hammer
        Boolean isHammercs()
        {
            return topTail < 0.03M * range && bodyRange >= 0.2M * range && bodyRange <= 0.3M * range;
        }

        // Method to check if the candlestick is an Inverted Hammer
        Boolean isInvertedHammercs()
        {
            return bottomTail < 0.03M * range && bodyRange >= 0.2M * range && bodyRange <= 0.3M * range;
        }

        // Method to check if the candlestick is a Dragonfly Doji
        Boolean isDragonFlyDojics()
        {
            return (bodyRange < 0.1M * range) && (bottomTail <= 0.1M * range) && (topTail >= 2 * bottomTail);
        }

        // Method to check if the candlestick is a Gravestone Doji
        Boolean isGraveStoneDojics()
        {
            return (bodyRange < 0.1M * range) && (topTail <= 0.1M * range) && (bottomTail >= 2 * topTail);
        }
    }

}
