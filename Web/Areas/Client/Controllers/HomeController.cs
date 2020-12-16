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
        private readonly ILlojetDepartamenteve _llojetDepartamenveRepository;
        private readonly IMenaxhimiK _llojetEKerkesaveRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserRepository _userRepository;

        public HomeController(IKerkesat kerkesatRepository, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ILlojetDepartamenteve llojetDepartamenveRepository, IMenaxhimiK llojetEKerkesaveRepository, IUserRepository userRepository)
        {
            _kerkesatRepository = kerkesatRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _llojetDepartamenveRepository = llojetDepartamenveRepository;
            _llojetEKerkesaveRepository = llojetEKerkesaveRepository;
            _userRepository = userRepository;
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
                    int tempDep = (int)item.DepartamentiId;
                    var gjejeDepartamentin = _llojetDepartamenveRepository.GetById(tempDep);
                    int temp = (int)item.LlojiKerkeses;
                    var gjejLlojinKerkeses = _llojetEKerkesaveRepository.GetById(temp);
                    var gjejuserin = _userRepository.GetByStringId(item.UserId);
                    kerkesatList.Add(new KerkesaViewModel
                    {
                        UserId = item.UserId,
                        KerkesaAnkesaId = item.KerkesaAnkesaId,
                        EmriKerkeses = gjejLlojinKerkeses.LlojiIkerkeses,
                        EmriDepartamentit = gjejeDepartamentin.EmriDepartamentit,
                        Nenshkrimi = item.Nenshkrimi,
                        PershkrimiIkerkeses = item.PershkrimiIkerkeses,
                        IsActive = item.IsActive,
                        IsDeleted = item.IsDeleted,
                        IsAnonim = item.IsAnonim,
                        Ankes=item.Ankes,
                        AnonimId = item.AnonimId,
                        InsertBy = gjejuserin.Email,
                        InsertDate = item.InsertDate,
                        Lub = item.Lub,
                        Lud = item.Lud,
                        Lun = item.Lun
                    });
                }
                model.kerkesalist = kerkesatList;
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult IndexAnkes()
        {
            var model = new KerkesaViewModel();
            try
            {
                var currentUserId = _userManager.GetUserId(User);
                var kerkesatList = new List<KerkesaViewModel>();
                var model1 = _kerkesatRepository.GetAllComplaintList(currentUserId);
                foreach (var item in model1)
                {
                    int tempDep = (int)item.DepartamentiId;
                    var gjejeDepartamentin = _llojetDepartamenveRepository.GetById(tempDep);
                    int temp = (int)item.LlojiKerkeses;
                    var gjejLlojinKerkeses = _llojetEKerkesaveRepository.GetById(temp);
                    var gjejuserin = _userRepository.GetByStringId(item.UserId);
                    kerkesatList.Add(new KerkesaViewModel
                    {
                        UserId = item.UserId,
                        KerkesaAnkesaId = item.KerkesaAnkesaId,
                        EmriKerkeses = gjejLlojinKerkeses.LlojiIkerkeses,
                        EmriDepartamentit = gjejeDepartamentin.EmriDepartamentit,
                        Nenshkrimi = item.Nenshkrimi,
                        PershkrimiIkerkeses = item.PershkrimiIkerkeses,
                        IsActive = item.IsActive,
                        IsDeleted = item.IsDeleted,
                        IsAnonim = item.IsAnonim,
                        Ankes=item.Ankes,
                        AnonimId = item.AnonimId,
                        InsertBy = gjejuserin.Email,
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
            var model = new KerkesaViewModel();
            try
            {
                var departamentetList = new List<KerkesaViewModel>();
                var modeelDepartamentet = _llojetDepartamenveRepository.GetAllList();
                foreach (var item in modeelDepartamentet)
                {
                    departamentetList.Add(new KerkesaViewModel
                    {
                        DepartamentiId = item.DepartamentiId,
                        EmriDepartamentit = item.EmriDepartamentit,
                        InsertBy = _userManager.GetUserName(User),
                        IsActive = item.IsActive,
                        IsDeleted = item.IsDeleted,
                        InsertDate = item.InsertDate,
                        Lud = item.Lud,

                    });;
                }
                model.departamentetlist = departamentetList;
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                if(model.KerkesaAnkesaId == 0)
                {
                    Kerkesat kerkesa = new Kerkesat();
                    kerkesa.DepartamentiId = model.DepartamentiId;
                    kerkesa.UserId = _userManager.GetUserId(User);
                    kerkesa.LlojiKerkeses = model.LlojiKerkeses;
                    kerkesa.Nenshkrimi = model.Nenshkrimi;
                    kerkesa.PershkrimiIkerkeses = model.PershkrimiIkerkeses;
                    kerkesa.IsActive = true;
                    kerkesa.IsDeleted = false;
                    kerkesa.IsAnonim = false;
                    kerkesa.AnonimId = null;
                    kerkesa.Ankes = false;
                    kerkesa.InsertBy = _userManager.GetUserId(User);
                    kerkesa.Pranuar = false;
                    kerkesa.InsertDate = DateTime.Now;
                    _kerkesatRepository.Add(kerkesa);
                    _kerkesatRepository.SaveChanges();
                }
                else
                {
                        var existing = _kerkesatRepository.GetById(model.KerkesaAnkesaId);
                        //existing.Departamenti = model.Departamenti;
                        existing.Lud = DateTime.Now;
                        existing.IsActive = model.IsActive;
                        existing.IsDeleted = model.IsDeleted;
                        _kerkesatRepository.Update(existing);
                        _kerkesatRepository.SaveChanges();
                }
                return RedirectToAction(nameof(HomeController.Index), "Home", new { area = "Client" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult AddAnkese()
        {
            var model = new KerkesaViewModel();
            try
            {
                var departamentetList = new List<KerkesaViewModel>();
                var modeelDepartamentet = _llojetDepartamenveRepository.GetAllList();
                foreach (var item in modeelDepartamentet)
                {
                    departamentetList.Add(new KerkesaViewModel
                    {
                        DepartamentiId = item.DepartamentiId,
                        EmriDepartamentit = item.EmriDepartamentit,
                        InsertBy = _userManager.GetUserName(User),
                        IsActive = item.IsActive,
                        IsDeleted = item.IsDeleted,
                        InsertDate = item.InsertDate,
                        Lud = item.Lud
                    });
                }
                model.departamentetlist = departamentetList;
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public IActionResult AddAnkese(KerkesaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                if (model.KerkesaAnkesaId == 0)
                {
                    Kerkesat kerkesa = new Kerkesat();
                    kerkesa.DepartamentiId = 1;
                    kerkesa.UserId = _userManager.GetUserId(User);
                    kerkesa.LlojiKerkeses = 4;
                    kerkesa.Nenshkrimi = model.Nenshkrimi;
                    kerkesa.PershkrimiIkerkeses = model.PershkrimiIkerkeses;
                    kerkesa.IsActive = true;
                    kerkesa.IsDeleted = false;
                    kerkesa.Ankes = true;
                    kerkesa.IsAnonim = false;
                    kerkesa.AnonimId = null;
                    kerkesa.InsertBy = _userManager.GetUserId(User);
                    kerkesa.Pranuar = false;
                    kerkesa.InsertDate = DateTime.Now;
                    _kerkesatRepository.Add(kerkesa);
                    _kerkesatRepository.SaveChanges();
                    //var kerkesa = new Kerkesat
                    //UserId = model.UserId,
                    //KerkesaAnkesaId = model.KerkesaAnkesaId,
                    //LlojiKerkeses = model.LlojiKerkeses,
                    //DepartamentiId = model.DepartamentiId,
                    //Nenshkrimi = model.Nenshkrimi,
                    //PershkrimiIkerkeses = model.PershkrimiIkerkeses,
                    //IsActive = model.IsActive,
                    //IsDeleted = model.IsDeleted,
                    //IsAnonim = model.IsAnonim,
                    //AnonimId = model.AnonimId,
                    //InsertBy = model.InsertBy,
                    //InsertDate = model.InsertDate,
                    //Lub = model.Lub,
                    //Lud = model.Lud,
                    //Lun = model.Lun,
                }
                else
                {
                    var existing = _kerkesatRepository.GetById(model.KerkesaAnkesaId);
                    //existing.Departamenti = model.Departamenti;
                    existing.Lud = DateTime.Now;
                    existing.IsActive = model.IsActive;
                    existing.IsDeleted = model.IsDeleted;
                    _kerkesatRepository.Update(existing);
                    _kerkesatRepository.SaveChanges();
                }
                return RedirectToAction(nameof(HomeController.IndexAnkes), "Home", new { area = "Client" });
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
