namespace SimpleMVC.App.MVC.Attributes.Methods
{
    using System;

    public class HttpPostAttribute : HttpMethodAttribute
    {
        #region Methods
        /// <summary>
        /// Check if the request method is equal to POST.
        /// </summary>
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper() == "POST")
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}