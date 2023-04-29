using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class Catalogo
    {
        public string UUID { get; set; }
        public string CATALOGO { get; set; }
        public string DESCRIPCION { get; set; }
        public string UUID_ESTADO { get; set; }
        public DateTime FECHA_MODIFICACION_CATALOGO { get; set; }
        public DateTime FECHA_CREACION { get; set; }



    }
}
