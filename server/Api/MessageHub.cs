using Microsoft.AspNetCore.SignalR;  
using System.Threading.Tasks;  
  
namespace sever.Controllers
{
    public class MessageHub : Hub
    {
        public async Task NewMessage(Message msg)
        {
            Console.Write("Mensaje:", msg.message, " sender: ",msg.sender, " reciever: ", msg.reciever);
            await Clients.All.SendAsync(msg.reciever, msg);
            //TODO: Guardar el mensaje en chatsController.
        }
    }
}