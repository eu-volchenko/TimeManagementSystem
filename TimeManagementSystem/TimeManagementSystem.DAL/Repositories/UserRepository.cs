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
    class UserRepository : IRepository<User>
    {
        MyDbContext _db;
        public UserRepository(MyDbContext _db)
        {
            this._db = _db;
        }
        public void Create(User item)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Users.Add(item);
                    var t = _db.Users.Where(x => x.Email == item.Email);
                    _db.People.Add(new Person()
                    {
                        User = t.FirstOrDefault(),
                        Email = item.Email,
                        Name = item.Name
                    });
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Delete(User item)
        {
            _db.Users.Remove(item);
            _db.SaveChanges();
        }

        public User Get(Func<User, bool> filter)
        {
            var a = _db.Users.Where(filter);
            return a.FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }

        public void Update(User item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
