using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections;
using ClusterAutomotriz_Model;

namespace ClusterAutomotriz_DataAccess
{
    public class ActividadRepository
    {

        public ActividadRepository()
        {

        }

        static string ConnectionString = "Data Source=DIEGOMEDRANODIE\\DIEGOMEDRANOSQL;Initial Catalog=Cluster_Automotriz;Integrated Security=True";        

        public static IEnumerable<Actividad> GetActividades()
        {
            // Se hare el acceso a la base de datos
            SqlConnection connection = new SqlConnection(ConnectionString);
            // Cualquier instruccion de sql server
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Actividad";

            SqlDataReader reader = command.ExecuteReader();

            List<Actividad> resultado = new List<Actividad>();
            while (reader.Read())
            {
                Actividad actividad = new Actividad();
                actividad.idActividad = (int)reader["idActividad"];
                actividad.nombreActividad = reader["nombreActividad"] as string;
                
                
                resultado.Add(actividad);
            }
            connection.Close();
            return resultado;
        }

        //Edit
        public static Actividad GetActividad(int? id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"select *from Actividad a where a.idActividad = @id ";
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Actividad actividad = new Actividad();
            while(reader.Read())
            {

                actividad.idActividad = (int)reader["idActividad"];
                actividad.nombreActividad = reader["nombreActividad"] as string;
            }

            connection.Close();
            return actividad;


        }

        public static bool InsertActividad(Actividad actividad)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"insert into Actividad(idActividad,nombreActividad) 
                                   values(@idActividad, @nombreActividad)";

            command.Parameters.AddWithValue("@idActividad", actividad.idActividad);
            command.Parameters.AddWithValue("@nombreActividad", actividad.nombreActividad);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
                return true;
            else
                return false;
        }
        public static bool UpdateActividad(Actividad actividad)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"update Actividad
                                    set idActividad=@idActividad, nombreActividad=@nombreActividad where idActividad =@idActividad";

            command.Parameters.AddWithValue("@idActividad",actividad.idActividad);
            command.Parameters.AddWithValue("@nombreActividad", actividad.nombreActividad);

            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
                return true;
            else
                return false;
        }


        public static bool DeleteActividad(int id)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "delete Actividad where idActividad=@idActividad";
            command.Parameters.AddWithValue("@idActividad", id);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
