using Sap.Data.SQLAnywhere;
using System;


/*
    En esta clase se conecta al servidor usando el proveedor de datos SAP.DATA.SQLAnyware
*/

public class Login
{
    string user = "siosad";
    string password = "sadver21";
    public void Connect()
    {
        try
        {            
            SAConnection conn = new SAConnection("Data Source=10.36.50.119;database=Nuevasep;charset=utf-8;Port=1234;UID=" + user + ";PWD=" + password);

            conn.Open();
            Console.WriteLine("Conexion exitosa!!");
            var command = conn.CreateCommand();
            command.CommandText = "SELECT clave_usuario, clave_acceso FROM usuarios";
            var reader = command.ExecuteReader();
            // Get the results.
            while (reader.Read())
            {
                var firstName = reader.GetString(0);
                var lastName = reader.GetString(1);
                Console.WriteLine($"{firstName} {lastName}");

            }

            Console.ReadKey();
            conn.Close();

        }
        catch (SAException e){ Console.WriteLine(e.Message);
        }
        catch (Exception e) { Console.WriteLine(e.StackTrace); }
    }



}