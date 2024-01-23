using PizzaProject.Core.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Core.Tools
{
    public interface IDbTools<T> where T : DbContextCore
    {
        bool Add(T item);
        bool Update(T item);
        bool Delete(T item);
        bool Save();
        List<T> GetList();
        T GetRecord(int id);

    }
}
