namespace SimpleMVC.App.Views.Home
{
    using MVC.Interfaces.Generic;
    using System.IO;
    using ViewModels;

    public class Index : IRenderable<HomeIndexButtonsViewModel>
    {
        public HomeIndexButtonsViewModel Model { get; set; }

        public string Render()
        {
            string page = File.ReadAllText("../../Views/Home/Index.html");

            if (Model.LoggedIn == true)
            {
                page = string.Format(page, $"<a href=\"../users/logout\"><button type=\"button\" class=\"btn btn-primary\">Logout</button></a>");
            }
            else
            {
                page = string.Format(page, $"<a href=\"../users/login\"><button type=\"button\" class=\"btn btn-primary\">Login</button></a> " + 
                                           $"<a href=\"../users/register\"><button type=\"button\" class=\"btn btn-primary\">Register User</button></a>");
            }

            return page;
        }
    }
}