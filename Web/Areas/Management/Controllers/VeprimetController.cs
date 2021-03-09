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
        private readonly ISherbimeStudentore _sherbimetStudentore;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public VeprimetController(IVeprimet veprimetRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IKerkesat menaxhimiKerkesaveRepository, ISherbimeStudentore sherbimetStudentore)
        {
            _veprimetRepository = veprimetRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _menaxhimiKerkesaveRepository = menaxhimiKerkesaveRepository;
            _sherbimetStudentore = sherbimetStudentore;
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
                var pranuar = true;
                var currentUser = _userManager.GetUserId(User);
                if (!ModelState.IsValid)
                    return View(model);
                else
                {
                    if (User.IsInRole("SherbimeStudentore"))
                    {
                        Veprimet modelVeprimet = new Veprimet();
                        modelVeprimet.KerkesaId = model.KerkesaId;
                        modelVeprimet.Pranimi = pranuar;
                        modelVeprimet.StafId = currentUser;
                        //modelVeprimet.Vendimi = vendimi;
                        //modelVeprimet.Verifikimi = verifikuar;
                        //modelVeprimet.Miratimi = miratuar;
                        modelVeprimet.InsertDate = DateTime.Now;
                        modelVeprimet.SherbimeStudentore = true;
                        modelVeprimet.DepShkenca = false;
                        modelVeprimet.DepEkonomik = false;
                        modelVeprimet.Sekretari = false;
                        modelVeprimet.Rektorati = false;
                        modelVeprimet.ZyraIt = false;
                        modelVeprimet.ZyraCilesis = false;
                        modelVeprimet.ZyraFinancave = false;
                        modelVeprimet.IsActive = true;
                        modelVeprimet.IsDeleted = false;
                        modelVeprimet.InsertBy = currentUser;
                        _veprimetRepository.Add(modelVeprimet);
                        _veprimetRepository.SaveChanges();
                        Kerkesat mod = new Kerkesat();
                        int tempDep = (int)model.KerkesaId;
                        var kerkesauGjet = _menaxhimiKerkesaveRepository.GetByIdInt(tempDep);
                        kerkesauGjet.Pranuar = true;
                        kerkesauGjet.Lub = currentUser;
                        kerkesauGjet.Lud = DateTime.Now;
                        _menaxhimiKerkesaveRepository.Update(kerkesauGjet);
                        _menaxhimiKerkesaveRepository.SaveChanges();
                    }
                    else if (User.IsInRole("DepShkenca"))
                    {
                        Veprimet vr = new Veprimet();
                        int tempVep = (int)model.KerkesaId;
                        var vepr = _sherbimetStudentore.GetVeprimID(tempVep);
                        foreach (var item in vepr)
                        {
                            var veprimiUGjet = _veprimetRepository.GetByIdInt(item.VeprimiId);
                            veprimiUGjet.DepShkenca = true;
                            veprimiUGjet.Lud = DateTime.Now;
                            veprimiUGjet.Lub = currentUser;
                            veprimiUGjet.Grupi = model.Grupi;
                            veprimiUGjet.Orari = model.Orari;
                            _veprimetRepository.Update(veprimiUGjet);
                            _veprimetRepository.SaveChanges();

                        }
                    }
                    else if (User.IsInRole("DepEkonomik"))
                    {
                        Veprimet vr = new Veprimet();
                        int tempVep = (int)model.KerkesaId;
                        var vepr = _sherbimetStudentore.GetVeprimID(tempVep);
                        foreach (var item in vepr)
                        {
                            var veprimiUGjet = _veprimetRepository.GetByIdInt(item.VeprimiId);
                            veprimiUGjet.DepEkonomik = true;
                            veprimiUGjet.Lud = DateTime.Now;
                            veprimiUGjet.Lub = currentUser;
                            veprimiUGjet.Grupi = model.Grupi;
                            veprimiUGjet.Orari = model.Orari;
                            _veprimetRepository.Update(veprimiUGjet);
                            _veprimetRepository.SaveChanges();
                        }
                    }
                    else if (User.IsInRole("ZyraFinancave"))
                    {

                    }
                    else if (User.IsInRole("Rektorati"))
                    {

                    }
                    else if (User.IsInRole("Sekretari"))
                    {

                    }
                    else if (User.IsInRole("ZyraCilesis"))
                    {

                    }
                    else if (User.IsInRole("ZyraIt"))
                    {

                    }

                }
                return RedirectToAction(nameof(SherbimeStudentoreController.Index), "SherbimeStudentore", new { area = "Management" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
