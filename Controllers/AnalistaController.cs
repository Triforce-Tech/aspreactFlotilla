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
            query.Select("UUID");
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

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Analista request)
        {

            var query = new Query("Analista").AsInsert(new
            {
                UUID = request.UUID,
                UUID_USUARIO = request.UUID_USUARIO,
                ESTADO = request.ESTADO,
                FECHA_ALTA = new DateTime(2009, 8, 4),
                FECHA_BAJA = new DateTime(2009, 8, 4),
                FECHA_MODIFICACION = new DateTime(2009, 8, 4),
                TICKETS_RESUELTOS = request.TICKETS_RESUELTOS,
                TICKETS_EXITOSOS = request.TICKETS_EXITOSOS,
                TICKETS_FALLO = request.TICKETS_FALLO,
                TICKETS_CANCELA = request.TICKETS_CANCELA
            });
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            var sql = execute.ExecuterCompiler(query);

            //var resp = execute.ExecuterOracle(sql);
            var resp = "";
            return StatusCode(StatusCodes.Status200OK, resp);

        }


    }
}