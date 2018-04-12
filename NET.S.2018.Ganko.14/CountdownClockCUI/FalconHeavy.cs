using System;
using CountdownClock;

namespace CountdownClockCUI
{
    /// <summary>
    /// Class FalconHeavy
    /// </summary>
    /// <seealso cref="CountdownClockCUI.Rocket" />
    public class FalconHeavy : Rocket
    {
        /// <summary>
        /// Commands the received.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TimeExpiredEventArgs" /> instance containing the event data.</param>
        internal override sealed void CommandReceived(object sender, TimeExpiredEventArgs e)
        {
            Console.WriteLine(e.Message + " FalconHeavy launched!");
        }
    }
}
