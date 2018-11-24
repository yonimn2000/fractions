using System;
/// <summary>
/// Created by Yonatan Mankovich on 11/11/2018
/// </summary>
namespace FractionsLibrary
{
    public class Fraction
    {

        private decimal denominator;
        public decimal Numerator { get; set; }
        public decimal Denominator
        {
            get { return denominator; }
            set
            {
                if (value == 0)
                    throw new DivideByZeroException("The denominator cannot be zero.");
                denominator = value;
            }
        }

        public Fraction(decimal numerator, decimal denominator = 1)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public bool IsSimplified
        {
            get
            {
                if (Numerator == 0 && Denominator == 1)
                    return true;
                if (Numerator == 0 && Denominator != 1)
                    return false;
                if ((Numerator > 0 && Denominator < 0) || (Numerator < 0 && Denominator < 0))
                    return false;
                if (Numerator % 1 == 0 && Denominator % 1 == 0)
                {
                    if (Numerator.ToString().IndexOf('.') != -1 || Denominator.ToString().IndexOf('.') != -1)
                        return false;
                    if (Math.Abs(GetGreatestCommonDenominator((long)Numerator, (long)Denominator)) == 1)
                        return true;
                }
                return false;
            }
        }

        public bool IsNegative
        {
            get
            {
                if (Numerator < 0 && Denominator > 0)
                    return true;
                if (Numerator > 0 && Denominator < 0)
                    return true;
                return false;
            }
        }

        public decimal Whole
        {
            get
            {
                return (long)(Numerator / Denominator);
            }
            set
            {
                Absolute();
                Simplify();
                RemoveWhole();
                Numerator = (value < 0 ? -1 : 1) * (Math.Abs(value) * Denominator + Numerator);
            }
        }

        public Fraction GetFractionWithoutWhole()
        {
            return new Fraction(Numerator, Denominator).RemoveWhole();
        }

        public Fraction RemoveWhole()
        {
            Numerator = (long)Numerator % (long)Denominator;
            return this;
        }

        public Fraction Simplify()
        {
            if (!IsSimplified)
            {
                if (Numerator == 0 && Denominator != 1)
                    Denominator = 1;
                while (Numerator % 1 != 0 || Denominator % 1 != 0) //If either one is not a whole number
                {
                    Numerator *= 10;
                    Denominator *= 10;
                }
                if (Numerator.ToString().IndexOf('.') != -1 || Denominator.ToString().IndexOf('.') != -1)
                {//Fixes 1.000 to 1
                    Math.Round(Numerator);
                    Math.Round(Denominator);
                }
                Numerator = Math.Round(Numerator);
                Denominator = Math.Round(Denominator);
                long biggestCommonDenominator = GetGreatestCommonDenominator((long)Numerator, (long)Denominator);
                Numerator /= biggestCommonDenominator;
                Denominator /= biggestCommonDenominator;
                if ((Numerator < 0 && Denominator < 0) || (Numerator >= 0 && Denominator < 0))
                {
                    Numerator *= -1;
                    Denominator *= -1;
                }
            }
            return this;
        }

        public long GetGreatestCommonDenominator(long a, long b)
        {
            return a == 0 ? b : GetGreatestCommonDenominator(b % a, a);
        }

        public Fraction GetReciprocal()
        {
            return new Fraction(Denominator, Numerator);
        }

        public Fraction Power(decimal power)
        {
            if (power < 0)
            {
                Fraction reciprocal = GetReciprocal();
                Numerator = reciprocal.Numerator;
                Denominator = reciprocal.Denominator;
                power *= -1;
            }
            Numerator = (decimal)Math.Pow((double)Numerator, (double)power);
            Denominator = (decimal)Math.Pow((double)Denominator, (double)power);
            return this;
        }

        public Fraction Absolute()
        {
            return new Fraction(Math.Abs(Numerator), Math.Abs(Denominator));
        }

        static public Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.Numerator * fraction2.Denominator + fraction2.Numerator * fraction1.Denominator, fraction1.Denominator * fraction2.Denominator);
        }

        static public Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.Numerator * fraction2.Denominator - fraction2.Numerator * fraction1.Denominator, fraction1.Denominator * fraction2.Denominator);
        }

        static public Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.Numerator * fraction2.Numerator, fraction1.Denominator * fraction2.Denominator);
        }

        static public Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            return fraction1 * fraction2.GetReciprocal();
        }

        static public Fraction operator +(Fraction fraction, decimal number)
        {
            return fraction + new Fraction(number);
        }

        static public Fraction operator -(Fraction fraction, decimal number)
        {
            return fraction - new Fraction(number);
        }

        static public Fraction operator *(Fraction fraction, decimal number)
        {
            return fraction * new Fraction(number);
        }

        static public Fraction operator /(Fraction fraction, decimal number)
        {
            return fraction / new Fraction(number);
        }

        static public explicit operator double(Fraction fraction)
        {
            return (double)(fraction.Numerator / fraction.Denominator);
        }

        static public explicit operator decimal(Fraction fraction)
        {
            return fraction.Numerator / fraction.Denominator;
        }

        static public explicit operator long(Fraction fraction)
        {
            return (long)fraction.Simplify().Whole;
        }

        static public bool operator ==(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.Numerator == fraction2.Numerator && fraction1.Denominator == fraction2.Denominator;
        }

        static public bool operator !=(Fraction fraction1, Fraction fraction2)
        {
            return !(fraction1 == fraction2);
        }

        static public bool operator <(Fraction fraction1, Fraction fraction2)
        {
            return (decimal)fraction1 < (decimal)fraction2;
        }

        static public bool operator >(Fraction fraction1, Fraction fraction2)
        {
            return (decimal)fraction1 > (decimal)fraction2;
        }

        static public bool operator <=(Fraction fraction1, Fraction fraction2)
        {
            return (decimal)fraction1 <= (decimal)fraction2;
        }

        static public bool operator >=(Fraction fraction1, Fraction fraction2)
        {
            return (decimal)fraction1 >= (decimal)fraction2;
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction)
                return (decimal)this == (decimal)(Fraction)obj;
            return false;
        }

        public override int GetHashCode()
        {
            return new Fraction(Numerator, Denominator).Simplify().ToString().GetHashCode();
        }

        public string ToMixedFractionString()
        {
            Fraction newFraction = new Fraction(Numerator, Denominator).Absolute().RemoveWhole();
            string output = "";
            if (Whole != 0)
                output += Whole + " ";
            if (newFraction.Numerator != 0)
                output += newFraction.Numerator + "/" + newFraction.Denominator;
            if (output == "")
                output = "0";
            return output.Trim(' ');
        }

        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }
    }
}