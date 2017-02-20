namespace SimpleHttpServer.Models
{
    using System.Collections.Generic;

    public class HttpSession
    {
        #region Fields
        private IDictionary<string, string> parameters;
        #endregion

        #region Constructors
        public HttpSession(string id)
        {
            this.parameters = new Dictionary<string, string>();
            this.Id = id;
        }
        #endregion

        #region Properties
        public string Id { get; private set; }

        public string this[string key]
        {
            get { return this.parameters[key]; }
        }
        #endregion

        #region Methods
        public void Clear()
        {
            this.parameters.Clear();
        }

        public void Add(string key, string value)
        {
            this.parameters.Add(key, value);
        }
        #endregion
    }
}