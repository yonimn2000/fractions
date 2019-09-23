# Fractions Library

A simple library to work with fractions and repeating decimal numbers.

## Usage

### Fraction

#### Methods
```cs
Fraction fraction = new Fraction(30, 8); // "30/8"

fraction.IsSimplified(); // False
fraction.IsNegative(); // False
fraction.GetWhole(); // 3
fraction.SetWhole(4); // Changes fraction to "38/8"
fraction.GetFractionWithoutWhole(); // "6/8"
fraction.RemoveWhole(); // Changes fraction to "6/8"
fraction.ToMixedFractionString(); // "4 6/8"
fraction.ToString(); // "38/8"
fraction.Simplify(); // Simplifies fraction to "19/4"
fraction.GetGreatestCommonDenominator(); // 1
fraction.Reciprocate(); // Reciprocates fraction to "4/19"
fraction.GetReciprocal(); // Returns "19/4" without modifying
fraction.Exponenciate(2); // Exponenciates fraction to "64/361"
fraction.Absolute(); // Removes negatives
```

#### Math Operators

Use the `+`, `-`, `*`, and `/` operators.

##### Example with `+`

```cs
Fraction fraction1 = new Fraction(3, 8);
Fraction fraction2 = new Fraction(1, 2);

Fraction resultFraction = fraction1 + fraction2; // "7/8"

//For math with fractions and numbers, use the fraction as the first parameter and the number as the second:
Fraction anotherResultFraction = fraction2 + 2; // "5/2"
```

#### Comparison Operators and Methods

Use the `<`, `>`, `<=`, and `>=` operators, and the `Equals`, and `Equivalent` methods.

**`Equal` compares the numerators and the denominators of two fractions, whereas `Equivalent` compares the values of the two:** `5/10` is equivalent, but not equal to `15/30`.

##### Example with `<`

```cs
Fraction fraction1 = new Fraction(3, 8);
Fraction fraction2 = new Fraction(1, 2);

return fraction1 < fraction2; // True
```

#### Casts

Available casts: `double`, `decimal`, and `long`.

##### Example with `double`

```cs
Fraction fraction = new Fraction(3, 8);

double myDouble = (double)fraction; // 0.375
```


##### Example with `long`

```cs
Fraction fraction1 = new Fraction(3, 8);
Fraction fraction2 = new Fraction(15, 4);

long myLong1 = (long)fraction1; // 0
long myLong2 = (long)fraction2; // 3
```

**Casting into `long` is equivalent to `fraction.GetWhole()`.**

### Repeating Decimal Number

```cs
RepeatingDecimalNumber rdn = new RepeatingDecimalNumber(123.456m, 2); // Second parameter is the count of repeating digits from the end.

rdn.GetAsFraction(); // Returns a conversion of the RepeatingDecimalNumber into a Fraction ("41111/333")
// ^^^ these are equivalent vvv
(Fraction)rdn;

rdn.ToString(); //"123.4565656565656565656..."
rdn.ToLineNotationString(); // Returns:
                            // "     __
                            //  123.456"

rdn.GetDecimalsLength(); // Returns 3
rdn.GetDecimals(); // Returns 456
rdn.SetDecimals(654); // 123.654 
rdn.GetDecimalsString(); // Returns "456"
rdn.SetDecimalsString("0456"); // 123.0456 
rdn.IsWhole(); // False 
rdn.IsNegative(); // False 
rdn.GetRepeatingPartString(); // Returns "56"
rdn.GetWhole(); // Returns 123
rdn.SetWhole(321); // 321.0456 
rdn.IsRepeatingDecimal(); // True 
```

## A Working Example

A working tool that uses this library can be found [here](https://github.com/yonimn2000/fractions-calculator).
