using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class Tickets
    {
    public string UUID { get; set; }
    public string DESCRIPTION { get; set; }
    public DateTime FECHA_REGISTRO { get; set; }
    public string ESTADO { get; set; }
    public DateTime FECHA_ASIGNACION { get; set; }
    public DateTime FECHA_MODIFICACION { get; set; }
    public DateTime FECHA_CANCELACION { get; set; }
    public string UUID_USUARIO { get; set; }

    }
}
