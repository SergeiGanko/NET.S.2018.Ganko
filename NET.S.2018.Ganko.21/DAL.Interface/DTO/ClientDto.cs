using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class ClientDto
    {
        public ClientDto()
        {
            Accounts = new List<AccountDto>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PassportNumber { get; set; }

        public List<AccountDto> Accounts { get; set; }
    }
}
