using System;
using CountdownClock;

namespace CountdownClockCUI
{
    public class FalconHeavy : Rocket
    {
        internal override sealed void CommandReceived(object sender, TimeExpiredEventArgs e)
        {
            Console.WriteLine(e.Message + " FalconHeavy launched!");
        }
    }
}
