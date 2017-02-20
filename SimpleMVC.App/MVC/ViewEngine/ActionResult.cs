namespace SimpleMVC.App.MVC.ViewEngine.Generic
{
    using Interfaces;
    using SimpleMVC.App.MVC.Interfaces.Generic;
    using System;

    public class ActionResult : IActionResult
    {
        #region Constructors
        public ActionResult(string viewFullQualifedName)
        {
            this.Action = (IRenderable)Activator.CreateInstance(Type.GetType(viewFullQualifedName));
        }

        public ActionResult(string viewFullQualifedName, string location) : this(viewFullQualifedName)
        {
            this.Location = location;
        }
        #endregion

        #region Properties
        public IRenderable Action { get; set; }

        public string Location { get; private set; }
        #endregion

        #region Methods
        public string Invoke()
        {
            return this.Action.Render();
        }
        #endregion
    }
}