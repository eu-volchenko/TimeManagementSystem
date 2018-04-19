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
    class TeammateRepository : IRepository<Teammate>
    {
        MyDbContext db;
        public TeammateRepository(MyDbContext db)
        {
            this.db = db;
        }
        public void Create(Teammate item)
        {
            db.Teammates.Add(item);
            db.SaveChanges();
        }

        public void Delete(Teammate item)
        {
            db.Teammates.Remove(item);
            db.SaveChanges();
        }

        public Teammate Get(Func<Teammate, bool> filter)
        {
            return db.Teammates.Find(filter);
        }

        public IEnumerable<Teammate> GetAll()
        {
            return db.Teammates;
        }

        public void Update(Teammate item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
