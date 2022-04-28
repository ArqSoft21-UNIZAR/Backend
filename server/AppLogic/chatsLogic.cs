using Model;

namespace AppLogic.chatsLogic;

public class chatsLogic
{
    static chatsDAO service = new chatsDAO();


    public static async Task<ChatVO> getChat(string emisor, string receptor)
    {
        ChatVO output = new ChatVO(emisor,receptor);
        
        foreach (Message m in await service.GetMessages(emisor,receptor))
        {
            output.addMsg(m);
        }

        return output;
    }

    public static async Task<bool> saveMessage(Message m)
    {
        bool output = await service.saveMessage(m.sender,m.reciever,m.message,m.date);
        return output;
    }
}