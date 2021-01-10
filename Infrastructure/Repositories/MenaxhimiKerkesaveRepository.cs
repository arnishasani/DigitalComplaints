using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class MenaxhimiKerkesaveRepository : Repository<TblMenaxhimiKerkesave>, IMenaxhimiK
    {
        protected readonly ApplicationDBContext _digitalComplaintsDB;

        public MenaxhimiKerkesaveRepository(ApplicationDBContext digitalComplaintsDB) : base(digitalComplaintsDB)
        {
            _digitalComplaintsDB = digitalComplaintsDB;
        }

        public bool DeleteMenaxhim(TblMenaxhimiKerkesave model)
        {
            _digitalComplaintsDB.Entry(model).State = EntityState.Modified;
            return _digitalComplaintsDB.SaveChanges() > 0;
        }

        public IEnumerable<TblMenaxhimiKerkesave> GetAllList()
        {
            try
            {
                var temp = _digitalComplaintsDB.TblMenaxhimiKerkesave.Where(x => x.IsDeleted == false && x.IsActive == true).ToList();
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetMax()
        {
            try
            {
                var temp = _digitalComplaintsDB.TblMenaxhimiKerkesave.Max(u => u.MenaxhimiId);
                return temp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool UpdateMenaxhim(TblMenaxhimiKerkesave model)
        {
            throw new NotImplementedException();
        }
    }
}
