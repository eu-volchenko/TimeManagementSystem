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
    class ReportRepository : IRepository<Report>
    {
        MyDbContext db;
        public ReportRepository(MyDbContext db)
        {
            this.db = db;
        }


        public void Create(Report item)
        {
            db.Reports.Add(item);
            db.SaveChanges();
        }

        public void Delete(Report item)
        {
            db.Reports.Remove(item);
            db.SaveChanges();
        }

        public Report Get(Func<Report, bool> filter)
        {
            return db.Reports.Find(filter);
        }

        public IEnumerable<Report> GetAll()
        {
            return db.Reports;
        }

        public void Update(Report item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
