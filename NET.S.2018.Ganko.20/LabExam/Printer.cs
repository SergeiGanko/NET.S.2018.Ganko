using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Class represents abstract printer
    /// </summary>
    /// <seealso cref="Printer" />
    public abstract class Printer : IEquatable<Printer>
    {
        /// <summary>
        /// Occurs when print start.
        /// </summary>
        public event EventHandler<PrintEventArgs> PrintStart = delegate { };

        /// <summary>
        /// Occurs when print end.
        /// </summary>
        public event EventHandler<PrintEventArgs> PrintEnd = delegate { };

        /// <summary>
        /// Initializes a new instance of the <see cref="Printer"/> class.
        /// </summary>
        /// <param name="model">The model of the printer.</param>
        protected Printer(string model)
        {
            CheckInput(model);

            Model = model;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Emulates printing on a concrete printer.
        /// </summary>
        /// <param name="stream">The stream.</param>
        protected abstract void EmulatePrint(Stream stream);

        public void Print(Stream stream)
        {
            OnPrintStarted(new PrintEventArgs(this, $"Printer:{Name} {Model}: Printing started"));

            EmulatePrint(stream);

            OnPrintEnded(new PrintEventArgs(this, $"Printer:{Name} {Model}: Printing ended"));
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{Name} {Model}";
        }

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

            return Equals((Printer)obj);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Printer other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(this.Name, other.Name)
                   && string.Equals(this.Model, other.Model);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return (Name.GetHashCode() * 73) ^ Model.GetHashCode();
        }

        /// <summary>
        /// Raises the <see cref="E:PrintStarted" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PrintEventArgs"/> instance containing the event data.</param>
        protected virtual void OnPrintStarted(PrintEventArgs e)
        {
            EventHandler<PrintEventArgs> temp = this.PrintStart;
            temp?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:PrintEnded" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PrintEventArgs"/> instance containing the event data.</param>
        protected virtual void OnPrintEnded(PrintEventArgs e)
        {
            EventHandler<PrintEventArgs> temp = this.PrintEnd;
            temp?.Invoke(this, e);
        }

        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <exception cref="ArgumentNullException">Throws the model is null or empty string</exception>
        private void CheckInput(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException($"Argument {nameof(model)} is null or empty");
            }
        }
    }
}
