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
    public class AnalistaController : Controller
    {
         private readonly OraConnect _context;

        public AnalistaController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("analyst")]
        public async Task<IActionResult> analyst()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<Analista> analista = new List<Analista>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID_ANALISTA");
            query.From("Analista");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                analista = DataReaderMapper<Analista>.MapToList(reader);
            });
            
            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, analista);

        }


    }
}