using Microsoft.EntityFrameworkCore;
using PizzaProject.Core.Cores;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Model.Queries
{
    public class AdminQueries<T> : IDbTools<T> where T : DbContextCore
    {
        private readonly PizzaDbContext _db;
        public AdminQueries(PizzaDbContext dbContext)
        {
            _db = dbContext;
        }
        public bool Add(T item)
        {
            try
            {
                _db.Add(item);
                return Save();
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(T item)
        {
            try
            {
                _db.Update(item);
                return Save();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(T item)
        {
            try
            {
                _db.Remove(item);
                return Save();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<T> GetList() => _db.Set<T>().ToList();



        public T GetRecord(int id) => _db.Set<T>().Find(id);


        public bool Save() => _db.SaveChanges() > 0 ? true : false;
       
    }
}
