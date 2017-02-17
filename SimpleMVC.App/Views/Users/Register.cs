namespace SimpleMVC.App.Views.Users
{
    using MVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Register : IRenderable
    {
        public string Render()
        {
            string registerPage = File.ReadAllText("../../Views/Users/Register.html");
            
            return registerPage;
        }
    }
}