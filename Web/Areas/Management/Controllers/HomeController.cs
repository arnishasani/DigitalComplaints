using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Management.Models;

namespace Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class HomeController : Controller
    {
        //private readonly IStudent _studentRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ISherbimeStudentore _sherbimeStudentoreRepository;
        private readonly ILlojetDepartamenteve _llojetDepartamenveRepository;
        private readonly IMenaxhimiK _llojetEKerkesaveRepository;
        private readonly IUsersRole _staffRole;
        private readonly IRole _roleStaff;
        private readonly IUserRepository _userRepository;
        protected readonly ApplicationDBContext _digitalComplaintsDB;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ISherbimeStudentore sherbimeStudentoreRepository, ILlojetDepartamenteve llojetDepartamenveRepository, IMenaxhimiK llojetEKerkesaveRepository, IUsersRole staffRole, IRole roleStaff, IUserRepository userRepository, ApplicationDBContext digitalComplaintsDB)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _sherbimeStudentoreRepository = sherbimeStudentoreRepository;
            _llojetDepartamenveRepository = llojetDepartamenveRepository;
            _llojetEKerkesaveRepository = llojetEKerkesaveRepository;
            _staffRole = staffRole;
            _roleStaff = roleStaff;
            _userRepository = userRepository;
            _digitalComplaintsDB = digitalComplaintsDB;
        }

        public IActionResult Index()
        {
            var model = new Models.SherbimeStudentoreKerkesatViewModel();
            try
            {
                var currentUser = _userManager.GetUserId(User);
                var roleId = _staffRole.GetRoleByUserId(currentUser);
                IEnumerable<AspNetRoles> roleName = null;
                foreach (var role in roleId)
                {
                    roleName = _roleStaff.GetRole(role.RoleId);
                }
                var tempName = "";
                foreach (var tempN in roleName)
                {
                    tempName = tempN.Id;
                }
                if (User.IsInRole("SherbimeStudentore"))
                {

                    var menaxhoKerkesenList = new List<Models.SherbimeStudentoreKerkesatViewModel>();
                    // var menaxhoAnkesenList = new List<SherbimeStudentoreKerkesatViewModel>();
                    // var menaxhoAnkesatAnonimeList = new List<SherbimeStudentoreKerkesatViewModel>();
                    var modelGetAllRequest = _sherbimeStudentoreRepository.GetAllRequestList();
                    //  var modelGetAllComplaint = _sherbimeStudentoreRepository.GetAllComplaintList();
                    // var modelGetAllAnonymousComplaint = _sherbimeStudentoreRepository.GetAllAnonymousComplaintList();
                    foreach (var item in modelGetAllRequest)
                    {
                        int tempDep = (int)item.DepartamentiId;
                        var gjejeDepartamentin = _llojetDepartamenveRepository.GetByIdInt(tempDep);
                        int temp = (int)item.LlojiKerkeses;
                        var gjejLlojinKerkeses = _llojetEKerkesaveRepository.GetByIdInt(temp);
                        menaxhoKerkesenList.Add(new Models.SherbimeStudentoreKerkesatViewModel
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
                    model.sherbimeStudentoreKerkesaList = menaxhoKerkesenList;
                }
                else if (User.IsInRole("DepShkenca"))
                {
                    var menaxhoKerkesenList = new List<Models.SherbimeStudentoreKerkesatViewModel>();
                    var modelGetAllRequest = _sherbimeStudentoreRepository.GetAllRequestsForShk();
                    foreach (var item in modelGetAllRequest)
                    {
                        int id = (int)item.KerkesaId;
                        var model1 = _sherbimeStudentoreRepository.GetByIdInt(id);
                        int tempDep = (int)model1.DepartamentiId;
                        var gjejeDepartamentin = _llojetDepartamenveRepository.GetByIdInt(tempDep);
                        int temp = (int)model1.LlojiKerkeses;
                        var gjejLlojinKerkeses = _llojetEKerkesaveRepository.GetByIdInt(temp);
                        int vepID = 0;
                        foreach (var it in model1.Veprimet)
                        {
                            vepID = it.VeprimiId;
                            break;
                        }
                        menaxhoKerkesenList.Add(new Models.SherbimeStudentoreKerkesatViewModel
                        {
                            VeprimiID = vepID,
                            KerkesaAnkesaId = model1.KerkesaAnkesaId,
                            LlojiKerkeses = gjejLlojinKerkeses.LlojiIkerkeses,
                            Departamenti = gjejeDepartamentin.EmriDepartamentit,
                            Nenshkrimi = model1.Nenshkrimi,
                            PershkrimiIkerkeses = model1.PershkrimiIkerkeses,
                            IsActive = model1.IsActive,
                            IsDeleted = model1.IsDeleted,
                            IsAnonim = model1.IsAnonim,
                            AnonimId = model1.AnonimId,
                            Ankes = model1.Ankes,
                            InsertBy = model1.InsertBy,
                            InsertDate = model1.InsertDate,
                            Lub = model1.Lub,
                            Lud = model1.Lud,
                            Lun = model1.Lun
                        });
                    }
                    model.sherbimeStudentoreKerkesaList = menaxhoKerkesenList;
                }
                else if (User.IsInRole("DepEkonomik"))
                {
                    var menaxhoKerkesenList = new List<Models.SherbimeStudentoreKerkesatViewModel>();
                    var modeel = new Veprimet();
                    var m = _digitalComplaintsDB.MenaxhimiKerkesaveRolet.Where(x => x.RoliId == "6").ToList();
                    foreach (var asd in m)
                    {
                        var sm = _digitalComplaintsDB.Kerkesat.Where(x => x.LlojiKerkeses == asd.LlojiKerkesesId).ToList();
                        foreach (var item in sm)
                        {
                            var r = _digitalComplaintsDB.Veprimet.Where(x => x.KerkesaId == item.KerkesaAnkesaId && x.Perfunduar == false && x.SherbimeStudentore == true && x.DepShkenca == false && x.DepEkonomik == false && x.Sekretari == false && x.Rektorati == false && x.ZyraFinancave == false && x.ZyraIt == false && x.ZyraCilesis == false).ToList();
                            foreach (var model12 in r)
                            {
                                int id = (int)model12.KerkesaId;
                                var model1 = _sherbimeStudentoreRepository.GetByIdInt(id);
                                int tempDep = (int)model1.DepartamentiId;
                                var gjejeDepartamentin = _llojetDepartamenveRepository.GetByIdInt(tempDep);
                                int temp = (int)model1.LlojiKerkeses;
                                var gjejLlojinKerkeses = _llojetEKerkesaveRepository.GetByIdInt(temp);
                                menaxhoKerkesenList.Add(new Models.SherbimeStudentoreKerkesatViewModel
                                {
                                    KerkesaAnkesaId = (int)model12.KerkesaId,
                                    LlojiKerkeses = gjejLlojinKerkeses.LlojiIkerkeses,
                                    Departamenti = gjejeDepartamentin.EmriDepartamentit,
                                    Nenshkrimi = model1.Nenshkrimi,
                                    PershkrimiIkerkeses = model1.PershkrimiIkerkeses,
                                    IsActive = model1.IsActive,
                                    IsDeleted = model1.IsDeleted,
                                    IsAnonim = model1.IsAnonim,
                                    AnonimId = model1.AnonimId,
                                    Ankes = model1.Ankes,
                                    InsertBy = model1.InsertBy,
                                    InsertDate = model1.InsertDate,
                                    Lub = model1.Lub,
                                    Lud = model1.Lud,
                                    Lun = model1.Lun
                                });
                            }
                        }
                    }
                    model.sherbimeStudentoreKerkesaList = menaxhoKerkesenList;
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
                else if (User.IsInRole("SuperAdmin"))
                {
                    var menaxhoKerkesenList = new List<Models.SherbimeStudentoreKerkesatViewModel>();
                    var modelGetAllRequest = _sherbimeStudentoreRepository.GetAllRequestList();
                    foreach (var item in modelGetAllRequest)
                    {
                        int tempDep = (int)item.DepartamentiId;
                        var gjejeDepartamentin = _llojetDepartamenveRepository.GetByIdInt(tempDep);
                        int temp = (int)item.LlojiKerkeses;
                        var gjejLlojinKerkeses = _llojetEKerkesaveRepository.GetByIdInt(temp);
                        menaxhoKerkesenList.Add(new Models.SherbimeStudentoreKerkesatViewModel
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
                    model.sherbimeStudentoreKerkesaList = menaxhoKerkesenList;
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public IActionResult ShikoStudentet()
        //{
        //    var model = new StudentViewModel();
        //    try
        //    {
        //        var studentList = new List<StudentViewModel>();
        //        var modeel = _studentRepository.GetAllStudentList();
        //        foreach (var item in modeel)
        //        {
        //            studentList.Add(new StudentViewModel {
        //                IndexId = item.IndexId,
        //                Name = item.Name,
        //                Surname = item.Surname,
        //                Email = item.Email,
        //                Birthday = item.Birthday,
        //                Gender = item.Gender,
        //                PhoneNumber = item.PhoneNumber,
        //                IsActive = item.IsActive,
        //                IsDeleted = item.IsDeleted,
        //                LastModifiedOnDate = item.LastModifiedOnDate,
        //                CreateOnDate = item.CreateOnDate,
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return View();
        //}
     
        public IActionResult Create()
        {
            return View();
        }
    }
}
