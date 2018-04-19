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
    class ActivitiesInProjectRepository : IRepository<ActivitiesInProject>
    {
        private MyDbContext db;
        public ActivitiesInProjectRepository(MyDbContext db)
        {
            this.db = db;
        }
        public void Create(ActivitiesInProject item)
        {
            db.ActivitiesInProjects.Add(item);
            db.SaveChanges();
        }

        public void Delete(ActivitiesInProject item)
        {
            db.ActivitiesInProjects.Remove(item);
            db.SaveChanges();
        }

        public ActivitiesInProject Get(Func<ActivitiesInProject, bool> filter)
        {
            return db.ActivitiesInProjects.Find(filter);
        }

        public IEnumerable<ActivitiesInProject> GetAll()
        {
            return db.ActivitiesInProjects;
        }

        public void Update(ActivitiesInProject item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
