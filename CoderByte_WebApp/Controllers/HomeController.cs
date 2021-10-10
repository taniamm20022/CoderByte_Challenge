using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoderByte_WebApp.Models;
using CoderByte_DAL.Models;
using CoderByte_WebApp.UiServices.Interfaces;

namespace CoderByte_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILossTypesUiService _lossTypesUiService;

        public HomeController(ILogger<HomeController> logger, ILossTypesUiService lossTypesUiService)
        {
            _logger = logger;
            _lossTypesUiService = lossTypesUiService;
        }

        public async  Task<IActionResult> Index()
        {
            var vm = await _lossTypesUiService.GetIndexViewModel();
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    
    }
}
