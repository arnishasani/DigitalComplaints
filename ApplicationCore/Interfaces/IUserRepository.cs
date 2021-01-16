using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IUserRepository : IRepository<AspNetUsers>
    {
        //IEnumerable<string> GetUserRoles(string id);
        AspNetUsers GetByStringId(string id);
        AspNetUserRoles GetUserRole(string id);
        //int CountUsersByRole(string roleId);
        //IEnumerable<AspNetUsers> GetOnlineCustomers();
        //int CountOrdersByUser(string userId);
        //IEnumerable<AspNetUsers> GetAllCustomers();
        //IEnumerable<AspNetUsers> GetAllManageCustomers();

        //(int, IEnumerable<AspNetUsers>) GetAllCustomers(int take, int skip, string query, int roleId);
        //(int, IEnumerable<AspNetUsers>) GetAllStaff(int take, int skip, bool takeSuperAdmin, string query, string roleId);
        //AspNetRoles GetUserASPRole(string id);

        //IEnumerable<AspNetUsers> GetCustomersByWeek();
        //IEnumerable<AspNetUsers> GetCustomersByMonth();
        //IEnumerable<AspNetUsers> GetCustomersByYears();
        //IEnumerable<string> GetUserRoleIds(string id);
        //string CustomerRegisteredBy(string userId);
        //void RemoveAllRoles(string userId);
        //string GetUserRoleName(string id);
        //IEnumerable<AspNetUsers> GetAllClients();
    }
}
