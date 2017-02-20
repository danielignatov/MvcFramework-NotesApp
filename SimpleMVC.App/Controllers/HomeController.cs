namespace SimpleMVC.App.Controllers
{
    using Data;
    using MVC.Controllers;
    using MVC.Interfaces;
    using MVC.Interfaces.Generic;
    using MVC.Security;
    using SimpleHttpServer.Models;
    using ViewModels;

    public class HomeController : Controller
    {
        #region Fields
        private SignInManager signInManager;
        #endregion

        #region Constructors
        public HomeController()
        {
            signInManager = new SignInManager(new NotesApplicationContext());
        }
        #endregion

        public IActionResult<HomeIndexButtonsViewModel> Index(HttpSession session)
        {
            var viewModel = new HomeIndexButtonsViewModel();

            if (signInManager.IsAuthenticated(session))
            {
                viewModel.LoggedIn = true;
            }
            else
            {
                viewModel.LoggedIn = false;
            }

            return View(viewModel);
        }
    }
}