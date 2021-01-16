using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
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
    public class MenaxhimiKerkesaveController : Controller
    {
        private readonly IMenaxhimiK _menaxhimiRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMenaxhimiKerkesaveRole _menaxhimiKerkesaveRoleve;

        public MenaxhimiKerkesaveController(IMenaxhimiK menaxhimiRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMenaxhimiKerkesaveRole menaxhimiKerkesaveRoleve)
        {
            _menaxhimiRepository = menaxhimiRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _menaxhimiKerkesaveRoleve = menaxhimiKerkesaveRoleve;
        }
        public IActionResult Index()
        {
            var model = new MenaxhimiKerkesaveViewModel();
            try
            {
                var menaxhimetList = new List<MenaxhimiKerkesaveViewModel>();
                var modelMenaxhimi = _menaxhimiRepository.GetAllList();
                foreach (var item in modelMenaxhimi)
                {
                    menaxhimetList.Add(new MenaxhimiKerkesaveViewModel
                    {
                        MenaxhimiId = item.MenaxhimiId,
                        LlojiIkerkeses = item.LlojiIkerkeses,
                        PershkrimiKerkeses = item.PershkrimiKerkeses,
                        IsActive = item.IsActive,
                        IsDeleted = item.IsDeleted,
                        //  InsertBy = item.InsertBy,
                        InsertDate = item.InsertDate,
                        Lub = item.Lub,
                        Lud = item.Lud,
                    }); 
                }
                model.menaxhimiList = menaxhimetList;
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult AddKerkese()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddKerkese(MenaxhimiKerkesaveViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                if (model.MenaxhimiId == 0)
                {
                    var createonDate = DateTime.Now;
                    TblMenaxhimiKerkesave modelMenaxhimi = new TblMenaxhimiKerkesave();
                    modelMenaxhimi.LlojiIkerkeses = model.LlojiIkerkeses;
                    modelMenaxhimi.PershkrimiKerkeses = model.PershkrimiKerkeses;
                    modelMenaxhimi.InsertBy = _userManager.GetUserId(User);
                    modelMenaxhimi.InsertDate = createonDate;
                    modelMenaxhimi.IsActive = true;
                    modelMenaxhimi.IsDeleted = false;
                    _menaxhimiRepository.Add(modelMenaxhimi);
                    _menaxhimiRepository.SaveChanges();

                    var menaxhimiKerkesesID = _menaxhimiRepository.GetMax();
                    MenaxhimiKerkesaveRolet modelRoletKerkesave = new MenaxhimiKerkesaveRolet();
                    modelRoletKerkesave.RoliId = "4";
                    modelRoletKerkesave.LlojiKerkesesId = menaxhimiKerkesesID;
                    _menaxhimiKerkesaveRoleve.Add(modelRoletKerkesave);
                    _menaxhimiRepository.SaveChanges();
                    if (model.DepShkenca == true)
                    {
                        MenaxhimiKerkesaveRolet addDepShkenca = new MenaxhimiKerkesaveRolet();
                        addDepShkenca.RoliId = "5";
                        addDepShkenca.LlojiKerkesesId = menaxhimiKerkesesID;
                        _menaxhimiKerkesaveRoleve.Add(addDepShkenca);
                        _menaxhimiRepository.SaveChanges();
                    }
                    if (model.DepEkonomik == true)
                    {
                        MenaxhimiKerkesaveRolet addDepEkonomik = new MenaxhimiKerkesaveRolet();
                        addDepEkonomik.RoliId = "6";
                        addDepEkonomik.LlojiKerkesesId = menaxhimiKerkesesID;
                        _menaxhimiKerkesaveRoleve.Add(addDepEkonomik);
                        _menaxhimiRepository.SaveChanges();
                    }
                    if (model.ZyraFinancave == true)
                    {
                        MenaxhimiKerkesaveRolet addZyrenFinancave = new MenaxhimiKerkesaveRolet();
                        addZyrenFinancave.RoliId = "7";
                        addZyrenFinancave.LlojiKerkesesId = menaxhimiKerkesesID;
                        _menaxhimiKerkesaveRoleve.Add(addZyrenFinancave);
                        _menaxhimiRepository.SaveChanges();
                    }
                    if (model.Rektorati == true)
                    {
                        MenaxhimiKerkesaveRolet addZyrenFinancave = new MenaxhimiKerkesaveRolet();
                        addZyrenFinancave.RoliId = "8";
                        addZyrenFinancave.LlojiKerkesesId = menaxhimiKerkesesID;
                        _menaxhimiKerkesaveRoleve.Add(addZyrenFinancave);
                        _menaxhimiRepository.SaveChanges();
                    }
                    if (model.Sekretari == true)
                    {
                        MenaxhimiKerkesaveRolet addZyrenFinancave = new MenaxhimiKerkesaveRolet();
                        addZyrenFinancave.RoliId = "9";
                        addZyrenFinancave.LlojiKerkesesId = menaxhimiKerkesesID;
                        _menaxhimiKerkesaveRoleve.Add(addZyrenFinancave);
                        _menaxhimiRepository.SaveChanges();
                    }
                    if (model.ZyraCilesis == true)
                    {
                        MenaxhimiKerkesaveRolet addZyrenFinancave = new MenaxhimiKerkesaveRolet();
                        addZyrenFinancave.RoliId = "10";
                        addZyrenFinancave.LlojiKerkesesId = menaxhimiKerkesesID;
                        _menaxhimiKerkesaveRoleve.Add(addZyrenFinancave);
                        _menaxhimiRepository.SaveChanges();
                    }
                    if (model.ZyraIt == true)
                    {
                        MenaxhimiKerkesaveRolet addZyrenFinancave = new MenaxhimiKerkesaveRolet();
                        addZyrenFinancave.RoliId = "11";
                        addZyrenFinancave.LlojiKerkesesId = menaxhimiKerkesesID;
                        _menaxhimiKerkesaveRoleve.Add(addZyrenFinancave);
                        _menaxhimiRepository.SaveChanges();
                    }
                }
                return RedirectToAction(nameof(MenaxhimiKerkesaveController.Index), "MenaxhimiKerkesave", new { area = "Management" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult DeleteKerkese (int id)
        {
            try
            {
                var kerkesa = _menaxhimiRepository.GetByIdInt(id);
                if (kerkesa != null)
                {
                    kerkesa.IsDeleted = true;
                    kerkesa.Lub = _userManager.GetUserId(User);
                    kerkesa.Lud = DateTime.Now;
                    _menaxhimiRepository.DeleteMenaxhim(kerkesa);
                }
                return RedirectToAction(nameof(MenaxhimiKerkesaveController.Index), "MenaxhimiKerkesave", new { area = "Management" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
