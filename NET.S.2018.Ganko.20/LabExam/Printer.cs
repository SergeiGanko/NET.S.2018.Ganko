using System;
using System.IO;

namespace LabExam
{
    public sealed class Printer : IEquatable<Printer>
    {
        public event EventHandler<PrintEventArgs> PrintStarted = delegate { };

        public event EventHandler<PrintEventArgs> PrintEnded = delegate { };

        public Printer(string name, string model)
        {
            CheckInput(name, model);

            Name = name;
            Model = model;
        }

        public string Name { get; set; }

        public string Model { get; set; }

        public void Print(FileStream fileStream)
        {
            OnPrintStarted(new PrintEventArgs(this, $"Printer:{Name} {Model}: Printing started"));

            using (fileStream)
            {
                for (int i = 0; i < fileStream.Length; i++)
                {
                    // simulate printing
                    Console.WriteLine(fileStream.ReadByte());
                }
            }

            OnPrintEnded(new PrintEventArgs(this, $"Printer:{Name} {Model}: Printing ended"));
        }

        public override string ToString()
        {
            return $"{Name} {Model}";
        }

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

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Model.GetHashCode();
        }

        private void OnPrintStarted(PrintEventArgs e)
        {
            EventHandler<PrintEventArgs> temp = PrintStarted;
            temp?.Invoke(this, e);
        }

        private void OnPrintEnded(PrintEventArgs e)
        {
            EventHandler<PrintEventArgs> temp = PrintEnded;
            temp?.Invoke(this, e);
        }

        private void CheckInput(string name, string model)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"Argument {nameof(name)} is null or empty");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException($"Argument {nameof(model)} is null or empty");
            }
        }
    }
}
