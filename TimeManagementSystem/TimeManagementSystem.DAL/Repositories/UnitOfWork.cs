using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.DAL.Entities;
using TimeManagementSystem.DAL.Interfaces;

namespace TimeManagementSystem.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyDbContext _db;
        private ProjectRepository _projectRepository;
        private ActivitiesInProjectRepository _activitiesInProjectRepository;
        private ActivityRepository _activityRepository;
        private PersonRepository _personRepository;
        private ReportRepository _reportRepository;
        private RiskRepository _riskRepository;
        private RoleRepostory _roleRepository;
        private StatusRepository _statusRepository;
        private TaskRepository _taskRepository;
        private TeammateRepository _teammateRepository;
        private UserRepository _userRepository;
       

        public UnitOfWork(string connectionString)
        {
            _db = new MyDbContext(connectionString);
        }
        public IRepository<Activity> Activities
        {
            get
            {
                return (_activityRepository == null) ? (_activityRepository = new ActivityRepository(_db)):_activityRepository;
            }
        }

        public IRepository<ActivitiesInProject> ActivityInProject
        {
            get
            {
                return(_activitiesInProjectRepository == null) ? (_activitiesInProjectRepository = new ActivitiesInProjectRepository(_db)):_activitiesInProjectRepository;
            }
        }

        public IRepository<Person> Persons
        {
            get
            {
                return (_personRepository == null)?(_personRepository = new PersonRepository(_db)):_personRepository;
            }
        }

        public IRepository<Project> Projects
        {
            get
            {
                if (_projectRepository == null)
                    _projectRepository = new ProjectRepository(_db);
                return _projectRepository;
            }
        }

        public IRepository<Report> Reports
        {
            get
            {
                return (_reportRepository == null) ? (_reportRepository = new ReportRepository(_db)):_reportRepository;
            }
        }

        public IRepository<Risk> Risks
        {
            get
            {
                return (_riskRepository == null) ? (_riskRepository = new RiskRepository(_db)):_riskRepository;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                return (_roleRepository == null) ? (_roleRepository = new RoleRepostory(_db)):_roleRepository;
            }
        }

        public IRepository<Status> Statuses
        {
            get
            {
                return (_statusRepository == null) ? (_statusRepository = new StatusRepository(_db)): _statusRepository;
            }
        }

        public IRepository<Entities.Task> Tasks
        {
            get
            {
                return (_taskRepository == null) ? (_taskRepository = new TaskRepository(_db)): _taskRepository;
            }
        }

        public IRepository<Teammate> Teammates
        {
            get
            {
                return (_teammateRepository == null) ? (_teammateRepository = new TeammateRepository(_db)): _teammateRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return (_userRepository == null) ? (_userRepository = new UserRepository(_db)) : _userRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

       
    }
}
