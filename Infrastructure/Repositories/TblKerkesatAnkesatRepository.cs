using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TblKerkesatAnkesatRepository : Repository<ApplicationCore.Entities.Kerkesat>, ApplicationCore.Interfaces.Kerkesat
    {
        protected readonly ApplicationDBContext _cineflexxContext;

        public TblKerkesatAnkesatRepository(ApplicationDBContext movieContext) : base(movieContext)
        {
            _cineflexxContext = movieContext;
        }
    }
}
