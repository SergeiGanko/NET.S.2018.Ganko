using System;
using System.Collections.Generic;

namespace Task1.Solution
{
    public sealed class PasswordCheckerService
    {
        private readonly IEnumerable<IPasswordValidator> validator;

        private readonly IRepository repository;

        public PasswordCheckerService(IEnumerable<IPasswordValidator> validator, IRepository repository)
        {
            this.validator = validator;
            this.repository = repository;
        }

        public Tuple<bool, string> VerifyPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentException($"Argument {nameof(password)} is null");
            }

            foreach (var rule in validator)
            {
                var result = rule.IsValid(password);

                if (!result.Item1)
                {
                    return result;
                }
            }

            repository.Create(password);

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}