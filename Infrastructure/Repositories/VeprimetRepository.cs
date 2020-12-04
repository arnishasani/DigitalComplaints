using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class VeprimetRepository : Repository<Veprimet>, IVeprimet
    {
        protected readonly ApplicationDBContext _digitalComplaintsDB;

        public VeprimetRepository(ApplicationDBContext digitalComplaintsDB) : base(digitalComplaintsDB)
        {
            _digitalComplaintsDB = digitalComplaintsDB;
        }
    }
}
