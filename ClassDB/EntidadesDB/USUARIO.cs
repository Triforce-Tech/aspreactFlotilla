using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class Usuario
    {
        public string UUID_USUARIO { get; set; }
        public string PRIMER_NOMBRE { get; set; }
        public string SEGUNDO_NOMBRE { get; set; }
        public string TERCER_NOMBER { get; set; }
        public string PRIMER_APELLIDO { get; set; }
        public string SEGUNDO_APELLIDO { get; set; }
        public int DPI { get; set; }
        public string DIRECCION { get; set; }
        public int TELEFONO { get; set; }
        public string CORREO { get; set; }
        public string EMPRESA { get; set; }
        public DateTime FECHA_INGRESO { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
        public string UUID_ESTADO { get; set; }
        public string UUID_TIPO_USUARIO { get; set; }
        public string UUID_USER_SESSION { get; set; }
   
    }
}
