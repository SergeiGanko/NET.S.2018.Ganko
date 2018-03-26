using System;
using System.Text;

namespace WorkingWithPolynomial
{
    /// <summary>
    /// Polinomial class
    /// </summary>
    public class Polynomial
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coeffs">The coefficients of the polynomial.</param>
        /// <exception cref="System.ArgumentNullException">Throws when the coeffs is null</exception>
        public Polynomial(double[] coeffs)
        {
            Coeffs = coeffs ?? throw new ArgumentNullException(
                         $"Argument {nameof(coeffs)} is null!");

            if (coeffs.Length == 0)
            {
                throw new ArgumentException($"{nameof(coeffs)} is empty");
            }
        }

        /// <summary>
        /// Gets the coeffs.
        /// </summary>
        /// <value>
        /// The coeffs.
        /// </value>
        public double[] Coeffs { get; }

        /// <summary>
        /// Gets the degree of the polynomial.
        /// </summary>
        /// <value>
        /// The degree.
        /// </value>
        public int Degree => Coeffs.Length;

        /// <summary>
        /// Gets the <see cref="System.Double"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="System.Double"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>Returns <see cref="System.Double"/> at the specified index</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">index</exception>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= Coeffs.Length)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(index)} out of range");
                }

                return Coeffs[index];
            }
        }

        #region public methods

        /// <summary>
        /// Adds the specified obj1.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>Returns a new instance of the polynomial obtained by addition of two polynomials</returns>
        public static Polynomial Add(Polynomial obj1, Polynomial obj2) => obj1 + obj2;

        /// <summary>
        /// Adds the specified obj1.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>Returns a new instance of the polynomial obtained by addition of two polynomials</returns>
        public static Polynomial Add(Polynomial obj1, double[] obj2) => obj1 + obj2;

        /// <summary>
        /// Adds the specified obj1.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>Returns a new instance of the polynomial obtained by addition of two polynomials</returns>
        public static Polynomial Add(double[] obj1, Polynomial obj2) => obj1 + obj2;

        /// <summary>
        /// Subtracts the specified obj1.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>Returns a new instance of the polynomial obtained by subtraction of two polynomials</returns>
        public static Polynomial Subtract(Polynomial obj1, Polynomial obj2) => obj1 - obj2;

        /// <summary>
        /// Subtracts the specified obj1.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>Returns a new instance of the polynomial obtained by subtraction of two polynomials</returns>
        public static Polynomial Subtract(Polynomial obj1, double[] obj2) => obj1 - obj2;

        /// <summary>
        /// Subtracts the specified obj1.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>Returns a new instance of the polynomial obtained by subtraction of two polynomials</returns>
        public static Polynomial Subtract(double[] obj1, Polynomial obj2) => obj1 - obj2;

        /// <summary>
        /// Multiplies the specified obj1.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>Returns a new instance of the polynomial obtained by multiplication of two polynomials</returns>
        public static Polynomial Multiply(Polynomial obj1, Polynomial obj2) => obj1 * obj2;

        /// <summary>
        /// Multiplies the specified obj1.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>Returns a new instance of the polynomial obtained by multiplication of two polynomials</returns>
        public static Polynomial Multiply(Polynomial obj1, double[] obj2) => obj1 * obj2;

        /// <summary>
        /// Multiplies the specified obj1.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>Returns a new instance of the polynomial obtained by multiplication of two polynomials</returns>
        public static Polynomial Multiply(double[] obj1, Polynomial obj2) => obj1 * obj2;

        #endregion

        #region System.Object virtual methods overridden

        public override bool Equals(object obj)
        {
            if (!(obj is Polynomial polynomial))
            {
                return false;
            }

            if (polynomial.Degree != this.Degree)
            {
                return false;
            }

            for (int i = 0; i < Coeffs.Length; i++)
            {
                if (polynomial[i] != this[i]) // ?????????????
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            if (Degree == 0)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            for (int i = 0; i < Degree; i++) // test! i=1 ????????????
            {
                builder.Append(Coeffs[Degree]);
                builder.Append(" ");
            }

            return builder.ToString();
        }

        #endregion

        #region overloading operators

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator +(Polynomial obj1, Polynomial obj2)
        {
            CheckInput(obj1.Coeffs, obj2.Coeffs);
            return new Polynomial(Sum(obj1.Coeffs, obj2.Coeffs));
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator +(Polynomial obj1, double[] obj2)
        {
            CheckInput(obj1.Coeffs, obj2);
            return new Polynomial(Sum(obj1.Coeffs, obj2));
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator +(double[] obj1, Polynomial obj2)
        {
            CheckInput(obj1, obj2.Coeffs);
            return new Polynomial(Sum(obj1, obj2.Coeffs));
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator -(Polynomial obj1, Polynomial obj2)
        {
            CheckInput(obj1.Coeffs, obj2.Coeffs);
            return new Polynomial(Sub(obj1.Coeffs, obj2.Coeffs));
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator -(Polynomial obj1, double[] obj2)
        {
            CheckInput(obj1.Coeffs, obj2);
            return new Polynomial(Sub(obj1.Coeffs, obj2));
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator -(double[] obj1, Polynomial obj2)
        {
            CheckInput(obj1, obj2.Coeffs);
            return new Polynomial(Sub(obj1, obj2.Coeffs));
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator *(Polynomial obj1, Polynomial obj2)
        {
            CheckInput(obj1.Coeffs, obj2.Coeffs);
            return new Polynomial(Mult(obj1.Coeffs, obj2.Coeffs));
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator *(Polynomial obj1, double[] obj2)
        {
            CheckInput(obj1.Coeffs, obj2);
            return new Polynomial(Mult(obj1.Coeffs, obj2));
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator *(double[] obj1, Polynomial obj2)
        {
            CheckInput(obj1, obj2.Coeffs);
            return new Polynomial(Mult(obj1, obj2.Coeffs));
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Polynomial obj1, Polynomial obj2)
        {
            return Equals(obj1, obj2);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Polynomial obj1, Polynomial obj2)
        {
            return !Equals(obj1, obj2);
        }

        #endregion

        #region private methods

        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <param name="input1">The input1.</param>
        /// <param name="input2">The input2.</param>
        /// <exception cref="System.ArgumentNullException">Throws when input1 or input2 is null</exception>
        private static void CheckInput(double[] input1, double[] input2)
        {
            if (input1 == null || input2 == null)
            {
                throw new ArgumentNullException(
                    $"Invalid input. Check following arguments: {nameof(input1)}, {nameof(input2)}");
            }
        }

        /// <summary>
        /// Sums the specified input1.
        /// </summary>
        /// <param name="input1">The input1.</param>
        /// <param name="input2">The input2.</param>
        /// <returns>Sums the specified input1 and input2</returns>
        private static double[] Sum(double[] input1, double[] input2)
        {
            double[] smallerArray = null;
            double[] biggerArray = null;

            if (input1.Length >= input2.Length)
            {
                biggerArray = input1;
                smallerArray = input2;
            }
            else
            {
                biggerArray = input2;
                smallerArray = input1;
            }

            var resultArray = new double[biggerArray.Length];

            biggerArray.CopyTo(resultArray, 0);

            for (int i = 0; i < smallerArray.Length; i++)
            {
                resultArray[i] += smallerArray[i];
            }

            return resultArray;
        }

        /// <summary>
        /// Subtracts the specified input1 and input2.
        /// </summary>
        /// <param name="input1">The input1.</param>
        /// <param name="input2">The input2.</param>
        /// <returns>Returns subtraction of two arrays</returns>
        private static double[] Sub(double[] input1, double[] input2)
        {
            double[] biggerArray = null;
            double[] resultArray = null;

            biggerArray = input1.Length > input2.Length ? input1 : input2;

            resultArray = new double[biggerArray.Length];
            input1.CopyTo(resultArray, 0);

            for (int i = 0; i < input2.Length; i++)
            {
                resultArray[i] -= input2[i];
            }

            return resultArray;
        }

        /// <summary>
        /// Mults the specified input1 and input 2.
        /// </summary>
        /// <param name="input1">The input1.</param>
        /// <param name="input2">The input2.</param>
        /// <returns>Returns multiplication of two arrays</returns>
        private static double[] Mult(double[] input1, double[] input2)
        {
            double[] biggerArray = input1.Length > input2.Length ? input1 : input2;
            double[] smallerArray = input1.Length <= input2.Length ? input1 : input2;
            double[] resultArray = new double[biggerArray.Length];

            for (int i = 0; i < smallerArray.Length; i++)
            {
                resultArray[i] = input1[i] * input2[i];
            }

            for (int i = smallerArray.Length; i < biggerArray.Length; i++)
            {
                resultArray[i] = 0; // or result[i] = biggerArray[i];
            }

            return resultArray;
        }

        #endregion
    }
}
