using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class Analista
    {
        public string UUID { get; set; }
        public string UUID_USUARIO { get; set; }
        public string ESTADO { get; set; }
        public DateTime FECHA_ALTA { get; set; }
        public DateTime FECHA_BAJA { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
        public  int TICKETS_RESUELTOS { get; set; }
        public int TICKETS_EXITOSOS { get; set; }
        public int TICKETS_FALLO { get; set; }
        public int TICKETS_CANCELA { get; set; }

    }
}
