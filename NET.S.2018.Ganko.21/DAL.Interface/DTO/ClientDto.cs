using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class ClientDto : IEntity
    {
        public ClientDto()
        {
            Accounts = new List<AccountDto>();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the passport number.
        /// </summary>
        public string PassportNumber { get; set; }

        public List<AccountDto> Accounts { get; set; }
    }
}
