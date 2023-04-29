using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class TipoUsuario

    {
        public string UUID { get; set; }
        public string UUID_NIVEL { get; set; }
        public string TIPO { get; set; }
        public string DESCRIPCION { get; set; }
        public string UUID_ESTADO { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        
    }
}
