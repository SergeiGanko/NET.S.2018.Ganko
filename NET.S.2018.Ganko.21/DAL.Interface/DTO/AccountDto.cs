namespace DAL.Interface.DTO
{
    public class AccountDto
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public int Bonus { get; set; }

        public string AccountType { get; set; }

        public bool IsClosed { get; set; }

        public ClientDto Client { get; set; }
    }
}
