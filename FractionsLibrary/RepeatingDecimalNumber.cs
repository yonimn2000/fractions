using System;

namespace FractionsLibrary
{
    public class RepeatingDecimalNumber
    {
        private decimal number = 0;
        private string repeatingDecimals = "";

        public decimal Number
        {
            get { return number; }
            set
            {
                RepeatingDecimals = "";
                number = value;
            }
        }

        public string RepeatingDecimals
        {
            get { return repeatingDecimals; }
            set
            {
                if (IsStringValidAsRepeatingDecimals(value))
                    repeatingDecimals = value;
                else
                    throw new Exception($"The repeating part '{value}' does not exist in the decimal number '{Number}' or located at the wrong index.");
            }
        }

        public bool IsStringValidAsRepeatingDecimals(string repeatingInput)
        {
            return (IsStringDigitsOnly(repeatingInput) && DoesRepeatingPartExistInDecimalsPart(repeatingInput)) || repeatingInput.Equals("");
        }

        private bool IsStringDigitsOnly(string str)
        {
            foreach (char c in str)
                if (c < '0' || c > '9')
                    return false;
            return true;
        }

        private bool DoesRepeatingPartExistInDecimalsPart(string repeatingInput)
        {//Checks if the input number is at the end of the decimal number after removing the tailing zeros.
            return DecimalsString.LastIndexOf(repeatingInput.TrimEnd('0')) >= DecimalsString.Length - repeatingInput.TrimEnd('0').Length;
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
                    Number = Whole + value;
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
            {
                return IsWhole ? "" : Number.ToString().Substring(Number.ToString().IndexOf('.') + 1); //Remove everything before the decimal point (including the point).
            }
            set
            {
                if (!IsStringDigitsOnly(value))
                    throw new Exception("DecimalsString must be numbers only. (Ex: '00920481')");
                if (value != "")
                    Number = decimal.Parse(Whole.ToString() + '.' + value);
                else
                    Decimals = 0;
            }
        }

        public bool IsWhole { get { return Number % 1 == 0; } }

        public bool IsNegative { get { return Number < 0; } }

        public ulong Whole
        {
            get
            {
                return IsWhole ? (ulong)Number : (ulong)Number / 1;
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
                return !RepeatingDecimals.Equals("");
            }
        }

        public RepeatingDecimalNumber(decimal decimalNumber, string repeatingNumbers = "")
        {
            Number = decimalNumber;
            RepeatingDecimals = repeatingNumbers;
        }

        public Fraction GetAsFraction()
        {
            if (IsRepeatingDecimal)
            {//According to the formula of geometric series: Sum from n=0 to infinity of ar^n is a/(1-r) or ar/(r-1).
                decimal start = decimal.Parse(Number.ToString().Substring(0, Number.ToString().LastIndexOf(RepeatingDecimals.TrimEnd('0'))));//TrimEnd(RepeatingDecimals.ToCharArray()));
                decimal topFrac = (Number - start) * (decimal)Math.Pow(10, RepeatingDecimals.Length);
                decimal bottomFrac = (decimal)Math.Pow(10, RepeatingDecimals.Length) - 1;
                return (new Fraction(topFrac, bottomFrac) + new Fraction(start)).Simplify();
            }
            /*if (approximate)
            {//TODO: aproximate decimal as fraction (bool approximate = false, uint precision = 5)
                ;
            }*/
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
                    output += (i < Number.ToString().Length - RepeatingDecimals.Length) ? " " : "_";
                output += Environment.NewLine;
            }
            output += Number.ToString();
            return output;
        }

        public string ToString(uint numberOfRepetitions)
        {
            string output = Number.ToString();
            if (IsRepeatingDecimal)
                for (int i = 0; i < numberOfRepetitions - 1; i++)
                    output += RepeatingDecimals;
            return output + "...";
        }

        public override string ToString()
        {
            return ToString(3);
        }
    }
}