﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YonatanMankovich.FractionsLibrary;

namespace UnitTest
{
    [TestClass]
    public class RepeatingDecimalNumberTest
    {
        [TestMethod]
        public void Get_Number()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.AreEqual(test, dn.Number);
        }
        [TestMethod]
        public void Set_Number()
        {
            decimal test = 456.000789000m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.AreEqual(test, dn.Number);
        }
        [TestMethod]
        public void Get_Count()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(4560.12300049m, 4);
            Assert.AreEqual(4, (int)dn.RepeatingDecimalsCount);
        }
        [TestMethod]
        public void Get_Count_TailingZeros()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(4560.1230004900m, 4);
            Assert.AreEqual(4, (int)dn.RepeatingDecimalsCount);
        }
        [TestMethod]
        public void Set_Count()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(456.7089m, 3);
            Assert.AreEqual(3, (int)dn.RepeatingDecimalsCount);
        }
        [TestMethod]
        public void Set_Count_TailingZeros()
        {
            decimal test = 001230.0000456m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 7);
            Assert.AreEqual(7, (int)dn.RepeatingDecimalsCount);
        }
        [TestMethod]
        public void Set_Count_OK()
        {
            decimal test = 001230.012121212m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 4);
            Assert.AreEqual(4, (int)dn.RepeatingDecimalsCount);
        }
        [TestMethod]
        public void Set_Count_Empty()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(456.7089m);
            Assert.AreEqual(0, (int)dn.RepeatingDecimalsCount);
        }

        [TestMethod]
        public void Get_Decimals()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(7890.00798m);
            Assert.AreEqual(0.00798m, dn.Decimals);
        }
        [TestMethod]
        public void Set_Decimals()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(7890.01487m);
            dn.Decimals = 0.0012481632m;
            Assert.AreEqual(0.0012481632m, dn.Decimals);
        }
        [TestMethod]
        public void Set_Decimals_Bad()
        {
            RepeatingDecimalNumber dn;
            decimal test = 56.7089m;
            try
            {
                dn = new RepeatingDecimalNumber(123);
                dn.Decimals = test;
            }
            catch (Exception) { return; }
            Assert.Fail(dn.DecimalsString);
        }
        [TestMethod]
        public void Get_DecimalsString()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.AreEqual("000456789", dn.DecimalsString);
        }
        [TestMethod]
        public void Get_DecimalsString_Zeros()
        {
            decimal test = 001230.00045678900m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.AreEqual("00045678900", dn.DecimalsString);
        }
        [TestMethod]
        public void Set_DecimalsString()
        {
            string test = "00987654";
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(001230.000456789m);
            dn.DecimalsString = test;
            Assert.AreEqual(test, dn.DecimalsString);
        }
        [TestMethod]
        public void Set_DecimalString_Empty()
        {
            string test = "";
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(001230.000456789m);
            dn.DecimalsString = test;
            Assert.AreEqual(test, dn.DecimalsString);
        }
        [TestMethod]
        public void Set_DecimalString_Bad_Decimal()
        {
            Set_DecimalString_Bad("0.123");
        }
        [TestMethod]
        public void Set_DecimalString_Bad_Letters()
        {
            Set_DecimalString_Bad("abc");
        }
        private void Set_DecimalString_Bad(string test)
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(001230.000456789m);
            try
            {
                dn.DecimalsString = test;
            }
            catch (Exception) { return; }
            Assert.Fail(dn.DecimalsString);
        }
        [TestMethod]
        public void IsWhole()
        {
            decimal test = 001230.000m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.IsTrue(dn.IsWhole);
        }
        [TestMethod]
        public void IsNotWhole()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.IsFalse(dn.IsWhole);
        }
        [TestMethod]
        public void IsNegative()
        {
            decimal test = -001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.IsTrue(dn.IsNegative);
        }
        [TestMethod]
        public void IsPositive()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.IsFalse(dn.IsNegative);
        }
        [TestMethod]
        public void Get_RepeatingPart()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 8);
            Assert.AreEqual("00456789", dn.RepeatingPartString);
        }
        [TestMethod]
        public void Get_RepeatingPart_Zeros()
        {
            decimal test = 001230.000456789000m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 8);
            Assert.AreEqual("56789000", dn.RepeatingPartString);
        }
        [TestMethod]
        public void Get_RepeatingPart_None()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.AreEqual("", dn.RepeatingPartString);
        }
        [TestMethod]
        public void Get_Whole()
        {
            decimal test = 001230.012345601m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.AreEqual((ulong)1230, dn.Whole);
        }
        [TestMethod]
        public void Set_Whole()
        {
            ulong test = 1230;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(654312.4897m);
            dn.Whole = test;
            Assert.AreEqual(test, dn.Whole);
        }
        [TestMethod]
        public void IsRepeatingDecimal()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 1);
            Assert.IsTrue(dn.IsRepeatingDecimal);
        }
        [TestMethod]
        public void IsNotRepeatingDecimal()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.IsFalse(dn.IsRepeatingDecimal);
        }
        [TestMethod]
        public void GetAsFraction0()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(0.125m);
            Assert.AreEqual(new Fraction(1, 8), dn.GetAsFraction());
        }
        [TestMethod]
        public void GetAsFraction1()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(0.1111m, 2);
            Assert.AreEqual(new Fraction(1, 9), dn.GetAsFraction());
        }
        [TestMethod]
        public void GetAsFraction2()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(123.456m, 3);

            Assert.AreEqual(new Fraction(41111, 333), dn.GetAsFraction());
        }
        [TestMethod]
        public void GetAsFraction3()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(123.045600m, 5);
            Assert.AreEqual(new Fraction(4101479, 33333), dn.GetAsFraction());
        }
        [TestMethod]
        public void GetAsFraction0_Negative()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(-0.125m);
            Assert.AreEqual(new Fraction(-1, 8), dn.GetAsFraction());
        }
        [TestMethod]
        public void GetAsFraction1_Negative()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(-0.1111m, 2);
            Assert.AreEqual(new Fraction(-1, 9), dn.GetAsFraction());
        }
        [TestMethod]
        public void GetAsFraction2_Negative()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(-123.456m, 3);

            Assert.AreEqual(new Fraction(-41111, 333), dn.GetAsFraction());
        }
        [TestMethod]
        public void GetAsFraction3_Negative()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(-123.045600m, 5);
            Assert.AreEqual(new Fraction(-4101479, 33333), dn.GetAsFraction());
        }
        [TestMethod]
        public void GetAsFraction_Huge()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(0.3529411764705882m, 16);
            Assert.AreEqual(new Fraction(12, 34), dn.GetAsFraction());
        }
        [TestMethod]
        public void ToScientificNotationString_Repeating()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 7);
            Assert.AreEqual("       _______" + Environment.NewLine + test, dn.ToScientificNotationString());
        }
        [TestMethod]
        public void ToScientificNotationString_RepeatingZero()
        {
            decimal test = 1.010m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 2);
            Assert.AreEqual(Environment.NewLine + "   __" + Environment.NewLine + test, Environment.NewLine + dn.ToScientificNotationString());
        }
        [TestMethod]
        public void ToScientificNotationString_NonRepeating()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.AreEqual(test.ToString(), dn.ToScientificNotationString());
        }
        [TestMethod]
        public void ToString_Repeating20()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 7);
            Assert.AreEqual("1230.000456789045...", dn.ToString(20));
        }
        [TestMethod]
        public void ToString_Repeating()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 7);
            Assert.AreEqual("1230.0004567890456789045678...", dn.ToString());
        }
        [TestMethod]
        public void ToString_Repeating_Negative()
        {
            decimal test = -001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 7);
            Assert.AreEqual("-1230.000456789045678904567...", dn.ToString());
        }
        [TestMethod]
        public void ToString_Repeating_WithZero()
        {
            decimal test = 001230.000456789000m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 9);
            Assert.AreEqual("1230.0004567890004567890004...", dn.ToString());
        }
        [TestMethod]
        public void ToString_NonRepeating()
        {
            decimal test = 001230.0004567890m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.AreEqual(test.ToString(), dn.ToString());
        }
        [TestMethod]
        public void Cast_Fraction()
        {
            Assert.AreEqual(new Fraction(1, 3), (Fraction)new RepeatingDecimalNumber(0.3m, 1));
        }
    }

    [TestClass]
    public class FractionsTest
    {
        [TestMethod]
        public void Get_Numerator()
        {
            Fraction fraction = new Fraction(3, 8);
            Assert.AreEqual(3, fraction.Numerator);
        }
        [TestMethod]
        public void Set_Numerator()
        {
            Fraction fraction = new Fraction(3, 8);
            fraction.Numerator = 10;
            Assert.AreEqual(10, fraction.Numerator);
        }
        [TestMethod]
        public void Set_Numerator_Negative()
        {
            Fraction fraction = new Fraction(-3, 8);
            fraction.Numerator = -10;
            Assert.AreEqual(-10, fraction.Numerator);
        }
        [TestMethod]
        public void Get_Denominator()
        {
            Fraction fraction = new Fraction(3, 8);
            Assert.AreEqual(8, fraction.Denominator);
        }
        [TestMethod]
        public void Set_Denominator()
        {
            Fraction fraction = new Fraction(3, 8);
            fraction.Denominator = 10;
            Assert.AreEqual(10, fraction.Denominator);
        }
        [TestMethod]
        public void Set_Denominator_Negative()
        {
            Fraction fraction = new Fraction(3, -8);
            fraction.Denominator = -25;
            Assert.AreEqual(-25, fraction.Denominator);
        }
        [TestMethod]
        public void Set_Denominator_Zero()
        {
            Fraction fraction = new Fraction(3, 8);
            try
            {
                fraction.Denominator = 0;
                Assert.Fail(fraction.ToString());
            }
            catch (Exception) { return; }

            Assert.AreEqual(10, fraction.Denominator);
        }
        [TestMethod]
        public void IsNegative_Numerator()
        {
            Fraction fraction = new Fraction(-3, 8);
            Assert.IsTrue(fraction.IsNegative);
        }
        [TestMethod]
        public void IsNegative_Denominator()
        {
            Fraction fraction = new Fraction(3, -8);
            Assert.IsTrue(fraction.IsNegative);
        }
        [TestMethod]
        public void IsNegative_Both()
        {
            Fraction fraction = new Fraction(-3, -8);
            Assert.IsFalse(fraction.IsNegative);
        }
        [TestMethod]
        public void IsNegative()
        {
            Fraction fraction = new Fraction(3, 8);
            Assert.IsFalse(fraction.IsNegative);
        }
        [TestMethod]
        public void IsSimlified()
        {
            Fraction fraction = new Fraction(3, 8);
            Assert.IsTrue(fraction.IsSimplified);
        }
        [TestMethod]
        public void IsSimlified_ZeroDecimal()
        {
            Fraction fraction = new Fraction(3.000m, 8.0m);
            Assert.IsFalse(fraction.IsSimplified);
        }
        [TestMethod]
        public void IsNotSimlified()
        {
            Fraction fraction = new Fraction(6, 8);
            Assert.IsFalse(fraction.IsSimplified);
        }
        [TestMethod]
        public void IsSimlified_Zero()
        {
            Fraction fraction = new Fraction(0, 1);
            Assert.IsTrue(fraction.IsSimplified);
        }
        [TestMethod]
        public void IsNotSimlified_Zero()
        {
            Fraction fraction = new Fraction(0, 8);
            Assert.IsFalse(fraction.IsSimplified);
        }
        [TestMethod]
        public void IsSimlified_Negative()
        {
            Fraction fraction = new Fraction(-3, 8);
            Assert.IsTrue(fraction.IsSimplified);
        }
        [TestMethod]
        public void IsNotSimlified_Negative1()
        {
            Fraction fraction = new Fraction(3, -8);
            Assert.IsFalse(fraction.IsSimplified);
        }
        [TestMethod]
        public void IsNotSimlified_Negative2()
        {
            Fraction fraction = new Fraction(-3, -8);
            Assert.IsFalse(fraction.IsSimplified);
        }
        [TestMethod]
        public void Get_Whole()
        {
            Fraction fraction = new Fraction(26, 8);
            Assert.AreEqual(3, fraction.Whole);
        }
        [TestMethod]
        public void Get_Whole_Zero()
        {
            Fraction fraction = new Fraction(3, 8);
            Assert.AreEqual(0, fraction.Whole);
        }
        [TestMethod]
        public void Set_Whole()
        {
            Fraction fraction = new Fraction(1, 3);
            fraction.Whole = 5;
            Assert.AreEqual(new Fraction(16, 3), fraction);
        }
        [TestMethod]
        public void Set_Whole_Negative()
        {
            Fraction fraction = new Fraction(3, 8);
            fraction.Whole = -5;
            Assert.AreEqual(-5, fraction.Whole);
        }
        [TestMethod]
        public void RemoveWhole()
        {
            Fraction fraction = new Fraction(26, 3);
            Assert.AreEqual(new Fraction(2, 3), fraction.RemoveWhole());
        }
        [TestMethod]
        public void RemoveWhole_Negative()
        {
            Fraction fraction = new Fraction(-26, 8);
            Assert.AreEqual(new Fraction(-2, 8), fraction.RemoveWhole());
        }
        [TestMethod]
        public void GetFractionWithoutWhole()
        {
            Fraction fraction = new Fraction(26, 3);
            Assert.AreEqual(new Fraction(2, 3), fraction.GetFractionWithoutWhole());
        }
        [TestMethod]
        public void GetFractionWithoutWhole_Negative()
        {
            Fraction fraction = new Fraction(-26, 3);
            Assert.AreEqual(new Fraction(-2, 3), fraction.GetFractionWithoutWhole());
        }
        [TestMethod]
        public void Simplify()
        {
            Assert.AreEqual(new Fraction(1, 2), new Fraction(123, 246).Simplify());
        }
        [TestMethod]
        public void Simplify_HugeNumber()
        {
            Assert.AreEqual(new Fraction(245614035087719, 33333333333333), new Fraction(736842105263157m, 99999999999999m).Simplify());
        }
        [TestMethod]
        public void Simplify_Zero()
        {
            Assert.IsTrue(new Fraction(0, 1) == new Fraction(0, 246).Simplify());
        }
        [TestMethod]
        public void Simplify_ZeroDecimal()
        {
            Assert.AreEqual("1/2", new Fraction(1.000m, 2.000m).Simplify().ToString());
        }
        [TestMethod]
        public void Simplify_Decimal()
        {
            Assert.AreEqual(new Fraction(1, 8), new Fraction(0.125m).Simplify());
        }
        [TestMethod]
        public void SimplifyNegative_Both()
        {
            Assert.AreEqual(new Fraction(1, 2), new Fraction(-1, -2).Simplify());
        }
        [TestMethod]
        public void SimplifyNegative_Denominator()
        {
            Assert.AreEqual("-1/2", new Fraction(1, -2).Simplify().ToString());
        }
        [TestMethod]
        public void GetReciprocal()
        {
            Fraction fraction = new Fraction(-26, 3);
            Assert.AreEqual(new Fraction(3, -26), fraction.GetReciprocal());
        }
        [TestMethod]
        public void Power()
        {
            Fraction fraction = new Fraction(-2, 3);
            Assert.AreEqual(new Fraction(4, 9), fraction.Power(2));
        }
        [TestMethod]
        public void Power_Negative()
        {
            Fraction fraction = new Fraction(-2, 3);
            Assert.AreEqual(new Fraction(9, 4), fraction.Power(-2));
        }
        [TestMethod]
        public void Absolute()
        {
            Assert.AreEqual("2/3", new Fraction(-2, -3).Absolute().ToString());
        }
        [TestMethod]
        public void Add()
        {
            Assert.AreEqual(new Fraction(25, 6), new Fraction(2, 3) + new Fraction(7, 2));
        }
        [TestMethod]
        public void Add_Negative()
        {
            Assert.AreEqual(new Fraction(17, 6), new Fraction(-2, 3) + new Fraction(7, 2));
        }
        [TestMethod]
        public void Substract()
        {
            Assert.AreEqual(new Fraction(-17, 6), new Fraction(2, 3) - new Fraction(7, 2));
        }
        [TestMethod]
        public void Substract_Negative()
        {
            Assert.AreEqual(new Fraction(-25, 6), new Fraction(-2, 3) - new Fraction(7, 2));
        }
        [TestMethod]
        public void Mutiply()
        {
            Assert.AreEqual(new Fraction(14, 6), new Fraction(2, 3) * new Fraction(7, 2));
        }
        [TestMethod]
        public void Mutiply_Negative()
        {
            Assert.AreEqual(new Fraction(-14, 6), new Fraction(-2, 3) * new Fraction(7, 2));
        }
        [TestMethod]
        public void Divide()
        {
            Assert.AreEqual(new Fraction(4, 21), new Fraction(2, 3) / new Fraction(7, 2));
        }
        [TestMethod]
        public void Divide_Negative()
        {
            Assert.AreEqual(new Fraction(-4, 21), new Fraction(-2, 3) / new Fraction(7, 2));
        }
        [TestMethod]
        public void Add_Number()
        {
            Assert.AreEqual(new Fraction(17, 3), new Fraction(2, 3) + 5);
        }
        [TestMethod]
        public void Add_Negative_Number()
        {
            Assert.AreEqual(new Fraction(13, 3), new Fraction(-2, 3) + 5);
        }
        [TestMethod]
        public void Substract_Number()
        {
            Assert.AreEqual(new Fraction(-13, 3), new Fraction(2, 3) - 5);
        }
        [TestMethod]
        public void Substract_Negative_Number()
        {
            Assert.AreEqual(new Fraction(-17, 3), new Fraction(-2, 3) - 5);
        }
        [TestMethod]
        public void Mutiply_Number()
        {
            Assert.AreEqual(new Fraction(10, 3), new Fraction(2, 3) * 5);
        }
        [TestMethod]
        public void Mutiply_Negative_Number()
        {
            Assert.AreEqual(new Fraction(-10, 3), new Fraction(-2, 3) * 5);
        }
        [TestMethod]
        public void Divide_Number()
        {
            Assert.AreEqual(new Fraction(2, 15), new Fraction(2, 3) / 5);
        }
        [TestMethod]
        public void Divide_Negative_Number()
        {
            Assert.AreEqual(new Fraction(-2, 15), new Fraction(-2, 3) / 5);
        }
        [TestMethod]
        public void Cast_Double()
        {
            Assert.AreEqual(0.125, (double)new Fraction(1, 8));
        }
        [TestMethod]
        public void Cast_Decimal()
        {
            Assert.AreEqual(0.125m, (decimal)new Fraction(1, 8));
        }
        [TestMethod]
        public void Cast_Int_Zero()
        {
            Assert.AreEqual(0, (int)new Fraction(1, 8));
        }
        [TestMethod]
        public void Cast_Int()
        {
            Assert.AreEqual(2, (int)new Fraction(20, 8));
        }
        [TestMethod]
        public void Comparison_Equals_Sign()
        {
            Assert.IsTrue(new Fraction(5, 2) == new Fraction(5, 2));
        }
        [TestMethod]
        public void Comparison_NotEquals_Sign()
        {
            Assert.IsTrue(new Fraction(10, 20) != new Fraction(5, 10));
        }
        [TestMethod]
        public void Comparison_Equals()
        {
            Assert.IsTrue(new Fraction(15, 2).Equals(new Fraction(60, 8)));
        }
        [TestMethod]
        public void Comparison_NotEquals()
        {
            Assert.IsFalse(new Fraction(19, 8).Equals(new Fraction(20, 8)));
        }
        [TestMethod]
        public void Comparison_LessThan()
        {
            Assert.IsTrue(new Fraction(10, 8) < new Fraction(20, 8));
        }
        [TestMethod]
        public void Comparison_LessThanOrEqual()
        {
            Assert.IsTrue(new Fraction(20, 8) <= new Fraction(20, 8));
        }
        [TestMethod]
        public void Comparison_GreaterThan()
        {
            Assert.IsTrue(new Fraction(10, 8) < new Fraction(20, 2));
        }
        [TestMethod]
        public void Comparison_GreaterThanOrEqual()
        {
            Assert.IsTrue(new Fraction(2, 8) <= new Fraction(2, 8));
        }
        [TestMethod]
        public void GetFractionHashCode()
        {
            Assert.AreEqual("1/8".GetHashCode(), new Fraction(10, 80).GetHashCode());
        }
        [TestMethod]
        public void Fraction_ToMixedString_WholeIsZero()
        {
            Assert.AreEqual("1/3", new Fraction(1, 3).ToMixedFractionString());
        }
        [TestMethod]
        public void Fraction_ToMixedString()
        {
            Assert.AreEqual("3 2/3", new Fraction(11, 3).ToMixedFractionString());
        }
        [TestMethod]
        public void Fraction_ToMixedString_Negative()
        {
            Assert.AreEqual("-3 2/3", new Fraction(-11, 3).ToMixedFractionString());
        }
        [TestMethod]
        public void Fraction_ToMixedString_Whole()
        {
            Assert.AreEqual("1", new Fraction(5, 5).ToMixedFractionString());
        }
        [TestMethod]
        public void Fraction_ToMixedString_NoDenominator()
        {
            Assert.AreEqual("3", new Fraction(9, 3).ToMixedFractionString());
        }
        [TestMethod]
        public void Fraction_ToMixedString_Zero()
        {
            Assert.AreEqual("0", new Fraction(0, 321).ToMixedFractionString());
        }
        [TestMethod]
        public void Fraction_ToString()
        {
            Assert.AreEqual("-654/-321", new Fraction(-654, -321).ToString());
        }
    }
}