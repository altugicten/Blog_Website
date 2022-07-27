using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IRepositoryDal<T>
    {
        List<T> List();


        T Get(Expression<Func<T, bool>> filter);

        void Insert(T p);
        void Delete(T p);
        void Update(T p);

        List<T> List(Expression<Func<T,bool>> filter);
    }
}
