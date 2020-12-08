﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entity);
        T GetById(string id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicte, params Expression<Func<T, object>>[] includes);
        T FindOne(Expression<Func<T, bool>> predicte);
        int SaveChanges();
    }
}
