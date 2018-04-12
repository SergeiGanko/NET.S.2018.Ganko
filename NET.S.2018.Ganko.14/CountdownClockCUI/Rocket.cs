using CountdownClock;

namespace CountdownClockCUI
{
    public abstract class Rocket
    {
        public void Subscribe(Clock clock) => clock.TimeExpired += CommandReceived;

        public void Unsubscribe(Clock clock) => clock.TimeExpired -= CommandReceived;

        internal abstract void CommandReceived(object sender, TimeExpiredEventArgs e);
    }
}
