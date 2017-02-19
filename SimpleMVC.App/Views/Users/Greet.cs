namespace SimpleMVC.App.Views.Users
{
    using MVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels;

    public class Greet : IRenderable<GreetViewModel>
    {
        #region Properties
        public GreetViewModel Model { get; set; }
        #endregion

        #region Methods
        public string Render()
        {
            return $"<em>Hello, user with session id: {this.Model.SessionId}</em>";
        }
        #endregion
    }
}