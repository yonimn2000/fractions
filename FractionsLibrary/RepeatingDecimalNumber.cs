using System;

namespace FractionsLibrary
{
    public class RepeatingDecimalNumber
    {
        private decimal number;
        private uint repeatingDecimalsCount;

        public decimal Number
        {
            get { return number; }
            set
            {
                RepeatingDecimalsCount = RepeatingDecimalsCount;
                number = value;
            }
        }

        public uint RepeatingDecimalsCount
        {
            get { return repeatingDecimalsCount; }
            set
            {
                if (IsValidRepeatingDecimalsCount(value))
                    repeatingDecimalsCount = value;
                else
                    throw new Exception("Too big RepeatingDecimalCount");
            }
        }

        public bool IsValidRepeatingDecimalsCount(uint count)
        {
            return DecimalsString.Length >= count;
        }

        /// <summary>
        /// Setting this will delete the 'RepeatingPart'
        /// </summary>
        public decimal Decimals
        {
            get
            {
                return Number - Whole;
            }
            set
            {
                if (value < 1)
                    Number = (IsNegative ? -1 : 1) * (Whole + value);
                else
                    throw new Exception("When setting decimals, the input has to be less than 1.");
            }
        }

        /// <summary>
        /// Setting this will delete the 'RepeatingPart'
        /// </summary>
        public string DecimalsString
        {
            get
            {   //Remove everything before the decimal point (including the point).
                return IsWhole ? "" : Number.ToString().Substring(Number.ToString().IndexOf('.') + 1);
            }
            set
            {
                if (!IsStringDigitsOnly(value))
                    throw new Exception("DecimalsString must be numbers only. (Ex: '00920481')");
                if (value != "")
                    Number = (IsNegative ? -1 : 1) * decimal.Parse(Whole.ToString() + '.' + value);
                else
                    Decimals = 0;
            }
        }

        private bool IsStringDigitsOnly(string str)
        {
            foreach (char c in str)
                if (c < '0' || c > '9')
                    return false;
            return true;
        }

        public bool IsWhole { get { return Number % 1 == 0; } }

        public bool IsNegative { get { return Number < 0; } }

        public string RepeatingPartString { get { return Number.ToString().Substring((int)(Number.ToString().Length - RepeatingDecimalsCount)); } }

        public ulong Whole
        {
            get
            {
                return IsWhole ? (ulong)Math.Abs(Number) : (ulong)Math.Abs(Number) / 1;
            }
            set
            {
                number = value + Decimals;
            }
        }

        public bool IsRepeatingDecimal
        {
            get
            {
                return RepeatingDecimalsCount > 0;
            }
        }

        public RepeatingDecimalNumber(decimal decimalNumber, uint repeatingDecimalsCount = 0)
        {
            Number = decimalNumber;
            RepeatingDecimalsCount = repeatingDecimalsCount;
        }

        public Fraction GetAsFraction()
        {
            if (IsRepeatingDecimal)
            {   //According to the formula of geometric series: Sum from n=0 to infinity of a*r^n is a/(1-r) or a*r/(r-1).
                decimal start = decimal.Parse(Number.ToString().Substring(0, (int)(Number.ToString().Length - RepeatingDecimalsCount)));
                decimal topFrac = (Number - start) * (decimal)Math.Pow(10, RepeatingDecimalsCount);
                decimal bottomFrac = (decimal)Math.Pow(10, RepeatingDecimalsCount) - 1;
                return (new Fraction(topFrac, bottomFrac) + new Fraction(start)).Simplify();
            }
            return new Fraction(Number).Simplify();
        }

        static public explicit operator Fraction(RepeatingDecimalNumber number)
        {
            return number.GetAsFraction();
        }

        public string ToScientificNotationString()
        {
            string output = "";
            if (IsRepeatingDecimal)
            {
                for (int i = 0; i < Number.ToString().Length; i++)
                    output += (i < Number.ToString().Length - RepeatingDecimalsCount) ? " " : "_";
                output += Environment.NewLine;
            }
            output += Number.ToString();
            return output;
        }

        public string ToString(uint numberOfCharacters)
        {
            string output = Number.ToString();
            if (IsRepeatingDecimal)
                for (uint i = (uint)output.Length; i < numberOfCharacters; i += RepeatingDecimalsCount)
                    output += RepeatingPartString;
            return IsRepeatingDecimal ? output.Substring(0, (int)numberOfCharacters - 3) + "..." : output;
        }

        public override string ToString()
        {
            return ToString(30);
        }
    }
}