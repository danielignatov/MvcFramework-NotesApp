namespace SimpleMVC.App.MVC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MvcContext
    {
        #region Singleton
        public static readonly MvcContext Current = new MvcContext();
        #endregion

        #region Constructors
        public MvcContext()
        {

        }
        #endregion

        #region Properties
        public string AssemblyName { get; set; }

        public string ControllersFolder { get; set; }

        public string ControllersSuffix { get; set; }

        public string ViewsFolder { get; set; }

        public string ModelsFolder { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}