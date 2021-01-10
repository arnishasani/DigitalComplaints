using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IRole : IRepository<AspNetRoles>
    {
        IEnumerable<AspNetRoles> GetRole(string id);
    }
}
