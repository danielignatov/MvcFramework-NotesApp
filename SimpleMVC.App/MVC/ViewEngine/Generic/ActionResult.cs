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
        #endregion

        #region Properties
        public IRenderable<T> Action { get; set; }
        #endregion

        #region Methods
        public string Invoke()
        {
            return this.Action.Render();
        }
        #endregion
    }
}