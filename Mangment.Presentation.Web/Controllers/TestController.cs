using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mangment.Presentation.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mangment.Presentation.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostTest()
        {
            TestModel model = new TestModel();
            model.Id = 1;
            model.IsMale = true;
            model.Name = "weng";
            
            return Json(model);
        }
    }
}