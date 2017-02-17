namespace SimpleMVC.App.MVC.Interfaces.Generic
{
    using SimpleHttpServer.Models;

    public interface IHandleable
    {
        HttpResponse Handle(HttpRequest request);
    }
}