using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class StudentRepository : Repository<AspNetUsers>, IStudent
    {
        protected readonly ApplicationDBContext _digitalComplaintsDB;

        public StudentRepository(ApplicationDBContext digitalComplaintsDB) : base(digitalComplaintsDB)
        {
            _digitalComplaintsDB = digitalComplaintsDB;
        }

        public bool DeleteStudent(AspNetUsers model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AspNetUsers> GetAllStudentList()
        {
            try
            {
            //    var temp = _digitalComplaintsDB.AspNetUserRoles.Where(x => x.RoleId == "3").Select(x => x.User).Where(x => x.IsDeleted == false || x.IsActive == true).ToList();
                //var r = _digitalComplaintsDB.TblDepartamentet.Where(x=>x.DepartamentiId == 2).Select(x=>x.)
                var studentShkenca = _digitalComplaintsDB.UsersDepartments.Where(x => x.DepartamentiId == 1).Select(x => x.User).Where(x => x.IsDeleted == false && x.IsActive == true);
                return studentShkenca;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateStudent(AspNetUsers model)
        {
            throw new NotImplementedException();
        }
    }
}
