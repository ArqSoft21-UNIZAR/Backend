using System;

public class UserDTO
{
    public string email { get; set; }
    public string password  { get; set; }
    
    public UserDTO(string email, string password) {
        this.email = email;
        this.password = password;
    }
}