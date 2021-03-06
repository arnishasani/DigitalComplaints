﻿using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TblKerkesatAnkesatRepository : Repository<ApplicationCore.Entities.Kerkesat>, IKerkesat
    {
        protected readonly ApplicationDBContext _digitalComplaintsDB;

        public TblKerkesatAnkesatRepository(ApplicationDBContext digitalComplaintsDB) : base(digitalComplaintsDB)
        {
            _digitalComplaintsDB = digitalComplaintsDB;
        }
        public bool AddException(string controller, string action, string exceptionMessage, string comment)
        {
            throw new NotImplementedException();
        }

        public bool DeleteKerkese(Kerkesat model)
        {
            throw new NotImplementedException();
        }

        public List<Kerkesat> GetAllKerkesa()
        {
            throw new NotImplementedException();
        }
        public List<Kerkesat> GetAllAnkesa()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Kerkesat> GetAllList(string id)
        {
            try
            {
                var temp = _digitalComplaintsDB.Kerkesat.Where(x => x.UserId == id && x.IsActive == true && x.IsDeleted == false).ToList();
                return temp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Savekerkese(Kerkesat model)
        {
            throw new NotImplementedException();
        }
        public bool SaveAnkese(Kerkesat model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Kerkesat> GetAllComplaintList(string id)
        {
            try
            {
                var temp = _digitalComplaintsDB.Kerkesat.Where(x => x.IsDeleted == false && x.IsActive == true && x.Ankes == true && x.IsAnonim == false && x.UserId == id).ToList();
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
