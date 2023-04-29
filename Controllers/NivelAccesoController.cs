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
    public class NivelAccesoController : ControllerBase
    {
         private readonly OraConnect _context;

        public NivelAccesoController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("levelaccess")]
        public async Task<IActionResult> levelaccess()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<NivelAccesso> levela = new List<NivelAccesso>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID_NIVEL");
            query.From("NivelAccesso");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                levela = DataReaderMapper<NivelAccesso>.MapToList(reader);
            });
            
            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, levela);

        }
 
    }
}