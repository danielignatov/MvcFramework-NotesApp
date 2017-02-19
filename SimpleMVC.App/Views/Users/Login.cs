namespace SimpleMVC.App.Views.Users
{
    using MVC.Interfaces;
    using System.IO;

    public class Login : IRenderable
    {
        #region Methods
        public string Render()
        {
            string page = File.ReadAllText("../../Views/Users/Login.html");

            return page;
        }
        #endregion
    }
}