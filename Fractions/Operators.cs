namespace YonatanMankovich.Fractions
{
    public partial class Fraction
    {
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
            return (long)fraction.Simplify().GetWhole();
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
    }
}