using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterAutomotriz_Model
{
    public class Empresa
    {

        public int idEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string codigoPostal { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Pais { get; set; }
        public string paginaWeb { get; set; }
        public string Telefono { get; set; }
        public string correoContacto { get; set; }
        public string tipoEmpresa { get; set; }

    }

}
