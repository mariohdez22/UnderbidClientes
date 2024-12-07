using Microsoft.AspNetCore.SignalR.Client;

namespace Underbid.Client.Services.SignalR
{
    public class HubRegistroService : IHubRegistroService
    {
        public HubConnection _hubConnection { get; set; }

        public event Func<string, Task> OnRegisterReceived;

        public HubRegistroService()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7050/publicacionesHub")
                .Build();

            _hubConnection.On<string>("PublicacionMensaje", async (registro) =>
            {
                if (OnRegisterReceived != null)

                    await OnRegisterReceived(registro);
            });
        }

        public async Task ConnectAsync()
        {
            if (_hubConnection.State == HubConnectionState.Disconnected)
            {
                await _hubConnection.StartAsync();
            }
        }

        public async Task DisconnectAsync()
        {
            if (_hubConnection.State == HubConnectionState.Connected)
            {
                await _hubConnection.StopAsync();
            }
        }

    }
}
