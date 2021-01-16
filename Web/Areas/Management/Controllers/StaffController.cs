using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Management.Models;
using Web.Extensions;

namespace Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class StaffController : Controller
    {
        private readonly IStaff _staffRepository;
        private readonly IUsersRole _staffRole;
        private readonly IRole _roleStaff;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public StaffController(IStaff staffRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IUsersRole staffRole, IRole roleStaff)
        {
            _staffRepository = staffRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _staffRole = staffRole;
            _roleStaff = roleStaff;
        }

        public IActionResult Index()
        {
            var model = new StaffViewModel();
            try
            {
                var staffList = new List<StaffViewModel>();
                var modeel = _staffRepository.GetAllList();
                foreach (var item in modeel)
                {
                    var roleId = _staffRole.GetRoleByUserId(item.Id);
                    IEnumerable<AspNetRoles> roleName = null;
                    foreach (var role in roleId)
                    {
                        roleName = _roleStaff.GetRole(role.RoleId);
                    }
                    var tempName = "";
                    foreach (var tempN in roleName)
                    {
                        tempName = tempN.Name;
                    }
                    staffList.Add(new StaffViewModel
                    {
                        StaffID = item.Id,
                        Name = item.Name,
                        Surname = item.Surname,
                        Email = item.Email,
                        Birthday = item.Birthday,
                        Roli = tempName,
                        Gender = item.Gender,
                        PhoneNumber = item.PhoneNumber,
                        IsActive = item.IsActive,
                        IsDeleted = item.IsDeleted,
                        LastModifiedOnDate = item.LastModifiedOnDate,
                        CreateOnDate = item.CreateOnDate,
                    });
                }
                model.Staff = staffList;
                return View(model);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Details(string id)
        {
            try
            {
                var staff = _staffRepository.GetById(id);
                var vm = new StaffViewModel()
                {
                    Name = staff.Name,
                    Surname = staff.Surname,
                    Email = staff.Email,
                    PhoneNumber = staff.PhoneNumber,
                    Birthday = staff.Birthday,
                    Gender = staff.Gender,
                    IsActive = staff.IsActive,
                    IsDeleted = staff.IsDeleted,
                    CreateOnDate = staff.CreateOnDate,
                    LastModifiedOnDate = staff.LastModifiedOnDate
                };
                return View(vm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddStaff(StaffViewModel model)
        {
            try
            {
                //if (!ModelState.IsValid)
                //    return View(model);
                //else
                //{
                var currentDate = DateTime.Now;
                var user = new ApplicationUser
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Birthday = model.Birthday,
                    Gender = model.Gender,
                    IsActive = true,
                    IsDeleted = false,
                    CreateByUserId = _userManager.GetUserId(User),
                    CreateOnDate = currentDate,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (model.SherbimeStudentore != false)
                    {
                        var role = await _roleManager.FindByIdAsync("4");
                        await _userManager.AddToRoleAsync(user, role.Name);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.EmailConfirmationLink(user.Id.ToString(), code, Request.Scheme);
                    }
                    else if (model.DepShkenca != false)
                    {
                        var role = await _roleManager.FindByIdAsync("5");
                        await _userManager.AddToRoleAsync(user, role.Name);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.EmailConfirmationLink(user.Id.ToString(), code, Request.Scheme);
                    }
                    else if (model.DepEkonomik != false)
                    {
                        var role = await _roleManager.FindByIdAsync("6");
                        await _userManager.AddToRoleAsync(user, role.Name);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.EmailConfirmationLink(user.Id.ToString(), code, Request.Scheme);
                    }
                    else if (model.ZyraFinancave != false)
                    {
                        var role = await _roleManager.FindByIdAsync("7");
                        await _userManager.AddToRoleAsync(user, role.Name);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.EmailConfirmationLink(user.Id.ToString(), code, Request.Scheme);
                    }
                    else if (model.Rektorati != false)
                    {
                        var role = await _roleManager.FindByIdAsync("8");
                        await _userManager.AddToRoleAsync(user, role.Name);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.EmailConfirmationLink(user.Id.ToString(), code, Request.Scheme);
                    }
                    else if (model.Sekretari != false)
                    {
                        var role = await _roleManager.FindByIdAsync("9");
                        await _userManager.AddToRoleAsync(user, role.Name);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.EmailConfirmationLink(user.Id.ToString(), code, Request.Scheme);
                    }
                    else if (model.ZyraCilesise != false)
                    {
                        var role = await _roleManager.FindByIdAsync("10");
                        await _userManager.AddToRoleAsync(user, role.Name);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.EmailConfirmationLink(user.Id.ToString(), code, Request.Scheme);
                    }
                    else if (model.ZyraIT != false)
                    {
                        var role = await _roleManager.FindByIdAsync("11");
                        await _userManager.AddToRoleAsync(user, role.Name);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.EmailConfirmationLink(user.Id.ToString(), code, Request.Scheme);
                    }
                }
                return RedirectToAction(nameof(StaffController.Index), "Staff", new { area = "Management" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[HttpGet]
        //public IActionResult Edit(string id)
        //{
        //    try
        //    {
        //        var staff = _staffRepository.GetById(id);
        //        var vm = new StaffViewModel()
        //        {
        //            Name = staff.Name,
        //            Surname = staff.Surname,
        //            Email = staff.Email,
        //            PhoneNumber = staff.PhoneNumber,
        //            Birthday = staff.Birthday,
        //            Gender = staff.Gender,
        //            IsActive = staff.IsActive,
        //            IsDeleted = staff.IsDeleted,
        //            CreateOnDate = staff.CreateOnDate,
        //            LastModifiedOnDate = staff.LastModifiedOnDate
        //        };
        //        return View(vm);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //[HttpPost]
        //public IActionResult EditStaff(StaffViewModel model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return View(model);
        //        else
        //        {
        //            var user = new ApplicationUser
        //            {
        //                Name = model.Name,
        //                Surname = model.Surname,
        //                UserName = model.Email,
        //                Email = model.Email,
        //                PhoneNumber = model.PhoneNumber,
        //                Birthday = model.Birthday,
        //                Gender = model.Gender,
        //                IsActive = model.IsActive,
        //                IsDeleted = model.IsDeleted,
        //                LastModifiedByUserId = _userManager.GetUserId(User),
        //                LastModifiedOnDate = DateTime.Now,
        //            };
        //            //_staffRepository.UpdateUser(user);
        //        }
        //        return RedirectToAction(nameof(StaffController.Index), "Staff", new { area = "Management" });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [HttpPost]
        public IActionResult DeleteStaff(string id)
        {
            try
            {
                var staff = _staffRepository.GetById(id);
                if (staff != null)
                {

                    staff.IsDeleted = true;
                    staff.LastModifiedByUserId = _userManager.GetUserId(User);
                    staff.LastModifiedOnDate = DateTime.Now;
                    _staffRepository.DeleteUser(staff);
                }
                return RedirectToAction(nameof(StaffController.Index), "Staff", new { area = "Management" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
