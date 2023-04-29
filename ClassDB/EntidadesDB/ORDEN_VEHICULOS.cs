using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class OrdenVehiculos
    {
    public string UUID_ORDEN { get; set; }
    public string UUID_USUARIO { get; set; }
    public string UUID_RUTA { get; set; }
    public string UUID_VEHICULO { get; set; }
    public string KM { get; set; }
    public DateTime FECHA_INGRESO { get; set; }
    public DateTime FECHA_ASIGNACION { get; set; }
    public DateTime FECHA_MODIFICACION { get; set; }
    public DateTime FECHA_CREACION { get; set; }
    public string UUID_ESTADO { get; set; }
    public string DESCRIPCION { get; set; }
    public string EMPRESA { get; set; }
    public DateTime FECHA_ENTREGA { get; set; }
    public DateTime FECHA_RECOLECCION { get; set; }
    public string PRECIO { get; set; }
    public string UUID_TIPO_PRECIO { get; set; }
    }
}
