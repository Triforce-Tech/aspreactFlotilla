using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class UserSession
    {
        public string UUID { get; set; }
        public string USUARIO { get; set; }
        public string PASSWORD { get; set; }
        public string UUID_ESTADO { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public DateTime FECHA_BAJA { get; set; }
    
    }
}
