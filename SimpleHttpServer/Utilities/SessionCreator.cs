namespace SimpleHttpServer.Utilities
{
    using Models;
    using System;

    public static class SessionCreator
    {
        public static HttpSession Create()
        {
            var sessionId = new Random().Next().ToString();
            var session = new HttpSession(sessionId);

            return session;
        }
    }
}