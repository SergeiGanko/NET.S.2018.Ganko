using Ninject;
using BLL.Interface.Interfaces;
using BLL.Services;
using DAL.Fake.Repositories;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using BLL.Factories;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IFakeRepository>().To<FakeRepository>();
            kernel.Bind<IAccountCreator>().To<AccountCreator>();
            kernel.Bind<IAccountService>().To<AccountService>();
            
            //kernel.Bind<IRepository>().To<AccountBinaryRepository>().WithConstructorArgument("test.bin");
            kernel.Bind<IAccountNumberCreateSevice>().To<AccountNumberCreateSevice>().InSingletonScope();
            
            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
