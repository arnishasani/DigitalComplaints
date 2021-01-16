using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public  interface IVeprimet : IRepository<Veprimet>
    {
        IEnumerable<Veprimet> GetAllRequestList();
        IEnumerable<Veprimet> GetAllComplaintList();
        IEnumerable<Veprimet> GetAllAnonymousComplaintList();
        bool DeleteKerkese(Veprimet model);
        bool UpdateKerkese(Veprimet model);
    }
}
