using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Common.Model;
using Service.User;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;


        public HomeController(ILogger<HomeController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> Create(UserVm userVm)
        {
            try
            {
                await _userService.SaveUser(userVm);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return Json(new object());
        }
        public async Task<JsonResult> DeleteAsync(int userId)
        {
            try
            {
                await _userService.Delete(userId);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return Json(new object());

        }
        public async Task<JsonResult> GetAsync(int userId)
        {
            try
            {
                await _userService.GetById(userId);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return Json(new object());
        }
        public async Task<JsonResult> List()
        {
            try
            {
                var data = await _userService.GetUsers();
                return Json(data);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return Json(new object());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
