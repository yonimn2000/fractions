using System;

namespace YonatanMankovich.FractionsLibrary
{
    public class RepeatingDecimalNumber
    {
        private decimal _number;
        private uint _repeatingDecimalsCount;

        public decimal Number
        {
            get { return _number; }
            set
            {
                _number = value;
                RepeatingDecimalsCount = RepeatingDecimalsCount; //Call the set
            }
        }

        public uint RepeatingDecimalsCount
        {
            get { return _repeatingDecimalsCount; }
            set
            {
                if (IsValidRepeatingDecimalsCount(value))
                    _repeatingDecimalsCount = value;
                else
                    throw new Exception("Too big RepeatingDecimalCount");
            }
        }

        public RepeatingDecimalNumber(decimal decimalNumber, uint repeatingDecimalsCount = 0)
        {
            Number = decimalNumber;
            RepeatingDecimalsCount = repeatingDecimalsCount;
        }

        public bool IsValidRepeatingDecimalsCount(uint count)
        {
            return GetDecimalsLength() >= count;
        }

        public int GetDecimalsLength()
        {
            return GetDecimalsString().Length;
        }

        public string GetDecimalsString()
        {   //Remove everything before the decimal point (including the point).
            return GetIsWhole() ? "" : Number.ToString().Substring(Number.ToString().IndexOf('.') + 1);
        }

        public decimal GetDecimals()
        {
            return Number - GetWhole();
        }

        /// <summary>
        /// Setting this will delete the 'RepeatingPart' 
        /// </summary>
        public void SetDecimals(decimal value)
        {
            if (value < 1)
                Number = (GetIsNegative() ? -1 : 1) * (GetWhole() + value);
            else
                throw new Exception("When setting decimals, the input has to be less than 1.");
        }

        /// <summary>
        /// Setting this will delete the 'RepeatingPart'
        /// </summary>
        public void SetDecimalsString(string value)
        {
            if (!IsStringDigitsOnly(value))
                throw new Exception("DecimalsString must be numbers only. (Ex: '00920481')");
            if (value != "")
                Number = (GetIsNegative() ? -1 : 1) * decimal.Parse(GetWhole().ToString() + '.' + value);
            else
                SetDecimals(0);
        }

        private bool IsStringDigitsOnly(string str)
        {
            foreach (char c in str)
                if (c < '0' || c > '9')
                    return false;
            return true;
        }

        public bool GetIsWhole()
        {
            return Number % 1 == 0;
        }

        public bool GetIsNegative()
        {
            return Number < 0;
        }

        public string GetRepeatingPartString()
        {
            return Number.ToString().Substring((int)(Number.ToString().Length - RepeatingDecimalsCount));
        }

        public ulong GetWhole()
        {
            return GetIsWhole() ? (ulong)Math.Abs(Number) : (ulong)Math.Abs(Number) / 1;
        }

        public void SetWhole(ulong value)
        {
            _number = value + GetDecimals();
        }

        public bool IsRepeatingDecimal()
        {
            return RepeatingDecimalsCount > 0;
        }

        public Fraction GetAsFraction()
        {
            if (IsRepeatingDecimal())
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

        public string ToLineNotationString()
        {
            string output = "";
            if (IsRepeatingDecimal())
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
            if (IsRepeatingDecimal())
                for (uint i = (uint)output.Length; i < numberOfCharacters; i += RepeatingDecimalsCount)
                    output += GetRepeatingPartString();
            return IsRepeatingDecimal() ? output.Substring(0, (int)numberOfCharacters - 3) + "..." : output;
        }

        public override string ToString()
        {
            return ToString(30);
        }
    }
}