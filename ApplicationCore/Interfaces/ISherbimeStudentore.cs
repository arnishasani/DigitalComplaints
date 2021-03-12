using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface ISherbimeStudentore : IRepository<Kerkesat>
    {
        IEnumerable<Kerkesat> GetAllRequestList();
        IEnumerable<Kerkesat> GetAllCompletedRequest();
        IEnumerable<Veprimet> GetAllRequestsForShk();
        IEnumerable<Veprimet> GetAllRequestsForEk();
        IEnumerable<Veprimet> GetVeprimID(int kerkesaID);
        IEnumerable<Kerkesat> GetAllAnonymousComplaintList();
        bool DeleteKerkese(Kerkesat model);
        bool UpdateKerkese(Kerkesat model);
    }
}
