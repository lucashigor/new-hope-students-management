using System;
using System.Linq;
using System.Linq.Expressions;

namespace New.Hope.Application.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        T Create(T entity);
        T Update(T entity);

        void Delete(T entity);
        void Delete(int id);

        T GetById(int id);

        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Func<T, object> order);
        IQueryable<T> GetAllDecreasing(Func<T, object> order);

        void Reload(T entity);

        void Reload(T entity, Expression<Func<T, object>> attribute);
    }
}