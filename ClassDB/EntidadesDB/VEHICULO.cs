using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class Vehiculo
    {
        public string UUID { get; set; }
        public string UUID_TIPO_VEHICULO { get; set; }
        public string UUID_USUARIO { get; set; }
        public string PLACA { get; set; }
        public string DESCRIPCION { get; set; }
        public DateTime FECHA_CARGA { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
        public string UUID_ESTADO { get; set; }
        public decimal KILOMETRAJE_ACTUAL { get; set; }

    }
}
