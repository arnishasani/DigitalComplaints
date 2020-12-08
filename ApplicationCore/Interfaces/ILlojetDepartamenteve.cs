using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface ILlojetDepartamenteve : IRepository<TblLlojetDepartamenteve>
    {
        IEnumerable<TblLlojetDepartamenteve> GetAllList();
        bool DeleteDepartament(TblLlojetDepartamenteve model);

        bool UpdateDepartament(TblLlojetDepartamenteve model);
    }
}
