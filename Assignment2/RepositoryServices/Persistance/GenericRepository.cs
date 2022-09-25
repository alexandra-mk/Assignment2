using Assignment2.Context;
using Assignment2.RepositoryServices.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment2.RepositoryServices.Persistance
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ApplicationContext db;
        public DbSet<T> table;

        public GenericRepository(ApplicationContext context)
        {
            db = context;
            table = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
            Save();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
            Save();
        }

        public void Delete(T obj)
        {
            table.Remove(obj);
            db.Entry(obj).State = EntityState.Deleted;
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}