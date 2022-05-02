using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class PlanVO
{
    public int lat;
    public int lon;
    public string donde;
    public string plan;
    

    [JsonConstructor]
    public PlanVO(String lugar, String descripcion, int lat, int lon) {
        this.donde = lugar;
        this.plan = descripcion;
        this.lat = lat;
        this.lon = lon;
    }

    override public String ToString() {
        return "PlanVO ("+  this.donde+","+
                            this.plan+","+
                            this.lat+","+this.lon+")";
    }
}