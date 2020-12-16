using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<AspNetUsers>, IUserRepository
    {
        protected readonly ApplicationDBContext _digitalComplaintsDB;

        public UserRepository(ApplicationDBContext digitalComplaintsDB) : base(digitalComplaintsDB)
        {
            _digitalComplaintsDB = digitalComplaintsDB;
        }
        public AspNetUsers GetByStringId(string id)
        {
            try
            {
                var finduser = _digitalComplaintsDB.AspNetUsers.Find(id);
                return _digitalComplaintsDB.AspNetUsers.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //public IEnumerable<string> GetUserRoles(string id)
        //{
        //    try
        //    {
        //        try
        //        {
        //            return _digitalComplaintsDB.AspNetUsers.Include(p => p.AspNetUserRoles).ThenInclude(u => u.Role).FirstOrDefault(p => p.Id == id).AspNetUserRoles.Where(x => x.IsActive == true).Select(p => p.Role.Name);
        //        }
        //        catch
        //        {
        //            //To do: 1K
        //            return null;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }

        //}
        //public IEnumerable<string> GetUserRoleIds(string id)
        //{
        //    try
        //    {
        //        try
        //        {
        //            return _digitalComplaintsDB.AspNetUsers.Include(p => p.AspNetUserRoles).ThenInclude(u => u.Role).FirstOrDefault(p => p.Id == id).AspNetUserRoles.Where(x => x.IsActive == true).Select(p => p.Role.Id);
        //        }
        //        catch
        //        {
        //            //To do: 1K
        //            return null;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}

        //public AspNetUserRoles GetUserRole(string id)
        //{
        //    try
        //    {
        //        var roles = _digitalComplaintsDB.AspNetUserRoles.Include(y => y.Role).Where(x => x.UserId == id && x.IsActive != false).ToList();
        //        AspNetUserRoles role;
        //        if (roles.Count > 1)
        //        {
        //            role = roles[roles.Count - 1];
        //        }
        //        else
        //        {
        //            role = roles[0];
        //        }
        //        if (role != null)
        //        {
        //            return role;
        //        }
        //        else
        //        {
        //            return _digitalComplaintsDB.AspNetUserRoles.Include(y => y.Role).Where(x => x.RoleId == "2" && x.IsActive != false).FirstOrDefault();
        //        }

        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }


        //}
        //public string GetUserRoleName(string id)
        //{
        //    try
        //    {
        //        var roles = _digitalComplaintsDB.AspNetUserRoles.Include(y => y.Role).Where(x => x.UserId == id && x.IsActive != false).ToList();
        //        string role = "";
        //        if (roles.Count > 1)
        //        {
        //            foreach (var item in roles)
        //            {
        //                role += item.Role.Name + ", ";
        //            }
        //            role = role.Substring(0, role.Length - 2);
        //        }
        //        else
        //        {
        //            role = roles[0].Role.Name;
        //        }
        //        if (role != null)
        //        {
        //            return role;
        //        }
        //        else
        //        {
        //            return _digitalComplaintsDB.AspNetUserRoles.Include(y => y.Role).Where(x => x.RoleId == "2" && x.IsActive != false).FirstOrDefault().Role.Name;
        //        }

        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }


        //}
        //public AspNetRoles GetRole(string id)
        //{
        //    try
        //    {
        //        var role = _digitalComplaintsDB.AspNetUserRoles.Include(y => y.Role).Where(x => x.UserId == id && x.IsActive != false).Select(x => x.Role).FirstOrDefault();
        //        //var role = _digitalComplaintsDB.AspNetUserRoles.Include(y => y.Role).Where(x => x.UserId == id && x.IsActive != false).FirstOrDefault();
        //        if (role != null)
        //        {
        //            return role;
        //        }
        //        else
        //        {
        //            return _digitalComplaintsDB.AspNetUserRoles.Include(y => y.Role).Where(x => x.UserId == "2" && x.IsActive != false).Select(x => x.Role).FirstOrDefault();
        //        }

        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }


        //}
        //public AspNetRoles GetUserASPRole(string id)
        //{
        //    try
        //    {
        //        var role = _digitalComplaintsDB.AspNetUserRoles.Include(x => x.Role).FirstOrDefault(x => x.UserId == id && x.IsActive != false);

        //        if (role != null)
        //        {
        //            return _digitalComplaintsDB.AspNetUserRoles.Include(x => x.Role).FirstOrDefault(x => x.UserId == id && x.IsActive != false).Role;
        //        }
        //        else
        //        {
        //            return _digitalComplaintsDB.AspNetUserRoles.Include(x => x.Role).FirstOrDefault(x => x.RoleId == "2").Role;
        //        }

        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public int CountUsersByRole(string roleId)
        //{
        //    try
        //    {
        //        return _digitalComplaintsDB.AspNetUserRoles.Where(r => r.RoleId == roleId).Count();
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public IEnumerable<AspNetUsers> GetOnlineCustomers()
        //{
        //    try
        //    {
        //        return _digitalComplaintsDB.AspNetUsers.Where(r => r.AspNetUserRoles.FirstOrDefault().RoleId == "2" && r.IsActive == true && r.IsDeleted != true).Include(c => c.AspNetUserRoles);
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public int CountOrdersByUser(string userId)
        //{
        //    try
        //    {
        //        return _digitalComplaintsDB.Orders.Where(x => x.CustomerId == userId && x.IsDeleted == false).Count();
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public IEnumerable<AspNetUsers> GetAllCustomers()
        //{
        //    try
        //    {
        //        return _digitalComplaintsDB.AspNetUsers.Where(x => x.IsActive == true && x.IsDeleted != true).Include(s => s.AspNetUserRoles);
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public IEnumerable<AspNetUsers> GetAllClients()
        //{
        //    try
        //    {
        //        return _digitalComplaintsDB.AspNetUserRoles.Where(x => x.RoleId == "2").Select(x => x.User).Where(x => x.IsActive == true && x.IsDeleted == false && x.CreateOnDate <= DateTime.Now && x.CreateOnDate > DateTime.Now.AddMonths(-1));
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public IEnumerable<AspNetUsers> GetAllManageCustomers()
        //{
        //    try
        //    {
        //        return _digitalComplaintsDB.AspNetUsers.Where(x => x.IsDeleted != true).Include(s => s.AspNetUserRoles);
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public (int, IEnumerable<AspNetUsers>) GetAllCustomers(int take, int skip, string query, int roleId)
        //{
        //    try
        //    {
        //        if (String.IsNullOrWhiteSpace(query))
        //        {
        //            //var selectQuery = _digitalComplaintsDB.AspNetUsers.Where(x => x.IsDeleted != true && x.AspNetUserRoles.All(a => a.RoleId != "0" && a.RoleId != "1" && a.RoleId != "3" && a.RoleId != "4" && a.IsActive == true) && (roleId == null || x.AspNetUserRoles.Any(a => a.RoleId == roleId && a.IsActive == true)));                    
        //            //var selectQuery2 = _digitalComplaintsDB.AspNetUsers.Where(x => x.IsDeleted != true && x.AspNetUserRoles.All(a => a.Role.IsStaffRole == false && a.IsActive == true) && (roleId == null || x.AspNetUserRoles.Any(a => a.RoleId == roleId && a.IsActive == true)));
        //            var linq = _digitalComplaintsDB.AspNetUserRoles.Where(x => x.Role.IsStaffRole == false && x.Role.IsActive == true).Select(x => x.User).Where(x => x.IsDeleted == false && x.IsActive == true && x.PriceListName.Id == roleId && x.PriceListName.IsActive == true && x.PriceListName.IsDeleted == false);

        //            var list = from user in _digitalComplaintsDB.AspNetUsers
        //                       join roles in _digitalComplaintsDB.PriceListName on user.PriceListNameId equals roles.Id
        //                       join userroles in _digitalComplaintsDB.AspNetUserRoles on user.Id equals userroles.UserId
        //                       where user.IsDeleted == false && roles.IsActive == true && userroles.Role.IsStaffRole == false
        //                       && ((roleId == 0 && user.Id == user.Id) || roles.Id == roleId)
        //                       select user;


        //            var count = list.Count();
        //            var res = list
        //                .OrderByDescending(c => c.CreateOnDate)
        //                .Skip(skip)
        //                .Take(take).AsEnumerable();
        //            return (count, res);

        //        }
        //        else
        //        {
        //            //var selectQuery = _digitalComplaintsDB.AspNetUsers.Where(x =>
        //            //    (x.Email.ToLower().Contains(query.ToLower()) ||
        //            //    x.Name.ToLower().Contains(query.ToLower()) ||
        //            //    x.Surname.ToLower().Contains(query.ToLower()) ||
        //            //    x.PhoneNumber.Contains(query.ToLower())) &&
        //            //    x.IsDeleted != true &&
        //            //    x.AspNetUserRoles.All(a => a.RoleId != "0" && a.RoleId != "1" && a.RoleId != "3" && a.RoleId != "4" && a.IsActive == true) && (roleId == null || x.AspNetUserRoles.Any(a => a.RoleId == roleId && a.IsActive == true)));
        //            IQueryable<AspNetUsers> selectQuery2 = null;

        //            if (roleId == 0)
        //            {
        //                selectQuery2 = _digitalComplaintsDB.AspNetUsers.Where(x =>
        //                (x.Email.ToLower().Contains(query.Trim().ToLower()) ||
        //                x.Name.ToLower().Contains(query.Trim().ToLower()) ||
        //                x.Surname.ToLower().Contains(query.Trim().ToLower()) ||
        //                x.PhoneNumber.Contains(query.Trim().ToLower())) &&
        //                x.IsDeleted != true &&
        //                x.PriceListName.IsActive == true && x.AspNetUserRoles.All(a => a.Role.IsStaffRole == false));
        //            }
        //            else
        //            {
        //                selectQuery2 = _digitalComplaintsDB.AspNetUsers.Where(x =>
        //                (x.Email.ToLower().Contains(query.ToLower()) ||
        //                x.Name.ToLower().Contains(query.ToLower()) ||
        //                x.Surname.ToLower().Contains(query.ToLower()) ||
        //                x.PhoneNumber.Contains(query.ToLower())) &&
        //                x.IsDeleted != true &&
        //                x.PriceListName.IsActive == true && x.PriceListName.Id == roleId
        //                && !(x.AspNetUserRoles.Any(a => a.Role.IsStaffRole == true)));
        //            }

        //            //x.AspNetUserRoles.All(a => a.Role.IsStaffRole == false && a.IsActive == true) && (roleId == null || x.AspNetUserRoles.Any(a => a.RoleId == roleId && a.IsActive == true)));

        //            var count = selectQuery2.Count();
        //            var res = selectQuery2
        //                .OrderByDescending(c => c.CreateOnDate)
        //                .Skip(skip)
        //                .Take(take).AsEnumerable();
        //            return (count, res);

        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public (int, IEnumerable<AspNetUsers>) GetAllStaff(int take, int skip, bool takeSuperAdmin, string query, string roleId)
        //{
        //    try
        //    {
        //        if (String.IsNullOrWhiteSpace(query))
        //        {
        //            if (takeSuperAdmin)
        //            {
        //                var selectQuery = _digitalComplaintsDB.AspNetUsers
        //                    .Where(x => x.IsDeleted != true && x.AspNetUserRoles.Any(a => a.Role.IsStaffRole == true && a.IsActive == true) && (roleId == null || x.AspNetUserRoles.Any(a => a.RoleId == roleId && a.IsActive == true)));

        //                //var selectQuery = _digitalComplaintsDB.AspNetUsers
        //                //    .Where(x => x.IsDeleted != true && x.IsActive == true);
        //                //var selectQuery = _digitalComplaintsDB.AspNetUserRoles.Where(x => x.Role.Id == roleId && x.Role.IsActive == true && x.Role.IsDeleted == false && x.Role.IsStaffRole == true).Select(x => x.User).Where(x => x.IsDeleted == false && x.IsActive == true);

        //                var count = selectQuery.Count();
        //                var res = selectQuery
        //                    .OrderByDescending(c => c.CreateOnDate)
        //                    .Skip(skip)
        //                    .Take(take).AsEnumerable();
        //                return (count, res);
        //            }
        //            else
        //            {
        //                var selectQuery = _digitalComplaintsDB.AspNetUsers
        //                    .Where(x => x.IsDeleted != true && x.AspNetUserRoles.Any(a => a.Role.IsStaffRole == true && a.RoleId != "0" && a.IsActive == true && a.IsActive == true) && (roleId == null || x.AspNetUserRoles.Any(a => a.RoleId == roleId && a.IsActive == true)));
        //                var count = selectQuery.Count();
        //                var res = selectQuery
        //                    .OrderByDescending(c => c.CreateOnDate)
        //                    .Skip(skip)
        //                    .Take(take).AsEnumerable();
        //                return (count, res);
        //            }

        //        }
        //        else
        //        {
        //            if (takeSuperAdmin)
        //            {
        //                var selectQuery = _digitalComplaintsDB.AspNetUsers.Where(x =>
        //                    (x.Email.ToLower().Contains(query.Trim().ToLower()) ||
        //                    x.Name.ToLower().Contains(query.Trim().ToLower()) ||
        //                    x.Surname.ToLower().Contains(query.Trim().ToLower()) ||
        //                    x.PhoneNumber.Contains(query.Trim().ToLower())) &&
        //                    x.IsDeleted != true &&
        //                    x.AspNetUserRoles.Any(a => a.Role.IsStaffRole == true && a.IsActive == true) && (roleId == null || x.AspNetUserRoles.Any(a => a.RoleId == roleId && a.IsActive == true)));

        //                var count = selectQuery.Count();
        //                var res = selectQuery
        //                    .OrderByDescending(c => c.CreateOnDate)
        //                    .Skip(skip)
        //                    .Take(take).AsEnumerable();

        //                return (count, res);
        //            }
        //            else
        //            {

        //                var selectQuery = _digitalComplaintsDB.AspNetUsers.Where(x =>
        //                    (x.Email.ToLower().Contains(query.Trim().ToLower()) ||
        //                    x.Name.ToLower().Contains(query.Trim().ToLower()) ||
        //                    x.Surname.ToLower().Contains(query.Trim().ToLower()) ||
        //                    x.PhoneNumber.Contains(query.Trim().ToLower())) &&
        //                    x.IsDeleted != true &&
        //                    x.AspNetUserRoles.Any(a => a.Role.IsStaffRole == true && a.RoleId != "0" && a.IsActive == true && a.IsActive == true) && (roleId == null || x.AspNetUserRoles.Any(a => a.RoleId == roleId && a.IsActive == true)));

        //                var count = selectQuery.Count();
        //                var res = selectQuery
        //                    .OrderByDescending(c => c.CreateOnDate)
        //                    .Skip(skip)
        //                    .Take(take).AsEnumerable();

        //                return (count, res);
        //            }

        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public IEnumerable<AspNetUsers> GetCustomersByWeek()
        //{
        //    try
        //    {
        //        var start = DateTime.Now.AddDays(-(double)DateTime.Now.DayOfWeek);
        //        return _digitalComplaintsDB.AspNetUserRoles.Where(x => x.RoleId == "2").Select(x => x.User).Where(o => o.CreateOnDate >= start).OrderBy(o => o.CreateOnDate);
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public IEnumerable<AspNetUsers> GetCustomersByMonth()
        //{
        //    try
        //    {
        //        var start = DateTime.Now.AddDays(-(double)DateTime.Now.DayOfWeek);
        //        return _digitalComplaintsDB.AspNetUserRoles.Where(x => x.RoleId == "2").Select(x => x.User).Where(o => (DateTime)o.CreateOnDate >= start).OrderBy(o => o.CreateOnDate);
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public IEnumerable<AspNetUsers> GetCustomersByYears()
        //{
        //    try
        //    {
        //        var start = DateTime.Now.AddDays(-(double)DateTime.Now.DayOfWeek);
        //        return _digitalComplaintsDB.AspNetUserRoles.Where(x => x.RoleId == "2").Select(x => x.User).Where(o => o.CreateOnDate >= start).OrderBy(o => o.CreateOnDate);
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public string CustomerRegisteredBy(string userId)
        //{
        //    try
        //    {
        //        var user = _digitalComplaintsDB.AspNetUsers.Where(u => u.Id == userId).FirstOrDefault();
        //        if (user == null)
        //        {
        //            return $"user_doesnt_exist@appdec.com";
        //        }
        //        else
        //        {
        //            return user.Email;
        //        }
        //        //var userRole = _digitalComplaintsDB.AspNetUserRoles.Where(u => u.UserId == user.CreateByUserId && u.IsActive != false).FirstOrDefault();

        //        //var role = _digitalComplaintsDB.AspNetRoles.Where(r => r.Id == userRole.RoleId).FirstOrDefault();

        //        ////if (role.Name == "Admin")
        //        ////{
        //        ////    return "Admin";
        //        ////}
        //        ////else if (role.Name == "Salesman")
        //        ////{
        //        ////    return "Salesman";
        //        ////}
        //        ////else
        //        ////{

        //        //}
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}

        //public void RemoveAllRoles(string userId)
        //{
        //    try
        //    {
        //        var user = _digitalComplaintsDB.AspNetUsers.Where(u => u.Id == userId).FirstOrDefault();
        //        var userrole = _digitalComplaintsDB.AspNetUserRoles.Where(x => x.UserId == userId);
        //        _digitalComplaintsDB.AspNetUserRoles.RemoveRange(userrole);
        //        _digitalComplaintsDB.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}


    }
}
