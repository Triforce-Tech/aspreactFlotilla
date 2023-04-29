using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class OrdenOp
    {
        public string UUID { get; set; }
        public string UUID_OPERADOR { get; set; }
        public string UUID_ORDEN { get; set; }
        public string UUID_ESTADO { get; set; }
        public DateTime FECHA_ASIGNA { get; set; }
        public DateTime FECHA_MODIFICA { get; set; }
        public DateTime FECHA_CANCELA { get; set; }
        public string DESCRIPCION { get; set; }
        public int NO_ORDEN { get; set; }
        public int ORDEN_ENTREA { get; set; }
    
    }
}
