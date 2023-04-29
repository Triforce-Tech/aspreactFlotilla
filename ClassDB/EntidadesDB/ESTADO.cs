using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial  class Estado
    {
        public string UUID_ESTADO { get; set; }
        public string DESCRIPCION { get; set; }
        public DateTime FECHA_INGRESO { get; set; }
        public DateTime FECHA_MODIFICA { get; set; }

    }
}
