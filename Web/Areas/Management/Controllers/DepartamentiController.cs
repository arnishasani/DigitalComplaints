﻿using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Management.Models;

namespace Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class DepartamentiController : Controller
    {
        private readonly ILlojetDepartamenteve _departamentetRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        public DepartamentiController(ILlojetDepartamenteve departamentetRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _departamentetRepository = departamentetRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var model = new DepartamentiViewModel();
            try
            {
                var departamentetList = new List<DepartamentiViewModel>();
                var modeelDepartamentet = _departamentetRepository.GetAllList();
                foreach (var item in modeelDepartamentet)
                {
                    departamentetList.Add(new DepartamentiViewModel
                    {
                        DepartamentiId = item.DepartamentiId,
                        EmriDepartamentit = item.EmriDepartamentit,
                        IsActive = item.IsActive,
                        IsDeleted = item.IsDeleted,
                        InsertDate = item.InsertDate,
                        Lud = item.Lud
                    });
                }
                model.DepartamentetList = departamentetList;
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public IActionResult AddDepartamente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDepartamente(DepartamentiViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                else
                {
                    var currentUser = _userManager.GetUserId(User);
                    if (model.DepartamentiId == 0)
                    {
                        TblLlojetDepartamenteve modelDepartamente = new TblLlojetDepartamenteve();
                        modelDepartamente.EmriDepartamentit = model.EmriDepartamentit;
                        modelDepartamente.InsertDate = DateTime.Now;
                        modelDepartamente.IsActive = true;
                        modelDepartamente.IsDeleted = false;
                        _departamentetRepository.Add(modelDepartamente);
                        _departamentetRepository.SaveChanges();
                    }
                    else
                    {
                        var existing = _departamentetRepository.GetById(model.DepartamentiId);
                        existing.EmriDepartamentit = model.EmriDepartamentit;
                        existing.Lud = DateTime.Now;
                        existing.IsActive = model.IsActive;
                        existing.IsDeleted = model.IsDeleted;
                        _departamentetRepository.Update(existing);
                        _departamentetRepository.SaveChanges();
                    }
                }
                return RedirectToAction(nameof(DepartamentiController.Index), "Departamenti", new { area = "Management" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
