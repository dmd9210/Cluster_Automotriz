using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClusterAutomotriz_Model;

namespace ClusterAutomotriz_DataAccess
{
    public class EmpresaRepository
    {
       static string ConnectionString = "Data Source=DIEGOMEDRANODIE\\DIEGOMEDRANOSQL;Initial Catalog=Cluster_Automotriz;Integrated Security=True";        

        public static IEnumerable<Empresa> GetEmpresas()
        {


            // Se hare el acceso a la base de datos
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            // Cualquier instruccion de sql server
            connection.Open();
            command.CommandText = "SELECT * FROM Empresa";

            SqlDataReader reader = command.ExecuteReader();
            List<Empresa> empresas = new List<Empresa>();
            while (reader.Read())
            {

                Empresa empresa = new Empresa();
                empresa.idEmpresa = (int)reader["idEmpresa"];
                empresa.Nombre = reader["nombre"] as string;
                empresa.Calle = reader["calle"] as string;
                empresa.Numero = reader["numero"] as string;
                empresa.codigoPostal = reader["codigoPostal"] as string;
                empresa.Estado = reader["estado"] as string;
                empresa.Municipio = reader["municipio"] as string;
                empresa.Pais = reader["pais"] as string;
                empresa.paginaWeb = reader["paginaWeb"] as string;
                empresa.Telefono = reader["telefono"] as string;
                empresa.correoContacto = reader["correoContacto"] as string;
                empresa.tipoEmpresa = reader["tipoEmpresa"] as string;


                empresas.Add(empresa);
            }
            return empresas;
        }

        // Edit
        public static Empresa GetEmpresa(int? id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "SELECT * FROM Empresa WHERE idEmpresa = @id";

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Empresa empresa = new Empresa();
            while (reader.Read())
            {
                empresa.idEmpresa = (int)reader["idEmpresa"];
                empresa.Nombre = reader["nombre"] as string;
                empresa.Calle = reader["calle"] as string;
                empresa.Numero = reader["numero"] as string;
                empresa.codigoPostal = reader["codigoPostal"] as string;
                empresa.Estado = reader["estado"] as string;
                empresa.Municipio = reader["municipio"] as string;
                empresa.Pais = reader["pais"] as string;
                empresa.paginaWeb = reader["paginaWeb"] as string;
                empresa.Telefono = reader["telefono"] as string;
                empresa.correoContacto = reader["correoContacto"] as string;
                empresa.tipoEmpresa = reader["tipoEmpresa"] as string;

            }
            return empresa;
        }
        public static bool InsertEmpresa(Empresa empresa)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"insert into Empresa values(@idEmpresa,@nombre,@calle,@numero,
                                    @codigoPostal,@estado,@municipio,@pais,@paginaweb,@telefono,@correocontacto,@tipoempresa)";
            command.Parameters.AddWithValue("@idEmpresa", empresa.idEmpresa);
            command.Parameters.AddWithValue("@nombre", empresa.Nombre);
            command.Parameters.AddWithValue("@calle", empresa.Calle);
            command.Parameters.AddWithValue("@numero", empresa.Numero);
            command.Parameters.AddWithValue("@codigoPostal", empresa.codigoPostal);
            command.Parameters.AddWithValue("@estado", empresa.Estado);
            command.Parameters.AddWithValue("@municipio", empresa.Municipio);
            command.Parameters.AddWithValue("@pais", empresa.Pais);
            command.Parameters.AddWithValue("@paginaweb", empresa.paginaWeb);
            command.Parameters.AddWithValue("@telefono", empresa.Telefono);
            command.Parameters.AddWithValue("@correocontacto", empresa.correoContacto);
            command.Parameters.AddWithValue("@tipoempresa", empresa.tipoEmpresa);
            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public static bool UpdateEmpresa(Empresa empresa)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"update Empresa
                                    set nombre=@nombre,calle=@calle,numero=@numero,codigoPostal=@codigopostal,
                                    estado=@estado, municipio=@municipio, pais=@pais, paginaWeb=@paginaweb, telefono=@telefono, 
                                    correoContacto=@correocontacto,tipoEmpresa=@tipoempresa where idEmpresa =@idempresa";
            command.Parameters.AddWithValue("@idEmpresa", empresa.idEmpresa);
            command.Parameters.AddWithValue("@nombre", empresa.Nombre);
            command.Parameters.AddWithValue("@calle", empresa.Calle);
            command.Parameters.AddWithValue("@numero", empresa.Numero);
            command.Parameters.AddWithValue("@codigoPostal", empresa.codigoPostal);
            command.Parameters.AddWithValue("@estado", empresa.Estado);
            command.Parameters.AddWithValue("@municipio", empresa.Municipio);
            command.Parameters.AddWithValue("@pais", empresa.Pais);
            command.Parameters.AddWithValue("@paginaweb", empresa.paginaWeb);
            command.Parameters.AddWithValue("@telefono", empresa.Telefono);
            command.Parameters.AddWithValue("@correocontacto", empresa.correoContacto);
            command.Parameters.AddWithValue("@tipoempresa", empresa.tipoEmpresa);

            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;

        }


        // Delete
        public static bool DeleteEmpresa(int? idEmpresa)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "delete Empresa where idEmpresa = @idEmpresa";
            command.Parameters.AddWithValue("@idEmpresa", idEmpresa);
            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}