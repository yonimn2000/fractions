namespace YonatanMankovich.Fractions.UnitTest
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
            Assert.AreEqual(0.00798m, dn.GetDecimals());
        }

        [TestMethod]
        public void Set_Decimals()
        {
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(7890.01487m);
            dn.SetDecimals(0.0012481632m);
            Assert.AreEqual(0.0012481632m, dn.GetDecimals());
        }

        [TestMethod]
        public void Set_Decimals_Bad()
        {
            RepeatingDecimalNumber dn;
            decimal test = 56.7089m;
            try
            {
                dn = new RepeatingDecimalNumber(123);
                dn.SetDecimals(test);
            }
            catch (Exception) { return; }
            Assert.Fail(dn.GetDecimalsString());
        }

        [TestMethod]
        public void Get_DecimalsString()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.AreEqual("000456789", dn.GetDecimalsString());
        }

        [TestMethod]
        public void Get_DecimalsString_Zeros()
        {
            decimal test = 001230.00045678900m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.AreEqual("00045678900", dn.GetDecimalsString());
        }

        [TestMethod]
        public void Set_DecimalsString()
        {
            string test = "00987654";
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(001230.000456789m);
            dn.SetDecimalsString(test);
            Assert.AreEqual(test, dn.GetDecimalsString());
        }

        [TestMethod]
        public void Set_DecimalString_Empty()
        {
            string test = "";
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(001230.000456789m);
            dn.SetDecimalsString(test);
            Assert.AreEqual(test, dn.GetDecimalsString());
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
                dn.SetDecimalsString(test);
            }
            catch (Exception) { return; }
            Assert.Fail(dn.GetDecimalsString());
        }

        [TestMethod]
        public void IsWhole()
        {
            decimal test = 001230.000m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.IsTrue(dn.IsWhole());
        }

        [TestMethod]
        public void IsNotWhole()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.IsFalse(dn.IsWhole());
        }

        [TestMethod]
        public void IsNegative()
        {
            decimal test = -001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.IsTrue(dn.IsNegative());
        }

        [TestMethod]
        public void IsPositive()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.IsFalse(dn.IsNegative());
        }

        [TestMethod]
        public void Get_RepeatingPart()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 8);
            Assert.AreEqual("00456789", dn.GetRepeatingPartString());
        }

        [TestMethod]
        public void Get_RepeatingPart_Zeros()
        {
            decimal test = 001230.000456789000m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 8);
            Assert.AreEqual("56789000", dn.GetRepeatingPartString());
        }

        [TestMethod]
        public void Get_RepeatingPart_None()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.AreEqual("", dn.GetRepeatingPartString());
        }

        [TestMethod]
        public void Get_Whole()
        {
            decimal test = 001230.012345601m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.AreEqual((ulong)1230, dn.GetWhole());
        }

        [TestMethod]
        public void Set_Whole()
        {
            ulong test = 1230;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(654312.4897m);
            dn.SetWhole(test);
            Assert.AreEqual(test, dn.GetWhole());
        }

        [TestMethod]
        public void IsRepeatingDecimal()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 1);
            Assert.IsTrue(dn.IsRepeatingDecimal());
        }

        [TestMethod]
        public void IsNotRepeatingDecimal()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.IsFalse(dn.IsRepeatingDecimal());
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
            Assert.AreEqual(new Fraction(6, 17), dn.GetAsFraction());
        }

        [TestMethod]
        public void ToScientificNotationString_Repeating()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 7);
            Assert.AreEqual("       _______" + Environment.NewLine + test, dn.ToLineNotationString());
        }

        [TestMethod]
        public void ToScientificNotationString_RepeatingZero()
        {
            decimal test = 1.010m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test, 2);
            Assert.AreEqual(Environment.NewLine + "   __" + Environment.NewLine + test, Environment.NewLine + dn.ToLineNotationString());
        }

        [TestMethod]
        public void ToScientificNotationString_NonRepeating()
        {
            decimal test = 001230.000456789m;
            RepeatingDecimalNumber dn = new RepeatingDecimalNumber(test);
            Assert.AreEqual(test.ToString(), dn.ToLineNotationString());
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
}