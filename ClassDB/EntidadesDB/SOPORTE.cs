using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class Soporte
    {
        public string UUID_SOPORTE { get; set; }
        public string UUID_TICKET { get; set; }
        public DateTime FECHA_ASIGNACION { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public string ESTADO { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
        public string UUID_ANALISTA { get; set; }

    }
}
