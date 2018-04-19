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
    class PersonRepository : IRepository<Person>
    {
        MyDbContext db;
        public PersonRepository(MyDbContext db)
        {
            this.db = db;
        }
        public void Create(Person item)
        {
            db.People.Add(item);
            db.SaveChanges();
        }

        public void Delete(Person item)
        {
            db.People.Remove(item);
            db.SaveChanges();
        }

        public Person Get(Func<Person, bool> filter)
        {
            return db.People.Find(filter);
        }

        public IEnumerable<Person> GetAll()
        {
            return db.People;
        }

        public void Update(Person item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
