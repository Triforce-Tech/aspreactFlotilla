using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class Operador
    {
        public string UUID { get; set; }
        public string UUID_USUARIO { get; set; }
        public DateTime FECHA_ALTA { get; set; }
        public string FECHA_BAJA { get; set; }
        public string UUID_LICENCIA { get; set; }
        public int NO_LICENCIAS { get; set; }

    
    }
}
