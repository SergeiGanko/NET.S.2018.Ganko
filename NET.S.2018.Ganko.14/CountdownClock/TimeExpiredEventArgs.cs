using System;

namespace CountdownClock
{
    public class TimeExpiredEventArgs : EventArgs
    {
        public TimeExpiredEventArgs(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException($"Invalid argument {nameof(message)}");
            }
            this.Message = message;
        }

        public string Message { get; }
    }
}