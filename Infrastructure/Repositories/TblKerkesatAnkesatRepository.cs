using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TblKerkesatAnkesatRepository : Repository<TblKerkesatAnkesat>, ITblKerkesatAnkesatRepository
    {
        protected readonly ApplicationDBContext _cineflexxContext;

        public TblKerkesatAnkesatRepository(ApplicationDBContext movieContext) : base(movieContext)
        {
            _cineflexxContext = movieContext;
        }
    }
}
