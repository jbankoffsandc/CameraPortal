using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using jQueryDatatableServerSideNetCore.Models;
using jQueryDatatableServerSideNetCore.Data;
using Microsoft.EntityFrameworkCore;
using jQueryDatatableServerSideNetCore.Models.DatabaseModels;

namespace jQueryDatatableServerSideNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public  IActionResult Index()
        {
           // JsonResult result = TestDataset().Result;
                return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetDataset()
        {
            var result = await _context.master_cameras.ToListAsync();
            foreach(Camera camera in result)
            {
                camera.mac_address = "<a href=\"http://" + camera.ip_address + "/en/storagelist.asp\"  target =\"blank\">Camera History</a>"; 
            }
            return Json(new
            {
                data = result
                  .ToList()
            });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
