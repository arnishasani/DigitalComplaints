using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IKerkesat : IRepository<Entities.Kerkesat> {
        IEnumerable<Kerkesat> GetAllList(string id);
        IEnumerable<Kerkesat> GetAllComplaintList(string id);
        bool AddException(string controller, string action, string exceptionMessage, string comment);
        List<Kerkesat> GetAllKerkesa();
        bool Savekerkese(Kerkesat model);
        bool DeleteKerkese(Kerkesat model);
    }
}
