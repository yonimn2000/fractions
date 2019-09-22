using System;

namespace YonatanMankovich.Fractions
{
    public partial class Fraction
    {
        public Fraction Simplify()
        {
            if (!IsSimplified())
            {
                if (Numerator == 0 && Denominator != 1)
                    Denominator = 1;
                while (Numerator % 1 != 0 || Denominator % 1 != 0) //If either one is not a whole number
                {
                    Numerator *= 10;
                    Denominator *= 10;
                }
                //Fix 1.000 to 1
                Numerator = Math.Round(Numerator);
                Denominator = Math.Round(Denominator);
                long biggestCommonDenominator = GetGreatestCommonDenominator();
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

        /// <summary>
        /// Uses the Euclidean algorithm.
        /// </summary>
        public long GetGreatestCommonDenominator()
        {
            return GetGreatestCommonDenominator((long)Numerator, (long)Denominator);
        }

        private long GetGreatestCommonDenominator(long a, long b)
        {
            return a == 0 ? b : GetGreatestCommonDenominator(b % a, a);
        }

        public Fraction Reciprocate()
        {
            decimal temp = Numerator;
            Numerator = Denominator;
            Denominator = temp;
            return this;
        }

        public Fraction GetReciprocal()
        {
            return new Fraction(Reciprocate());
        }

        public Fraction Exponenciate(decimal exponent)
        {
            if (exponent < 0)
            {
                Fraction reciprocal = GetReciprocal();
                Numerator = reciprocal.Numerator;
                Denominator = reciprocal.Denominator;
                exponent *= -1;
            }
            Numerator = (decimal)Math.Pow((double)Numerator, (double)exponent);
            Denominator = (decimal)Math.Pow((double)Denominator, (double)exponent);
            return this;
        }

        public Fraction Absolute()
        {
            Numerator = Math.Abs(Numerator);
            Denominator = Math.Abs(Denominator);
            return this;
        }
    }
}