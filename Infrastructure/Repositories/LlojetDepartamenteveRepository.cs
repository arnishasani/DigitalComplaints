using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class LlojetDepartamenteveRepository : Repository<TblLlojetDepartamenteve>, ILlojetDepartamenteve
    {
        protected readonly ApplicationDBContext _digitalComplaintsDB;

        public LlojetDepartamenteveRepository(ApplicationDBContext digitalComplaintsDB) : base(digitalComplaintsDB)
        {
            _digitalComplaintsDB = digitalComplaintsDB;
        }

        public bool DeleteDepartament(TblLlojetDepartamenteve model)
        {
            _digitalComplaintsDB.Entry(model).State = EntityState.Modified;
            return _digitalComplaintsDB.SaveChanges() > 0;
        }

        public IEnumerable<TblLlojetDepartamenteve> GetAllList()
        {
            try
            {
                var temp = _digitalComplaintsDB.TblLlojetDepartamenteve.Where(x=>x.IsDeleted == false && x.IsActive == true).ToList();
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateDepartament(TblLlojetDepartamenteve model)
        {
            throw new NotImplementedException();
        }
    }
}
