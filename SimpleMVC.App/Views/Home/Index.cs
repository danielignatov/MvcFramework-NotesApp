namespace SimpleMVC.App.Views.Home
{
    using MVC.Interfaces;
    using System.IO;

    public class Index : IRenderable
    {
        public string Render()
        {
            string page = File.ReadAllText("../../Views/Home/Index.html");

            return page;
        }
    }
}