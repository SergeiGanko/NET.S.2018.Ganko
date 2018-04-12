using CountdownClock;

namespace CountdownClockCUI
{
    internal sealed class Program
    {
        private static void Main()
        {
            Clock countdownClock = new Clock(10);

            var falconOne = new FalconOne();
            falconOne.Subscribe(countdownClock);
            var falconHeavy = new FalconHeavy();
            falconHeavy.Subscribe(countdownClock);

            countdownClock.StartCountdown();
        }
    }
}
