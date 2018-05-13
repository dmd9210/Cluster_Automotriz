using ClusterAutomotriz_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterAutomotriz_DataAccess
{
    public class Empresa_ActividadRepository
    {
        static string ConnectionString = "Data Source=DIEGOMEDRANODIE\\DIEGOMEDRANOSQL;Initial Catalog=Cluster_Automotriz;Integrated Security=True";
        public static IEnumerable<Empresa_Actividad> GetEmpresas()
        {                    
            // Se hare el acceso a la base de datos
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            // Cualquier instruccion de sql server
            connection.Open();
            command.CommandText = @"select e.nombre,a.nombreActividad
                                    from Empresa e, Actividad a, Empresa_Actividad c
                                    where e.idEmpresa = c.idEmpresa and a.idActividad = c.idActividad;";

            SqlDataReader reader = command.ExecuteReader();
            List<Empresa_Actividad> empresas = new List<Empresa_Actividad>();
            while (reader.Read())
            {

                Empresa_Actividad empresa = new Empresa_Actividad();                
                empresa.nombreEmpresa = reader["nombre"] as string;
                empresa.nombreActividad = reader["nombreActividad"] as string;
                empresas.Add(empresa);
            }
            return empresas;
        }
    }
}
