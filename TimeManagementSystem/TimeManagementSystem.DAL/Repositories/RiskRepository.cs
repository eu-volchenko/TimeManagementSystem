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
    class RiskRepository : IRepository<Risk>
    {
        MyDbContext db;
        public RiskRepository(MyDbContext db)
        {
            this.db = db;
        }

        public void Create(Risk item)
        {
            db.Risks.Add(item);
            db.SaveChanges();
        }

        public void Delete(Risk item)
        {
            db.Risks.Remove(item);
            db.SaveChanges();
        }

        public Risk Get(Func<Risk, bool> filter)
        {
            return db.Risks.Find(filter);
        }

        public IEnumerable<Risk> GetAll()
        {
            return db.Risks;
        }

        public void Update(Risk item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
