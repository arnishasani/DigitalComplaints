using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class StaffRepository : Repository<AspNetUsers>, IStaff
    {
        protected readonly ApplicationDBContext _digitalComplaintsDB;

        public StaffRepository(ApplicationDBContext digitalComplaintsDB) : base(digitalComplaintsDB)
        {
            _digitalComplaintsDB = digitalComplaintsDB;
        }

        public bool DeleteUser(AspNetUsers model)
        {
            _digitalComplaintsDB.Entry(model).State = EntityState.Modified;
            return _digitalComplaintsDB.SaveChanges() > 0;
        }

        public IEnumerable<AspNetUsers> GetAllList()
        {
            try
            {
                var temp = _digitalComplaintsDB.AspNetUserRoles.Where(x => x.RoleId == "1" || x.RoleId == "2" || x.RoleId == "4").Select(x => x.User).Where(x=>x.IsDeleted == false || x.IsDeleted == null).ToList();
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUser(AspNetUsers model)
        {
            _digitalComplaintsDB.Entry(model).State = EntityState.Modified;
            return _digitalComplaintsDB.SaveChanges() > 0;
        }
    }
}
