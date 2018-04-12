using System;

namespace CountdownClock
{
    using System.Threading;

    public sealed class Clock
    {
        private readonly int seconds;

        public Clock(int seconds)
        {
            if (seconds < 0)
            {
                throw new ArgumentException($"Invalid argument {nameof(seconds)}");
            }

            this.seconds = seconds;
        }

        public event EventHandler<TimeExpiredEventArgs> TimeExpired = delegate { };

        public void StartCountdown()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(this.seconds);
            do
            {
                timeSpan = timeSpan.Subtract(TimeSpan.FromSeconds(1));
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            while (timeSpan != TimeSpan.Zero);

            if (timeSpan == TimeSpan.Zero)
            {
                OnTimeExpired(this, new TimeExpiredEventArgs($"{this.seconds} seconds is over!"));
            }
        }

        private void OnTimeExpired(object sender, TimeExpiredEventArgs e)
        {
            EventHandler<TimeExpiredEventArgs> tempHandler = TimeExpired;
            tempHandler?.Invoke(sender, e);
        }
    }
}