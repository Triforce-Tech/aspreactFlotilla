using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class LicenciasPorOperador
    {
    
        public string UUID_LICENCIA { get; set; }
        public string UUID_OPERADOR { get; set; }
        public string TIPO { get; set; }
        public string DESCRIPCION { get; set; }

        public DateTime FECHA_EMISION { get; set; }
        public DateTime FECHA_CADUCIDAD { get; set; }
    
    }
}
