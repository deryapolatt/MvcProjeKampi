﻿using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c= new Context();
        DbSet<T> _object; // T değerine karşılık gelen sınıfı tutuyor

        public GenericRepository()
        {
              _object=c.Set<T>();
        }
        public void Delete(T entity)
        {
            _object.Remove(entity);
            c.SaveChanges();
        }

        public void Insert(T entity)
        {
            _object.Add(entity);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T entity)
        {
            c.SaveChanges();
        }
    }
}
