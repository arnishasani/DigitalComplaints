using ApplicationCore.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Management.Models;

namespace Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class StaffController : Controller
    {
        private readonly IStaff _staffRepository;

        public StaffController(IStaff staffRepository)
        {
            _staffRepository = staffRepository;
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
                    staffList.Add(new StaffViewModel
                    {
                        StaffID = item.Id,
                        Name = item.Name,
                        Surname = item.Surname,
                        Email = item.Email,
                        Birthday = item.Birthday,
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

        public IActionResult Details()
        {
            return View();
        }
        public IActionResult AddStaff(StaffViewModel model)
        {
            return View();
        }
    }
}
