namespace SimpleHttpServer
{
    using SimpleHttpServer.Models;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    public class HttpServer
    {
        #region Constructors
        public HttpServer(int port, IEnumerable<Route> routes)
        {
            this.Port = port;
            this.IsActive = true;
            this.Sessions = new Dictionary<string, HttpSession>();
            this.Processor = new HttpProcessor(routes, this.Sessions);
        }
        #endregion

        #region Properties
        public TcpListener Listener { get; private set; }

        public int Port { get; private set; }

        public HttpProcessor Processor { get; private set; }

        public bool IsActive { get; private set; }

        public IDictionary<string, HttpSession> Sessions { get; set; }
        #endregion

        public void Listen()
        {
            this.Listener = new TcpListener(IPAddress.Any, this.Port);
            this.Listener.Start();
            while (this.IsActive)
            {
                TcpClient client = this.Listener.AcceptTcpClient();
                Thread thread = new Thread(() =>
                {
                    this.Processor.HandleClient(client);
                });
                thread.Start();
                Thread.Sleep(1);
            }
        }
    }
}