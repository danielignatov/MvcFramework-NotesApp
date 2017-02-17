namespace SimpleMVC.App.MVC.Interfaces.Generic
{
    public interface IActionResult : IInvocable
    {
        IRenderable Action { get; set; }
    }
}