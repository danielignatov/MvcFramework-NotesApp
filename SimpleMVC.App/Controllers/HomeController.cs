namespace SimpleMVC.App.Controllers
{
    using MVC.Controllers;
    using MVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}