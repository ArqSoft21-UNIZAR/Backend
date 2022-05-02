public class Message
{
    public string sender { get; set; }
    public string reciever { get; set; }
    public bool isSent { get; set; }
    public string message { get; set; }
    public DateTime date { get; set; }
    
    public Message(string sender, string reciever, string message, DateTime date) {
        this.sender = sender;
        this.reciever = reciever;
        this.message = message;
        this.date = date;
    }
}
