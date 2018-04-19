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
    class StatusRepository : IRepository<Status>
    {
        MyDbContext db;
        public StatusRepository(MyDbContext db)
        {
            this.db = db;
        }
        public void Create(Status item)
        {
            db.Status.Add(item);
            db.SaveChanges();
        }

        public void Delete(Status item)
        {
            db.Status.Add(item);
            db.SaveChanges();
        }

        public Status Get(Func<Status, bool> filter)
        {
            return db.Status.Find(filter);
        }

        public IEnumerable<Status> GetAll()
        {
            return db.Status;
        }

        public void Update(Status item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
