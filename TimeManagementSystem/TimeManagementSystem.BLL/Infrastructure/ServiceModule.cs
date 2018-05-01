using Ninject.Modules;
using TimeManagementSystem.BLL.Interfaces;
using TimeManagementSystem.BLL.Service;
using TimeManagementSystem.DAL.Interfaces;
using TimeManagementSystem.DAL.Repositories;

namespace TimeManagementSystem.BLL.Infrastructure
{
    public class ServiceModule: NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
            Bind<IProjectService>().To<ProjectService>();
            Bind<ITeammateService>().To<TeammateService>();
            Bind<IAccauntService>().To<AccauntService>();
        }
    }
}
