using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TimeManagementSystem.DAL.Entities;
using TimeManagementSystem.DAL.Interfaces;

namespace TimeManagementSystem.DAL.Repositories
{
    class TaskRepository : IRepository<Task>
    {
        MyDbContext db;
        public TaskRepository(MyDbContext db)
        {
            this.db = db;
        }
        public void Create(Task item)
        {
            db.Tasks.Add(item);
            db.SaveChanges();
        }

        public void Delete(Task item)
        {
            db.Tasks.Remove(item);
            db.SaveChanges();
        }

        public Task Get(Func<Task, bool> filter)
        {
            return db.Tasks.Find(filter);
        }

        public IEnumerable<Task> GetAll()
        {
            return db.Tasks;
        }

        public void Update(Task item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
