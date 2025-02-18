﻿using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepositories<T> : IRepositoryDal<T> where T : class
    {

        Context c = new Context();
        DbSet<T> _object;

        public GenericRepositories()
        {
            _object = c.Set<T>();
        }
        public void Delete(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            //_object.Add(p);
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

        public void Update(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
