using System;
using CountdownClock;

namespace CountdownClockCUI
{
    public class FalconOne : Rocket
    {
        internal override sealed void CommandReceived(object sender, TimeExpiredEventArgs e)
        {
            Console.WriteLine(e.Message + " FalconOne launched!");
        }
    }
}
