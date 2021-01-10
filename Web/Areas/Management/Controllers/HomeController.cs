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
        private readonly IStudent _studentRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShikoStudentet()
        {
            var model = new StudentViewModel();
            try
            {
                var studentList = new List<StudentViewModel>();
                var modeel = _studentRepository.GetAllStudentList();
                foreach (var item in modeel)
                {
                    studentList.Add(new StudentViewModel {
                        IndexId = item.IndexId,
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
     
        public IActionResult Create()
        {
            return View();
        }
    }
}
