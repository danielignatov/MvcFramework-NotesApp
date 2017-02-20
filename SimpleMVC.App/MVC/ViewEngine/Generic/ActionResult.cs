namespace SimpleMVC.App.MVC.ViewEngine.Generic
{
    using Interfaces.Generic;
    using System;

    public class ActionResult<T> : IActionResult<T>
    {
        #region Constructors
        public ActionResult(string viewFullQualifiedName, T model)
        {
            this.Action = (IRenderable<T>)Activator.CreateInstance(Type.GetType(viewFullQualifiedName));

            Action.Model = model;
        }

        public ActionResult(string fullQualifedName, string location, T model) : this(fullQualifedName, model)
        {
            this.Location = location;
        }
        #endregion

        #region Properties
        public IRenderable<T> Action { get; set; }

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