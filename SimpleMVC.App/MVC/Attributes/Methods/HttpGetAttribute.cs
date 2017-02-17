namespace SimpleMVC.App.MVC.Attributes.Methods
{
    using System;

    public class HttpGetAttribute : HttpMethodAttribute
    {
        #region Methods
        /// <summary>
        /// Check if the request method is equal to GET.
        /// </summary>
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper() == "GET")
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}