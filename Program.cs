using System;

using AdoNetCore.AseClient;
using Sap.Data.SQLAnywhere;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string user = "siosad";
            string password = "sadver21";
            try
            {
                AseConnection conn = new AseConnection("Data Source=10.36.50.119;database=Nuevasep;charset=utf-8;Port=1234;UID=" + user + ";PWD=" + password);

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

            }catch(AseException e){ Console.WriteLine(e.Message);
            }catch(Exception e) {  Console.WriteLine(e.StackTrace); }
            

        }
    }
}
