using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UsersRoleRepository : Repository<AspNetUserRoles>, IUsersRole
    {
        protected readonly ApplicationDBContext _digitalComplaintsDB;

        public UsersRoleRepository(ApplicationDBContext digitalComplaintsDB) : base(digitalComplaintsDB)
        {
            _digitalComplaintsDB = digitalComplaintsDB;
        }

        public IEnumerable<AspNetUserRoles> GetRoleByUserId(string id)
        {
            try
            {
                var temp = _digitalComplaintsDB.AspNetUserRoles.Where(x => x.UserId == id).ToList();
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
