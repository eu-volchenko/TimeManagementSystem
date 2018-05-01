using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.DAL.Entities;
using TimeManagementSystem.DAL.Interfaces;

namespace TimeManagementSystem.DAL.Repositories
{
    class ProjectRepository : IRepository<Project>
    {
        private MyDbContext db;
        public ProjectRepository(MyDbContext db)
        {
            this.db = db;
        }
        public void Create(Project item)
        {
            db.Projects.Add(item);
            db.SaveChanges();
        }

        public void Delete(Project item)
        {
            db.Projects.Remove(item);
            db.SaveChanges();
        }

        public Project Get(Func<Project, bool> filter)
        {
            IEnumerable<Project> project = db.Projects.Where(filter);
            return project.FirstOrDefault();
        }

        public IEnumerable<Project> GetAll()
        {
            return db.Projects;
        }

        public void Update(Project item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
