using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class DateVO
{
    public String email1;
    public String email2;
    public DateTime momento;
    public PlanVO plan;
    

    [JsonConstructor]
    public DateVO(String email1, String email2, DateTime momento, PlanVO plan) {
        if(string.Compare(email1,email2)>=0) {
            this.email1 = email1;
            this.email2 = email2;
        }
        else {
            this.email1 = email2;
            this.email2 = email1;
        }
        this.momento = momento;
        this.plan = plan;
    }
}