using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class TipoVehiculo
    {
        public string UUID { get; set; }
        public string MARCA { get; set; }
        public string MODELO { get; set; }
        public DateTime ? AÑO { get; set; }
        public string DESCRIPCION { get; set; }
        public string TIPO { get; set; }
        public int TIPO_GASOLINA { get; set; }
        public int TIPO_DISEL { get; set; }

    }
}
