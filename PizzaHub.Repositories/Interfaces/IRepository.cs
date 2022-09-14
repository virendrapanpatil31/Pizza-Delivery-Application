using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHub.Repositories.Interfaces
{
    //Creating Generic Repository
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Find(object Id);//object is base type in C#
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Delete(object Id);
        int SaveChanges();
    }
}
