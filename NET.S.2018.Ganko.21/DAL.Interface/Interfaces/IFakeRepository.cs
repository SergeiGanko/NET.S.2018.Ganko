using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Interface.Interfaces
{
    public interface IFakeRepository : IRepository<AccountDto>
    {
        AccountDto Get(AccountDto entity);

        AccountDto Get(string number);
    }
}