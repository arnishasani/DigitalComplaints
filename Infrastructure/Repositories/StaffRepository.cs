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

        public IEnumerable<AspNetUsers> GetAllList()
        {
            try
            {
                var temp = _digitalComplaintsDB.AspNetUserRoles.Where(x => x.RoleId == "1" || x.RoleId == "2").Select(x => x.User).ToList();
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
