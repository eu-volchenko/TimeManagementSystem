using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.DAL.Entities;

namespace TimeManagementSystem.DAL.Interfaces
{
     public interface IUnitOfWork: IDisposable
    {
        IRepository<Activity> Activities { get; }
        IRepository <ActivitiesInProject> ActivityInProject { get; }
        IRepository <Person> Persons { get; }
        IRepository<Project> Projects { get; }
        IRepository<Report> Reports { get; }
        IRepository<Risk> Risks { get; }
        IRepository<Role> Roles { get; }
        IRepository<Status> Statuses { get; }
        IRepository <Entities.Task> Tasks { get; }
        IRepository <Teammate> Teammates { get; }
        IRepository<User> Users { get; }

        void Save();
    }
}
