using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                var temp = _digitalComplaintsDB.Veprimet.Where(x => x.KerkesaId == model.KerkesaId);
                foreach (var item in temp)
                {
                    if (item.KerkesaId == model.KerkesaId)
                    {
                        _digitalComplaintsDB.Entry(model).State = EntityState.Modified;
                    }
                }
                return _digitalComplaintsDB.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
