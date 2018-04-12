using CountdownClock;

namespace CountdownClockCUI
{
    /// <summary>
    /// Class Rocket
    /// </summary>
    public abstract class Rocket
    {
        /// <summary>
        /// Subscribes the specified clock.
        /// </summary>
        /// <param name="clock">The clock.</param>
        public void Subscribe(Clock clock) => clock.TimeExpired += CommandReceived;

        /// <summary>
        /// Unsubscribes the specified clock.
        /// </summary>
        /// <param name="clock">The clock.</param>
        public void Unsubscribe(Clock clock) => clock.TimeExpired -= CommandReceived;

        /// <summary>
        /// Commands the received.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TimeExpiredEventArgs"/> instance containing the event data.</param>
        internal abstract void CommandReceived(object sender, TimeExpiredEventArgs e);
    }
}
