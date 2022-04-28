using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ChatVO
{
    public String emisor;
    public String receptor;
    public List<Message> data;

    [JsonConstructor]
    public ChatVO(String emisor, String receptor) {
        this.emisor = emisor;
        this.receptor = receptor;
        this.data = new List<Message>();
    }

    public bool addMsg(Message m) {
        if(((m.sender == emisor) && (m.reciever == receptor)) || ((m.sender == receptor) && (m.reciever == emisor)))
        {
            data.Add(m);
            return true;
        }
        return false;
    }

    override public String ToString() {
        return "ChatVO ("+  this.emisor+","+
                            this.receptor+","+
                            this.data + ")";
    }
}