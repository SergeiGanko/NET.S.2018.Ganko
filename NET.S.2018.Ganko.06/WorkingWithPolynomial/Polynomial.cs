using System;
using System.Text;
using System.Configuration;

namespace WorkingWithPolynomial
{
    /// <summary>
    /// Polinomial class
    /// </summary>
    public sealed class Polynomial
    {
        /// <summary>
        /// The coeffs of the polynomial
        /// </summary>
        private readonly double[] coeffs = { };

        /// <summary>
        /// Initializes the <see cref="Polynomial"/> class.
        /// </summary>
        static Polynomial()
        {
            try
            {
                var appSettingsReader = new AppSettingsReader();

                Epsilon = (double)appSettingsReader.GetValue("epsilon", typeof(double));
            }
            catch (InvalidOperationException)
            {
                Epsilon = 0.001;
            }
            catch (ArgumentNullException)
            {
                Epsilon = 0.001;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coeffs">The coefficients of the polynomial.</param>
        /// <exception cref="System.ArgumentNullException">Throws when the coeffs is null</exception>
        public Polynomial(params double[] coeffs)
        {
            if (coeffs == null)
            {
                throw new ArgumentNullException($"Argument {nameof(coeffs)} is null!");
            }

            if (coeffs.Length == 0)
            {
                throw new ArgumentException($"{nameof(coeffs)} is empty");
            }

            this.coeffs = new double[coeffs.Length];

            coeffs.CopyTo(this.coeffs, 0);
        }

        /// <summary>
        /// Gets the accuracy.
        /// </summary>
        /// <value>
        /// The accuracy.
        /// </value>
        public static double Epsilon { get; }

        /// <summary>
        /// Gets the degree of the polynomial.
        /// </summary>
        /// <value>
        /// The degree.
        /// </value>
        public int Degree
        {
            get
            {
                for (int i = this.coeffs.Length - 1; i >= 0; i--)
                {
                    if (Math.Abs(this.coeffs[i]) > Epsilon)
                    {
                        return i;
                    }
                }

                return -1;
            }
        }

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
                if (index < 0 || index >= Degree)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(index)} out of range");
                }

                return coeffs[index];
            }

            private set
            {
                if (index >= 0 && index < Degree)
                {
                    this.coeffs[index] = value;
                }
            }
        }

        #region public methods

        /// <summary>
        /// Adds the specified lhs and rhs.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>Returns a new instance of the polynomial obtained by addition of two polynomials</returns>
        public static Polynomial Add(Polynomial lhs, Polynomial rhs) => lhs + rhs;

        /// <summary>
        /// Adds the specified lhs and rhs.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>Returns a new instance of the polynomial obtained by addition of two polynomials</returns>
        public static Polynomial Add(Polynomial lhs, double[] rhs) => lhs + rhs;

        /// <summary>
        /// Adds the specified lhs and rhs.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>Returns a new instance of the polynomial obtained by addition of two polynomials</returns>
        public static Polynomial Add(double[] lhs, Polynomial rhs) => lhs + rhs;

        /// <summary>
        /// Subtracts the specified lhs and rhs.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>Returns a new instance of the polynomial obtained by subtraction of two polynomials</returns>
        public static Polynomial Subtract(Polynomial lhs, Polynomial rhs) => lhs - rhs;

        /// <summary>
        /// Subtracts the specified lhs and rhs.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>Returns a new instance of the polynomial obtained by subtraction of two polynomials</returns>
        public static Polynomial Subtract(Polynomial lhs, double[] rhs) => lhs - rhs;

        /// <summary>
        /// Subtracts the specified lhs and rhs.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="obj2">The rhs.</param>
        /// <returns>Returns a new instance of the polynomial obtained by subtraction of two polynomials</returns>
        public static Polynomial Subtract(double[] lhs, Polynomial rhs) => lhs - rhs;

        /// <summary>
        /// Multiplies the specified lhs and rhs.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>Returns a new instance of the polynomial obtained by multiplication of two polynomials</returns>
        public static Polynomial Multiply(Polynomial lhs, Polynomial rhs) => lhs * rhs;

        /// <summary>
        /// Multiplies the specified lhs and rhs.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>Returns a new instance of the polynomial obtained by multiplication of two polynomials</returns>
        public static Polynomial Multiply(Polynomial lhs, double[] rhs) => lhs * rhs;

        /// <summary>
        /// Multiplies the specified lhs and rhs.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>Returns a new instance of the polynomial obtained by multiplication of two polynomials</returns>
        public static Polynomial Multiply(double[] lhs, Polynomial rhs) => lhs * rhs;

        #endregion

        #region System.Object virtual methods overridden

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Polynomial)obj);
        }


        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>Returns true if current polynomial equals other polynomial</returns>
        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.Degree != other.Degree)
            {
                return false;
            }

            if (other.Degree != this.Degree)
            {
                return false;
            }

            for (int i = 0; i < this.Degree; i++)
            {
                if (!this.coeffs[i].Equals(other.coeffs[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => this.Degree.GetHashCode() * 17 + this.coeffs.GetHashCode();

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (Degree == 0)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            for (int i = 0; i < Degree; i++)
            {
                builder.Append(coeffs[Degree]);
                builder.Append(" ");
            }

            return builder.ToString();
        }

        #endregion

        #region overloading operators

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            CheckInput(lhs.coeffs, rhs.coeffs);
            return new Polynomial(Sum(lhs.coeffs, rhs.coeffs));
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator +(Polynomial lhs, double[] rhs)
        {
            CheckInput(lhs.coeffs, rhs);
            return new Polynomial(Sum(lhs.coeffs, rhs));
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator +(double[] lhs, Polynomial rhs)
        {
            CheckInput(lhs, rhs.coeffs);
            return new Polynomial(Sum(lhs, rhs.coeffs));
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            CheckInput(lhs.coeffs, rhs.coeffs);
            return new Polynomial(Sub(lhs.coeffs, rhs.coeffs));
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator -(Polynomial lhs, double[] rhs)
        {
            CheckInput(lhs.coeffs, rhs);
            return new Polynomial(Sub(lhs.coeffs, rhs));
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator -(double[] lhs, Polynomial rhs)
        {
            CheckInput(lhs, rhs.coeffs);
            return new Polynomial(Sub(lhs, rhs.coeffs));
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            CheckInput(lhs.coeffs, rhs.coeffs);
            return new Polynomial(Mult(lhs.coeffs, rhs.coeffs));
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator *(Polynomial lhs, double[] rhs)
        {
            CheckInput(lhs.coeffs, rhs);
            return new Polynomial(Mult(lhs.coeffs, rhs));
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator *(double[] lhs, Polynomial rhs)
        {
            CheckInput(lhs, rhs.coeffs);
            return new Polynomial(Mult(lhs, rhs.coeffs));
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            return Equals(lhs.coeffs, rhs.coeffs);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="lhs">The lhs.</param>
        /// <param name="rhs">The rhs.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            return !Equals(lhs.coeffs, rhs.coeffs);
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
