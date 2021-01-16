using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class RoleRepository : Repository<AspNetRoles>, IRole
    {
        protected readonly ApplicationDBContext _digitalComplaintsDB;

        public RoleRepository(ApplicationDBContext digitalComplaintsDB) : base(digitalComplaintsDB)
        {
            _digitalComplaintsDB = digitalComplaintsDB;
        }

        public IEnumerable<AspNetRoles> GetRole(string id)
        {
            try
            {
                var temp = _digitalComplaintsDB.AspNetRoles.Where(x => x.Id == id).ToList();
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
