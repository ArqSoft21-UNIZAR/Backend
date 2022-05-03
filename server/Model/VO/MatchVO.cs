using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class MatchVO
{
    public String email1;
    public String email2;

    [JsonConstructor]
    public MatchVO(String email1, String email2) {
        this.email1 = email1;
        this.email2 = email2;
    }

    override public String ToString() {
        return "ChatVO ("+  this.email1 +","+
                            this.email2 +")";
    }

}