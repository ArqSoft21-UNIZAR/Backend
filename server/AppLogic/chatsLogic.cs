using Model;

namespace AppLogic.chatsLogic;

public class chatsLogic
{
    static chatsDAO service = new chatsDAO();

    public static void getChats(string email)
    {

    }

    public static bool saveMessage(Message m)
    {
        return service.saveMessage(m.sender,m.reciever,m.message,m.date);
    }
}