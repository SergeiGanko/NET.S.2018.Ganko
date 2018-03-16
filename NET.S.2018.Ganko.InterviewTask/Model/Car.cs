using System;

namespace Model
{
    /// <summary>
    /// Class Car.
    /// Incapsulates information about a car
    /// </summary>
    public sealed class Car : IComparable<Car>
    {
        /// <summary>
        /// Initializes a new instance of the Car class with default values
        /// </summary>
        public Car()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Car class with 2 parameters
        /// </summary>
        /// <param name="manufacturer">car manufacturer</param>
        /// <param name="model">car model</param>
        public Car(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        /// <summary>
        /// Initializes a new instance of the Car class with 3 parameters
        /// </summary>
        /// <param name="manufacturer">car manufacturer</param>
        /// <param name="model">car model</param>
        /// <param name="acceleration">car acceleration</param>
        public Car(string manufacturer, string model, double acceleration) 
            : this(manufacturer, model)
        {
            this.Acceleration = acceleration;
        }

        /// <summary>
        /// Gets or sets a car manufacturer
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets a car model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets a car vin
        /// </summary>
        public double Acceleration { get; set; }

        /// <summary>
        /// Compares cars acceleration
        /// </summary>
        /// <param name="car">Car instance</param>
        /// <returns>
        /// If returns value: less than zero, therefore this instance is less then value,
        /// zero, therefore this instance is equal to value,
        /// greater then zero, therefore this instence is greater then value. 
        /// </returns>
        public int CompareTo(Car car)
        {
            return this.Acceleration.CompareTo(car.Acceleration);
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>Returns string which describes how quick is current car</returns>
        public override string ToString()
        {
            return $"{this.Manufacturer} {this.Model} accelerates in {this.Acceleration} seconds to 100 km/h\n";
        }
    }
}
