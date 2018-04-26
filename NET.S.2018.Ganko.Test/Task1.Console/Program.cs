using Task1.Solution;

namespace Task1.Console
{
    using Console = System.Console;

    internal sealed class Program
    {
        private static void Main()
        {
            IPasswordValidator[] validators = {
                new EmptinessValidator(),
                new MinLengthValidator(),
                new MaxLengthValidator(),
                new LetterValidator(),
                new DigitValidator()
            };

            var service = new PasswordCheckerService(validators, new SqlRepository());

            string[] passwords = { "qwerty", "qwertyuiop", "qweRty123", "123456789", "veryShortPassword"};

            foreach (var password in passwords)
            {
                Console.WriteLine(service.VerifyPassword(password));
            }
        }
    }
}
