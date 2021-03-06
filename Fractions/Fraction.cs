﻿using System;

namespace YonatanMankovich.Fractions
{
    public partial class Fraction
    {
        private decimal _denominator;

        public decimal Numerator { get; set; }
        public decimal Denominator
        {
            get { return _denominator; }
            set
            {
                if (value == 0)
                    throw new DivideByZeroException("The denominator cannot be zero.");
                _denominator = value;
            }
        }

        public Fraction(decimal numerator, decimal denominator = 1)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction(decimal whole, decimal numerator, decimal denominator) : this(denominator * whole + numerator, denominator) { }

        public Fraction(Fraction fraction) : this(fraction.Numerator, fraction.Denominator) { }

        public Fraction() : this(0) { }

        public bool IsSimplified()
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
                if (Math.Abs(GetGreatestCommonDenominator()) == 1)
                    return true;
            }
            return false;
        }

        public bool IsNegative()
        {
            if (Numerator < 0 && Denominator > 0)
                return true;
            if (Numerator > 0 && Denominator < 0)
                return true;
            return false;
        }

        public decimal GetWhole()
        {
            return (long)(Numerator / Denominator);
        }

        public void SetWhole(decimal whole)
        {
            Absolute();
            Simplify();
            RemoveWhole();
            Numerator = (whole < 0 ? -1 : 1) * (Math.Abs(whole) * Denominator + Numerator);
        }

        public Fraction GetFractionWithoutWhole()
        {
            return new Fraction(this).RemoveWhole();
        }

        public Fraction RemoveWhole()
        {
            Numerator = (long)Numerator % (long)Denominator;
            return this;
        }

        public bool Equivalent(Fraction fraction)
        {
            return (decimal)this == (decimal)fraction;
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction)
            {
                Fraction fraction = (Fraction)obj;
                return Numerator == fraction.Numerator && Denominator == fraction.Denominator;
            }
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
            if (GetWhole() != 0)
                output += GetWhole() + " ";
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