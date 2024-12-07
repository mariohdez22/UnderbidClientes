namespace Underbid.Client.Services.SignalR
{
    public interface IHubRegistroService
    {
        event Func<string, Task> OnRegisterReceived;

        Task ConnectAsync();

        Task DisconnectAsync();
    }
}
