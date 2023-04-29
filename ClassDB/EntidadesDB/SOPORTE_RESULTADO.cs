using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class SoporteResultado
    {
        public string UUID_RESULT { get; set; }
        public string UUID_SOPORTE { get; set; }
        public string ESTADO { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
    }
}
