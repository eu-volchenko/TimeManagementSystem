using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagementSystem.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(Func<T, bool> filter);

        void Create(T item);

        void Update(T item);

        void Delete(T item);
    }
}
