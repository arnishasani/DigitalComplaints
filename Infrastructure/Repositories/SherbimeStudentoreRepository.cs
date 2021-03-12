using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class SherbimeStudentoreRepository : Repository<Kerkesat>, ISherbimeStudentore
    {
        protected readonly ApplicationDBContext _digitalComplaintsDB;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMenaxhimiK _llojetEKerkesaveRepository;
        public SherbimeStudentoreRepository(ApplicationDBContext digitalComplaintsDB, UserManager<ApplicationUser> userManager, IMenaxhimiK llojetEKerkesaveRepository) : base(digitalComplaintsDB)
        {
            _digitalComplaintsDB = digitalComplaintsDB;
            _userManager = userManager;
            _llojetEKerkesaveRepository = llojetEKerkesaveRepository;
        }

        public bool DeleteKerkese(Kerkesat model)
        {
            _digitalComplaintsDB.Entry(model).State = EntityState.Modified;
            return _digitalComplaintsDB.SaveChanges() > 0;
        }

        public IEnumerable<Kerkesat> GetAllAnonymousComplaintList()
        {
            try
            {
                var temp = _digitalComplaintsDB.Kerkesat.Where(x => x.Ankes == true && x.IsAnonim == true && x.IsActive == true && x.IsDeleted == false).ToList();
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Veprimet> GetAllRequestsForShk()
        {
            try
            {
                var model = _digitalComplaintsDB.Veprimet.Where(x => x.Perfunduar == false && x.SherbimeStudentore == true && x.DepShkenca == false && x.DepEkonomik == false && x.Sekretari == false && x.Rektorati == false && x.ZyraFinancave == false && x.ZyraIt == false && x.ZyraCilesis == false).ToList();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Veprimet> GetAllRequestsForEk()
        {
            var model = new Veprimet();
            var m = _digitalComplaintsDB.MenaxhimiKerkesaveRolet.Where(x => x.RoliId == "6").ToList();
            foreach (var asd in m)
            {
                var sm = _digitalComplaintsDB.Kerkesat.Where(x => x.LlojiKerkeses == asd.LlojiKerkesesId).ToList();
                foreach (var item in sm)
                {
                    var r = _digitalComplaintsDB.Veprimet.Where(x => x.KerkesaId == item.KerkesaAnkesaId && x.Perfunduar == false && x.SherbimeStudentore == true && x.DepShkenca == false && x.DepEkonomik == false && x.Sekretari == false && x.Rektorati == false && x.ZyraFinancave == false && x.ZyraIt == false && x.ZyraCilesis == false).ToList();
                    foreach (var items in r)
                    {
                        model = items;
                    }
                }
            }

            yield return model;
            //var model = _digitalComplaintsDB.Veprimet.Where(x => x.Perfunduar == false && x.SherbimeStudentore == true && x.DepShkenca == false && x.DepEkonomik == false && x.Sekretari == false && x.Rektorati == false && x.ZyraFinancave == false && x.ZyraIt == false && x.ZyraCilesis == false).ToList();
            //var gjejLlojin = new TblMenaxhimiKerkesave();
            //foreach (var item in model)
            //{
            //    var temp = _digitalComplaintsDB.Kerkesat.Where(x => x.KerkesaAnkesaId == item.KerkesaId).ToList();
            //    var llojiID = 0;
            //    foreach (var iss in temp)
            //    {
            //        llojiID = (int)iss.LlojiKerkeses;

            //    }
            //}
            //return model;
        }
        public IEnumerable<Kerkesat> GetAllRequestList()
        {
            try
            {
                //var temp = _digitalComplaintsDB.Kerkesat.Where(x => x.IsDeleted == false && x.IsActive == true && x.Ankes == false && x.IsAnonim == false).ToList();
                // var currentUser = _userManager.GetUserId(User);
                var temp = _digitalComplaintsDB.Kerkesat.Where(x => x.Pranuar == false && x.IsDeleted == false && x.IsActive == true).ToList();
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Kerkesat> GetAllCompletedRequest()
        {
            try
            {
                var temp = _digitalComplaintsDB.Veprimet.Where(x => x.Perfunduar == false && x.IsActive == true && x.IsDeleted == false).ToList();
                var model = new List<Kerkesat>();
                foreach (var item in temp)
                {
                    var mod = _digitalComplaintsDB.Kerkesat.Where(x => x.KerkesaAnkesaId == item.KerkesaId && x.Pranuar == true && x.IsDeleted == false).ToList();
                    foreach (var items in mod)
                    {
                        model.Add(new Kerkesat
                        {
                            KerkesaAnkesaId = items.KerkesaAnkesaId,
                            UserId = items.UserId,
                            LlojiKerkeses = items.LlojiKerkeses,
                            DepartamentiId = items.DepartamentiId,
                            Nenshkrimi = items.Nenshkrimi,
                            PershkrimiIkerkeses = items.PershkrimiIkerkeses,
                            IsActive = items.IsActive,
                            IsDeleted = items.IsDeleted,
                            IsAnonim = items.IsAnonim,
                            AnonimId = items.AnonimId,
                            InsertBy = items.InsertBy,
                            InsertDate = items.InsertDate,
                            Lub = items.Lub,
                            Lud = items.Lud,
                            Lun = items.Lun,
                            Ankes = items.Ankes,
                            Pranuar = items.Pranuar,
                        });
                    }
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateKerkese(Kerkesat model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Veprimet> GetVeprimID(int kerkesaID)
        {
            var model = _digitalComplaintsDB.Veprimet.Where(x => x.KerkesaId == kerkesaID && x.Perfunduar == false && x.SherbimeStudentore == true && x.DepShkenca == false && x.DepEkonomik == false && x.Sekretari == false && x.Rektorati == false && x.ZyraFinancave == false && x.ZyraIt == false && x.ZyraCilesis == false).ToList();
            return model;
        }
    }
}
