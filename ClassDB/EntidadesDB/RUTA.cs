using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB.EntidadesDB
{
    public partial class Ruta
    {
        public string UUID_RUTA { get; set; }
        public string DESCRIPCION { get; set; }
        public string COORDENADA_PUNTO_A { get; set; }
        public string COORDENADA_PUNTO_B { get; set; }
        public string LINK_GOOGLE { get; set; }
        public Int64 DISTANCIA_KM { get; set; }
    
    }
}
