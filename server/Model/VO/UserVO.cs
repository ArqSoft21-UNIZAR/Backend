using System;
using Newtonsoft.Json;

public class UserVO
{
    public string email { get; set; }
    public string password { get; set; }
    public string nombre { get; set; }
    public string apellidos { get; set; }
    public DateTime fNacimiento { get; set; }
    public string sexo { get; set; }
    public string localidad { get; set; }
    public string meGusta1 { get; set; }
    public string meGusta2 { get; set; }
    public string meGusta3 { get; set; }
    public string noMeGusta1 { get; set; }
    public string noMeGusta2 { get; set; }
    public string noMeGusta3 { get; set; }
    public string foto { get; set; }//Temporal
    
    [JsonConstructor]
    public UserVO(string email, string fNacimiento="", string password="", string nombre="", string apellidos="", string sexo="", string localidad="", string meGusta1="", string meGusta2="", string meGusta3="", string noMeGusta1="", string noMeGusta2="", string noMeGusta3="") {
        this.email = email;
        this.password = password;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.sexo = sexo;
        this.fNacimiento = (fNacimiento!=null ? DateTime.ParseExact(fNacimiento, "yyyy-MM-dd", null) : new DateTime());
        this.localidad = localidad;
        this.meGusta1 = meGusta1;
        this.meGusta2 = meGusta2;
        this.meGusta3 = meGusta3;
        this.noMeGusta1 = noMeGusta1;
        this.noMeGusta2 = noMeGusta2;
        this.noMeGusta3 = noMeGusta3;
        this.foto = "";
    }

    public UserVO(string email, DateTime fNacimiento, string password="", string nombre="", string apellidos="", string sexo="", string localidad="", string meGusta1="", string meGusta2="", string meGusta3="", string noMeGusta1="", string noMeGusta2="", string noMeGusta3="") {
        this.email = email;
        this.password = password;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.sexo = sexo;
        this.fNacimiento = fNacimiento;
        this.localidad = localidad;
        this.meGusta1 = meGusta1;
        this.meGusta2 = meGusta2;
        this.meGusta3 = meGusta3;
        this.noMeGusta1 = noMeGusta1;
        this.noMeGusta2 = noMeGusta2;
        this.noMeGusta3 = noMeGusta3;
        this.foto = "";
    }
    
    override public String ToString() {
        return "UserVO ("+  this.email+","+
                            this.password+","+
                            this.nombre+","+
                            this.apellidos+","+
                            this.sexo+","+
                            this.localidad+","+
                            this.fNacimiento+","+
                            this.meGusta1+","+
                            this.meGusta2+","+
                            this.meGusta3+","+
                            this.noMeGusta1+","+
                            this.noMeGusta2+","+
                            this.noMeGusta3+","+
                            this.foto+")";
    }
}
