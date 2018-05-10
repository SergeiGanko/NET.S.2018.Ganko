namespace DAL.Interface.DTO
{
    public class AccountDto
    {
        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public int Bonus { get; set; }

        public string AccountType { get; set; }

        public bool IsClosed { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PassportNumber { get; set; }
    }
}
