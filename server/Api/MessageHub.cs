using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using AppLogic.chatsLogic;
  
namespace sever.Controllers
{
    public class MessageHub : Hub
    {

        public async Task NewMessage(Message msg)
        {
            Console.Write("Mensaje:", msg.message, " sender: ",msg.sender, " reciever: ", msg.reciever);
            if(chatsLogic.saveMessage(msg)) {
                await Clients.All.SendAsync(msg.reciever, msg);
            }
        }
    }
}