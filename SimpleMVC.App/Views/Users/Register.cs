﻿namespace SimpleMVC.App.Views.Users
{
    using MVC.Interfaces;
    using System.IO;

    public class Register : IRenderable
    {
        public string Render()
        {
            string page = File.ReadAllText("../../Views/Users/Register.html");
            
            return page;
        }
    }
}