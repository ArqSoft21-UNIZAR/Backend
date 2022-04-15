using System;

public class UserVO
{
    public string email { get; set; }
    public string password { get; set; }
    public string nombre { get; set; }
    public string apellidos { get; set; }
    public string sexo { get; set; }
    public int edad { get; set; }
    public string localidad { get; set; }
    public string meGusta1 { get; set; }
    public string meGusta2 { get; set; }
    public string meGusta3 { get; set; }
    public string noMeGusta1 { get; set; }
    public string noMeGusta2 { get; set; }
    public string noMeGusta3 { get; set; }
    public string foto { get; set; }//Temporal
    
    public UserVO(string email, string password="", string nombre="", string apellidos="", string sexo="", int edad=18, string localidad="", string meGusta1="", string meGusta2="", string meGusta3="", string noMeGusta1="", string noMeGusta2="", string noMeGusta3="") {
        this.email = email;
        this.password = password;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.sexo = sexo;
        this.edad = edad;
        this.localidad = localidad;
        this.meGusta1 = meGusta1;
        this.meGusta2 = meGusta2;
        this.meGusta3 = meGusta3;
        this.noMeGusta1 = noMeGusta1;
        this.noMeGusta2 = noMeGusta2;
        this.noMeGusta3 = noMeGusta3;
        this.foto = "";
    }
}