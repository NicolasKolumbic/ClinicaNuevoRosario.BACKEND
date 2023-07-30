namespace ClinicaNuevoRosario.Application.SignalR.Chat
{
    public interface IHubClient
    {
        Task BroadcastMessage();
    }
}
