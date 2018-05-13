using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections;
using ClusterAutomotriz_Model;

namespace ClusterAutomotriz_DataAccess
{
    public class AdminRepository
    {
        public AdminRepository()
        {

        }

        public string ConnectionString { get; set; }

        public IEnumerable<Admin> GetAdmin()
        {
            // Se hare el acceso a la base de datos
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            // Cualquier instruccion de sql server
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "SELECT * FROM Admin";

            SqlDataReader reader = command.ExecuteReader();

            List<Admin> resultado = new List<Admin>();
            while (reader.Read())
            {
                Admin admin = new Admin();

                admin.Id = (int)reader["Id"];
                admin.User = reader["User"] as string;
                admin.Password = reader["Password"] as string;


                resultado.Add(admin);
            }
            return resultado;
        }
    }
}
