using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Areas.Management.Models;

namespace Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class VeprimetController : Controller
    {
        private readonly IVeprimet _veprimetRepository;
        private readonly IKerkesat _menaxhimiKerkesaveRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public VeprimetController(IVeprimet veprimetRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IKerkesat menaxhimiKerkesaveRepository)
        {
            _veprimetRepository = veprimetRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _menaxhimiKerkesaveRepository = menaxhimiKerkesaveRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddVeprim(int id)
        {
            VeprimetViewModel model = new VeprimetViewModel();
            model.KerkesaId = id;
            return View(model);
        }

        [HttpPost]
        public IActionResult AddVeprim(VeprimetViewModel model)
        {
            try
            {
                var currentUser = _userManager.GetUserId(User);
                if (!ModelState.IsValid)
                    return View(model);
                else
                {
                    Veprimet modelVeprimet = new Veprimet();
                    modelVeprimet.KerkesaId = model.KerkesaId;
                    modelVeprimet.Pranimi = model.Pranimi;
                    modelVeprimet.StafId = currentUser;
                    modelVeprimet.Vendimi = model.Vendimi;
                    modelVeprimet.Verifikimi = model.Verifikimi;
                    modelVeprimet.Miratimi = model.Miratimi;
                    modelVeprimet.InsertDate = DateTime.Now;
                    modelVeprimet.IsActive = true;
                    modelVeprimet.IsDeleted = false;
                    modelVeprimet.InsertBy = currentUser;
                    modelVeprimet.InsertDate = model.InsertDate;
                    _veprimetRepository.Add(modelVeprimet);
                    _veprimetRepository.SaveChanges();
                    Kerkesat mod = new Kerkesat();
                    int tempDep = (int)model.KerkesaId;
                    var kerkesauGjet =  _menaxhimiKerkesaveRepository.GetById(tempDep);
                    kerkesauGjet.Pranuar = true;
                    _menaxhimiKerkesaveRepository.Update(kerkesauGjet);
                    _menaxhimiKerkesaveRepository.SaveChanges();
                }
                return RedirectToAction(nameof(SherbimeStudentoreController.Index), "SherbimetStudentore", new { area = "Management" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
