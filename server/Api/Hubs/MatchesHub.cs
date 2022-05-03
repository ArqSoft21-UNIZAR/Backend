using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using AppLogic.matchesLogic;
  
namespace sever.Controllers
{
    public class MatchesHub : Hub
    {
        public async void NewMatch(UserVO user1, UserVO user2)
        {
            Console.Write("Nuevo Match, user1: " + user1 + " - user2: " + user2);
            await Clients.All.SendAsync(user1.email, user2);
            await Clients.All.SendAsync(user2.email, user1);                
        }
    }

}