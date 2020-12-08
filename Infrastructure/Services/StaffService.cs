using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Services
{
    public class StaffService : IStaff
    {
        public void Add(AspNetUsers entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<AspNetUsers> entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(AspNetUsers model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AspNetUsers> Find(Expression<Func<AspNetUsers, bool>> predicte, params Expression<Func<AspNetUsers, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public AspNetUsers FindOne(Expression<Func<AspNetUsers, bool>> predicte)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AspNetUsers> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AspNetUsers> GetAllList()
        {
            throw new NotImplementedException();
        }

        public AspNetUsers GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(AspNetUsers entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<AspNetUsers> entity)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(AspNetUsers entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<AspNetUsers> entity)
        {
            throw new NotImplementedException();
        }
    }
}
