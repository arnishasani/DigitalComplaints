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

        public bool DeleteKerkese(Veprimet model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Veprimet> GetAllAnonymousComplaintList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Veprimet> GetAllComplaintList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Veprimet> GetAllRequestList()
        {
            throw new NotImplementedException();
        }

        public bool UpdateKerkese(Veprimet model)
        {
            throw new NotImplementedException();
        }
    }
}
