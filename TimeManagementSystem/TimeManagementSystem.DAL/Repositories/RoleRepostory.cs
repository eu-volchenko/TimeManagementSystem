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
    class RoleRepostory : IRepository<Role>
    {
        MyDbContext db;
        public RoleRepostory(MyDbContext db)
        {
            this.db = db;
        }
        public void Create(Role item)
        {
            db.Roles.Add(item);
            db.SaveChanges();

        }

        public void Delete(Role item)
        {
            db.Roles.Remove(item);
            db.SaveChanges();
        }

        public Role Get(Func<Role, bool> filter)
        {
            return db.Roles.Find(filter);
        }

        public IEnumerable<Role> GetAll()
        {
            return db.Roles;
        }

        public void Update(Role item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
