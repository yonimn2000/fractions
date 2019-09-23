using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YonatanMankovich.Fractions.UnitTest
{
    [TestClass]
    public class FractionsTest
    {
        [TestMethod]
        public void WholeCtor()
        {
            Fraction fraction = new Fraction(5, 3, 8);
            Assert.AreEqual(new Fraction(43, 8), fraction);
        }

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
            Assert.IsTrue(fraction.IsNegative());
        }

        [TestMethod]
        public void IsNegative_Denominator()
        {
            Fraction fraction = new Fraction(3, -8);
            Assert.IsTrue(fraction.IsNegative());
        }

        [TestMethod]
        public void IsNegative_Both()
        {
            Fraction fraction = new Fraction(-3, -8);
            Assert.IsFalse(fraction.IsNegative());
        }

        [TestMethod]
        public void IsNegative()
        {
            Fraction fraction = new Fraction(3, 8);
            Assert.IsFalse(fraction.IsNegative());
        }

        [TestMethod]
        public void IsSimlified()
        {
            Fraction fraction = new Fraction(3, 8);
            Assert.IsTrue(fraction.IsSimplified());
        }

        [TestMethod]
        public void IsSimlified_ZeroDecimal()
        {
            Fraction fraction = new Fraction(3.000m, 8.0m);
            Assert.IsFalse(fraction.IsSimplified());
        }

        [TestMethod]
        public void IsNotSimlified()
        {
            Fraction fraction = new Fraction(6, 8);
            Assert.IsFalse(fraction.IsSimplified());
        }

        [TestMethod]
        public void IsSimlified_Zero()
        {
            Fraction fraction = new Fraction(0, 1);
            Assert.IsTrue(fraction.IsSimplified());
        }

        [TestMethod]
        public void IsNotSimlified_Zero()
        {
            Fraction fraction = new Fraction(0, 8);
            Assert.IsFalse(fraction.IsSimplified());
        }

        [TestMethod]
        public void IsSimlified_Negative()
        {
            Fraction fraction = new Fraction(-3, 8);
            Assert.IsTrue(fraction.IsSimplified());
        }

        [TestMethod]
        public void IsNotSimlified_Negative1()
        {
            Fraction fraction = new Fraction(3, -8);
            Assert.IsFalse(fraction.IsSimplified());
        }

        [TestMethod]
        public void IsNotSimlified_Negative2()
        {
            Fraction fraction = new Fraction(-3, -8);
            Assert.IsFalse(fraction.IsSimplified());
        }

        [TestMethod]
        public void Get_Whole()
        {
            Fraction fraction = new Fraction(26, 8);
            Assert.AreEqual(3, fraction.GetWhole());
        }

        [TestMethod]
        public void Get_Whole_Zero()
        {
            Fraction fraction = new Fraction(3, 8);
            Assert.AreEqual(0, fraction.GetWhole());
        }

        [TestMethod]
        public void Set_Whole()
        {
            Fraction fraction = new Fraction(1, 3);
            fraction.SetWhole(5);
            Assert.AreEqual(new Fraction(16, 3), fraction);
        }

        [TestMethod]
        public void Set_Whole_Negative()
        {
            Fraction fraction = new Fraction(3, 8);
            fraction.SetWhole(-5);
            Assert.AreEqual(-5, fraction.GetWhole());
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
            Assert.IsTrue(new Fraction(0, 1).Equivalent(new Fraction(0, 246).Simplify()));
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
            Assert.AreEqual(new Fraction(4, 9), fraction.Exponenciate(2));
        }

        [TestMethod]
        public void Power_Negative()
        {
            Fraction fraction = new Fraction(-2, 3);
            Assert.AreEqual(new Fraction(9, 4), fraction.Exponenciate(-2));
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
        public void Comparison_Equvalent()
        {
            Assert.IsTrue(new Fraction(15, 2).Equivalent(new Fraction(60, 8)));
        }

        [TestMethod]
        public void Comparison_Equvalent2()
        {
            Assert.IsTrue(new Fraction(5, 10).Equivalent(new Fraction(5, 10)));
        }

        [TestMethod]
        public void Comparison_Equals()
        {
            Assert.IsTrue(new Fraction(5, 2).Equals(new Fraction(5, 2)));
        }

        [TestMethod]
        public void Comparison_NotEquals()
        {
            Assert.IsFalse(new Fraction(10, 4).Equals(new Fraction(20, 8)));
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

        [TestMethod]
        public void Fraction_Reciprocate()
        {
            Assert.AreEqual("-321/-654", new Fraction(-654, -321).Reciprocate().ToString());
        }

        [TestMethod]
        public void Fraction_FractionCtor()
        {
            Assert.AreEqual("-654/-321", new Fraction(new Fraction(-654, -321)).ToString());
        }
    }
}