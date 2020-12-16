using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class SherbimeStudentoreRepository : Repository<Kerkesat>, ISherbimeStudentore
    {
        protected readonly ApplicationDBContext _digitalComplaintsDB;

        public SherbimeStudentoreRepository(ApplicationDBContext digitalComplaintsDB) : base(digitalComplaintsDB)
        {
            _digitalComplaintsDB = digitalComplaintsDB;
        }

        public bool DeleteKerkese(Kerkesat model)
        {
            _digitalComplaintsDB.Entry(model).State = EntityState.Modified;
            return _digitalComplaintsDB.SaveChanges() > 0;
        }

        public IEnumerable<Kerkesat> GetAllAnonymousComplaintList()
        {
            try
            {
                var temp = _digitalComplaintsDB.Kerkesat.Where(x => x.Ankes == true && x.IsAnonim == true && x.IsActive == true && x.IsDeleted == false).ToList();
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Kerkesat> GetAllComplaintList()
        {
            try
            {
                var temp = _digitalComplaintsDB.Kerkesat.Where(x => x.IsDeleted == false && x.IsActive == true && x.Ankes == true && x.IsAnonim == false).ToList();
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Kerkesat> GetAllRequestList()
        {
            try
            {
                //var temp = _digitalComplaintsDB.Kerkesat.Where(x => x.IsDeleted == false && x.IsActive == true && x.Ankes == false && x.IsAnonim == false).ToList();
                var temp = _digitalComplaintsDB.Kerkesat.Where(x => x.Pranuar == false && x.IsDeleted == false && x.IsActive == true).ToList();
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateKerkese(Kerkesat model)
        {
            throw new NotImplementedException();
        }
    }
}
