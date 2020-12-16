﻿using ApplicationCore.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Management.Models;

namespace Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class SherbimeStudentoreController : Controller
    {
        private readonly ISherbimeStudentore _sherbimeStudentoreRepository;
        private readonly ILlojetDepartamenteve _llojetDepartamenveRepository;
        private readonly IMenaxhimiK _llojetEKerkesaveRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public SherbimeStudentoreController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ISherbimeStudentore sherbimeStudentore, IMenaxhimiK llojetEKerkesave, ILlojetDepartamenteve llojetDepartamenve, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _sherbimeStudentoreRepository = sherbimeStudentore;
            _llojetEKerkesaveRepository = llojetEKerkesave;
            _llojetDepartamenveRepository = llojetDepartamenve;
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            var model = new SherbimeStudentoreKerkesatViewModel();
            try
            {
                var menaxhoKerkesenList = new List<SherbimeStudentoreKerkesatViewModel>();
               // var menaxhoAnkesenList = new List<SherbimeStudentoreKerkesatViewModel>();
               // var menaxhoAnkesatAnonimeList = new List<SherbimeStudentoreKerkesatViewModel>();
                var modelGetAllRequest = _sherbimeStudentoreRepository.GetAllRequestList();
              //  var modelGetAllComplaint = _sherbimeStudentoreRepository.GetAllComplaintList();
               // var modelGetAllAnonymousComplaint = _sherbimeStudentoreRepository.GetAllAnonymousComplaintList();
                foreach (var item in modelGetAllRequest)
                {
                    int tempDep = (int)item.DepartamentiId;
                    var gjejeDepartamentin = _llojetDepartamenveRepository.GetById(tempDep);
                    int temp = (int)item.LlojiKerkeses;
                    var gjejLlojinKerkeses = _llojetEKerkesaveRepository.GetById(temp);
                    menaxhoKerkesenList.Add(new SherbimeStudentoreKerkesatViewModel
                    {
                        KerkesaAnkesaId = item.KerkesaAnkesaId,
                      //  UserId = r,
                        LlojiKerkeses = gjejLlojinKerkeses.LlojiIkerkeses,
                        Departamenti = gjejeDepartamentin.EmriDepartamentit,
                        Nenshkrimi = item.Nenshkrimi,
                        PershkrimiIkerkeses = item.PershkrimiIkerkeses,
                        IsActive = item.IsActive,
                        IsDeleted = item.IsDeleted,
                        IsAnonim = item.IsAnonim,
                        AnonimId = item.AnonimId,
                        Ankes = item.Ankes,
                        InsertBy = item.InsertBy,
                        InsertDate = item.InsertDate,
                        Lub = item.Lub,
                        Lud = item.Lud,
                        Lun = item.Lun
                    });
                }
                //foreach (var item in modelGetAllComplaint)
                //{
                //    int tempDep = (int)item.DepartamentiId;
                //    var gjejeDepartamentin = _llojetDepartamenveRepository.GetById(tempDep);
                //    int temp = (int)item.LlojiKerkeses;
                //    var gjejLlojinKerkeses = _llojetEKerkesaveRepository.GetById(temp);
                //    menaxhoAnkesenList.Add(new SherbimeStudentoreKerkesatViewModel
                //    {
                //        KerkesaAnkesaId = item.KerkesaAnkesaId,
                //        UserId = item.UserId,
                //        LlojiKerkeses = gjejLlojinKerkeses.LlojiIkerkeses,
                //        Departamenti = gjejeDepartamentin.EmriDepartamentit,
                //        Nenshkrimi = item.Nenshkrimi,
                //        PershkrimiIkerkeses = item.PershkrimiIkerkeses,
                //        IsActive = item.IsActive,
                //        IsDeleted = item.IsDeleted,
                //        InsertBy = item.InsertBy,
                //        InsertDate = item.InsertDate,
                //        Lub = item.Lub,
                //        Lud = item.Lud,
                //        Lun = item.Lun
                //    });
                //}
                //foreach (var item in modelGetAllAnonymousComplaint)
                //{
                //    int tempDep = (int)item.DepartamentiId;
                //    var gjejeDepartamentin = _llojetDepartamenveRepository.GetById(tempDep);
                //    int temp = (int)item.LlojiKerkeses;
                //    var gjejLlojinKerkeses = _llojetEKerkesaveRepository.GetById(temp);
                //    menaxhoAnkesatAnonimeList.Add(new SherbimeStudentoreKerkesatViewModel
                //    {
                //        KerkesaAnkesaId = item.KerkesaAnkesaId,
                //        AnonimId = item.AnonimId,
                //        IsAnonim = item.IsAnonim,
                //        LlojiKerkeses = gjejLlojinKerkeses.LlojiIkerkeses,
                //        Departamenti = gjejeDepartamentin.EmriDepartamentit,
                //        Nenshkrimi = item.Nenshkrimi,
                //        PershkrimiIkerkeses = item.PershkrimiIkerkeses,
                //        IsActive = item.IsActive,
                //        IsDeleted = item.IsDeleted,
                //        InsertBy = item.InsertBy,
                //        InsertDate = item.InsertDate,
                //        Lub = item.Lub,
                //        Lud = item.Lud,
                //        Lun = item.Lun
                //    });
                //}
                model.sherbimeStudentoreKerkesaList = menaxhoKerkesenList;
                //model.sherbimeStudentoreAnkesaList = menaxhoAnkesenList;
                //model.sherbimeStudentoreAnkesatAnonimeList = menaxhoAnkesatAnonimeList;
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult KerkesatNeShqyrtim()
        {
            return View();
        }

        public IActionResult KerkesatEPerfunduara()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            try
            {
                var kerkesA = _sherbimeStudentoreRepository.GetById(id);
                int tempDep = (int)kerkesA.DepartamentiId;
                var gjejeDepartamentin = _llojetDepartamenveRepository.GetById(tempDep);
                int temp = (int)kerkesA.LlojiKerkeses;
                var gjejLlojinKerkeses = _llojetEKerkesaveRepository.GetById(temp);
               // var tempUser = _userRepository.GetByStringId(kerkesA.InsertBy);
                var vm = new SherbimeStudentoreKerkesatViewModel()
                {
                    KerkesaAnkesaId = kerkesA.KerkesaAnkesaId,
                    LlojiKerkeses = gjejLlojinKerkeses.LlojiIkerkeses,
                    Departamenti = gjejeDepartamentin.EmriDepartamentit,
                    Nenshkrimi = kerkesA.Nenshkrimi,
                    PershkrimiIkerkeses = kerkesA.PershkrimiIkerkeses,
                    IsActive = kerkesA.IsActive,
                    IsDeleted = kerkesA.IsDeleted,
                    IsAnonim = kerkesA.IsAnonim,
                    AnonimId = kerkesA.AnonimId,
                    Ankes = kerkesA.Ankes,
                    InsertBy = kerkesA.InsertBy,
                    InsertDate = kerkesA.InsertDate,
                    Lub = kerkesA.Lub,
                    Lud = kerkesA.Lud,
                    Lun = kerkesA.Lun
                };
                return View(vm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
