using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class HistoricoGeneral
    {
        public string UUID_HISTORIC { get; set; }
        public string UUID_USUARIO { get; set; }
        public string DESCRIPCION { get; set; }
        public string UUID_TRANSACTION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
        public string UUID_CATALOG { get; set; }
        public string IP { get; set; }


        
    }
}
