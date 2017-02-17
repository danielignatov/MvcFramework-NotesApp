namespace SimpleMVC.App.MVC.Attributes.Methods
{
    using System;

    public abstract class HttpMethodAttribute : Attribute
    {
        #region Methods
        public abstract bool IsValid(string requestMethod);
        #endregion
    }
}