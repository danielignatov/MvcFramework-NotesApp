namespace SimpleMVC.App.Views.Home
{
    using MVC.Interfaces.Generic;

    public class Index : IRenderable
    {
        public string Render()
        {
            return $"<h3>Hello MVC!</h3><br><img src=\"http://pocketnow.com/wp-content/uploads/2012/07/wat-why-you-no-face.png\" height=\"200\" width=\"200\">";
        }
    }
}