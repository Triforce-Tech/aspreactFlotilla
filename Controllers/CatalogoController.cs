using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassDB.EntidadesDB;
using ClassDB.ConnectDB;
using SqlKata;
using ClassDB.SqlKataTools;

namespace Flotilla_netCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
 private readonly OraConnect _context;

        public CatalogoController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("control")]
        public async Task<IActionResult> control()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<Catalogo> catalogos = new List<Catalogo>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID");
            query.From("Catalogo");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                catalogos = DataReaderMapper<Catalogo>.MapToList(reader);
            });
            
            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, catalogos);

        }



        
    }
}