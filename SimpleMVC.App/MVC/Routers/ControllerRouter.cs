namespace SimpleMVC.App.MVC.Routers
{
    using Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SimpleHttpServer.Models;
    using System.Reflection;
    using Controllers;
    using Attributes.Methods;

    public class ControllerRouter : IHandleable
    {
        #region Fields
        /// <summary>
        /// Dictionary containing transformed query string to name and value pairs.
        /// </summary>
        private IDictionary<string, string> getParams;
        /// <summary>
        /// Dictionary containing transformed content of POST request to name and value pairs.
        /// </summary>
        private IDictionary<string, string> postParams;
        /// <summary>
        /// Type of the request method (GET or POST).
        /// </summary>
        private string requestMethod;
        /// <summary>
        /// Name of the controller.
        /// </summary>
        private string controllerName;
        /// <summary>
        /// Name of the action method in the controller.
        /// </summary>
        private string actionName;
        /// <summary>
        /// Array of parameters which will be passed to the action method when it is executing.
        /// </summary>
        private object[] methodParams;
        #endregion

        #region Methods
        public HttpResponse Handle(HttpRequest request)
        {
            // 1. Parse input from request
            // 1.1 Retrive GET parameters from request URL if there is any
            string[] urlStringParts = request.Url.Split('?');
            this.getParams = new Dictionary<string, string>();

            if (urlStringParts.Count() > 1)
            {
                string[] paramPairs = urlStringParts[1].Split('&');

                foreach (var pair in paramPairs)
                {
                    string[] pairParams = pair.Split('=');

                    this.getParams.Add(pairParams[0], pairParams[1]);
                }
            }

            // 1.2 Retrive POST parameters from request Content if there is any
            if (request.Content != null)
            {
                string[] postContentPairs = request.Content.Split('&');
                this.postParams = new Dictionary<string, string>();

                if (postContentPairs.Count() > 1)
                {
                    foreach (var pair in postContentPairs)
                    {
                        string[] pairParams = pair.Split('=');

                        this.postParams.Add(pairParams[0], pairParams[1]);
                    }
                }
            }

            // 1.3 Retreve request method
            this.requestMethod = request.Method.ToString();

            // 1.4 Retreve Controller and Action names
            string[] urlParams = request.Url.Split('/');

            if (urlParams.Count() == 3)
            {
                string[] actionNameQueryString = urlParams[2].Split('?');

                this.controllerName = urlParams[1].First().ToString().ToUpper() + urlParams[1].Substring(1) + "Controller";
                this.actionName = actionNameQueryString[0].First().ToString().ToUpper() + actionNameQueryString[0].Substring(1);
            }

            // 1.5 Retreve Method
            MethodInfo method = this.GetMethod();

            if (method == null)
            {
                throw new NotSupportedException("No such method.");
            }

            // 1.6 Convert passed params to its appropriate type (primitive or complex)
            IEnumerable<ParameterInfo> parameters
                = method.GetParameters();

            this.methodParams
                = new object[parameters.Count()];

            int index = 0;

            foreach (ParameterInfo param in parameters)
            {
                if (param.ParameterType.IsPrimitive)
                {
                    object value = this.getParams[param.Name];
                    this.methodParams[index] = Convert.ChangeType(
                        value,
                        param.ParameterType);
                    index++;
                }
                else
                {
                    Type bindingModelType = param.ParameterType;
                    object bindingModel =
                        Activator.CreateInstance(bindingModelType);

                    IEnumerable<PropertyInfo> properties
                        = bindingModelType.GetProperties();

                    foreach (PropertyInfo property in properties)
                    {
                        property.SetValue(
                            bindingModel,
                            Convert.ChangeType(
                                postParams[property.Name],
                                property.PropertyType
                                )
                            );
                    }

                    this.methodParams[index] = Convert.ChangeType(
                        bindingModel,
                        bindingModelType);

                    index++;
                }
            }

            // 2. Reflection
            // 2.1 Create new controller with the provided controller name
            IInvocable actionResult =
                (IInvocable)this.GetMethod()
                .Invoke(this.GetController(), this.methodParams);

            // 2.2 Invoke the method with the name provided as action from the controller
            string content = actionResult.Invoke();

            // 3. Set response
            return new HttpResponse()
            {
                ContentAsUTF8 = content,
                StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok
            };
        }

        private MethodInfo GetMethod()
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in this.GetSuitableMethods())
            {
                IEnumerable<Attribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute);

                if (!attributes.Any())
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(this.requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            return this.GetController()
                .GetType()
                .GetMethods()
                .Where(m => m.Name == this.actionName);
        }

        private Controller GetController()
        {
            var controllerType = string.Format(
                "{0}.{1}.{2}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ControllersFolder,
                this.controllerName);

            var controller =
                (Controller)Activator.CreateInstance(Type.GetType(controllerType));

            return controller;
        }
        #endregion
    }
}