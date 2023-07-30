using ClinicaNuevoRosario.Application.SignalR.Chat;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ClinicaNuevoRosario.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ChatController : Controller
    {
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public ChatController(IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

      
    }
}
