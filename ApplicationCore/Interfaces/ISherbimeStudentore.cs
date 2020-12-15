using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface ISherbimeStudentore : IRepository<Kerkesat>
    {
        IEnumerable<Kerkesat> GetAllRequestList();
        IEnumerable<Kerkesat> GetAllComplaintList();
        IEnumerable<Kerkesat> GetAllAnonymousComplaintList();
        bool DeleteKerkese(Kerkesat model);

        bool UpdateKerkese(Kerkesat model);
    }
}
