using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassDB.EntidadesDB;
using ClassDB.ConnectDB;
using SqlKata;
using ClassDB.SqlKataTools;

namespace Flotilla_netCORE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogoPrecioController : ControllerBase
    {
        private readonly OraConnect _context;

        public CatalogoPrecioController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("catalogop")]
        public async Task<IActionResult> catalogop()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<CatalogoPrecio> clprecio = new List<CatalogoPrecio>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID_TIPO_PRECIO");
            query.From("CatalogoPrecio");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                clprecio = DataReaderMapper<CatalogoPrecio>.MapToList(reader);
            });
            
            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, clprecio);

        }





    }
}