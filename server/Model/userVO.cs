using System;

public class UserVO
{
    public string email { get; set; }
    public string password  { get; set; }
    
    public UserVO(string email, string password) {
        this.email = email;
        this.password = password;
    }
}