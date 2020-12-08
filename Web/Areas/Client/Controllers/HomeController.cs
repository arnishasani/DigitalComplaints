using ApplicationCore.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Client.Models;
using ApplicationCore.Entities;

namespace Web.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        private readonly IKerkesat _kerkesatRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(IKerkesat kerkesatRepository, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _kerkesatRepository = kerkesatRepository;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var model = new KerkesaViewModel();
            try
            {
                var currentUserId = _userManager.GetUserId(User);
                var kerkesatList = new List<KerkesaViewModel>();
                var model1 = _kerkesatRepository.GetAllList(currentUserId);
                foreach (var item in model1)
                {
                    kerkesatList.Add(new KerkesaViewModel
                    {
                        UserId = item.UserId,
                        KerkesaAnkesaId = item.KerkesaAnkesaId,
                        LlojiKerkeses = item.LlojiKerkeses,
                        DepartamentiId = item.DepartamentiId,
                        Nenshkrimi = item.Nenshkrimi,
                        PershkrimiIkerkeses = item.PershkrimiIkerkeses,
                        IsActive = item.IsActive,
                        IsDeleted = item.IsDeleted,
                        IsAnonim = item.IsAnonim,
                        AnonimId = item.AnonimId,
                        InsertBy = item.InsertBy,
                        InsertDate = item.InsertDate,
                        Lub = item.Lub,
                        Lud = item.Lud,
                        Lun = item.Lun
                    });
                }
                model.kerkesalist = kerkesatList;
                return View(model);
            }
            catch (Exception)
            {
                return null;
            }
        }
        [HttpGet]
        public IActionResult AddKerkese()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddKerkese(KerkesaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    var kerkesa = new Kerkesat
                    {
                        UserId = model.UserId,
                        KerkesaAnkesaId = model.KerkesaAnkesaId,
                        LlojiKerkeses = model.LlojiKerkeses,
                        DepartamentiId = model.DepartamentiId,
                        Nenshkrimi = model.Nenshkrimi,
                        PershkrimiIkerkeses = model.PershkrimiIkerkeses,
                        IsActive = model.IsActive,
                        IsDeleted = model.IsDeleted,
                        IsAnonim = model.IsAnonim,
                        AnonimId = model.AnonimId,
                        InsertBy = model.InsertBy,
                        InsertDate = model.InsertDate,
                        Lub = model.Lub,
                        Lud = model.Lud,
                        Lun = model.Lun
                    };

                }
                return RedirectToAction(nameof(HomeController.Index), "Home", new { area = "Client" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //public IActionResult CreateKerkese(int id)
        //{
        //    var model = new Kerkesat();
        //    try
        //    {
        //        model.KerkesaAnkesaId = id;
        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _kerkesatRepository.AddException(this.ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["action"].ToString(), ex.ToString(), "");
        //        return View(model);
        //    }
        //}
        public IActionResult DeleteKerkese(string id)
        {
            try
            {
                var kerkese = _kerkesatRepository.GetById(id);
                if (kerkese != null)
                {
                    kerkese.IsDeleted = true;
                    _kerkesatRepository.DeleteKerkese(kerkese);
                }
                return RedirectToAction(nameof(HomeController.Index), "Kerkesa", new { area = "Client" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IActionResult Details(string id)
        {
            try
            {
                var kerkese = _kerkesatRepository.GetById(id);
                var kerkesavm = new KerkesaViewModel()
                {
                    UserId = kerkese.UserId,
                    KerkesaAnkesaId = kerkese.KerkesaAnkesaId,
                    LlojiKerkeses = kerkese.LlojiKerkeses,
                    DepartamentiId = kerkese.DepartamentiId,
                    Nenshkrimi = kerkese.Nenshkrimi,
                    PershkrimiIkerkeses = kerkese.PershkrimiIkerkeses,
                    IsActive = kerkese.IsActive,
                    IsDeleted = kerkese.IsDeleted,
                    IsAnonim = kerkese.IsAnonim,
                    AnonimId = kerkese.AnonimId,
                    InsertBy = kerkese.InsertBy,
                    InsertDate = kerkese.InsertDate,
                    Lub = kerkese.Lub,
                    Lud = kerkese.Lud,
                    Lun = kerkese.Lun
                };
                return View(kerkesavm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
