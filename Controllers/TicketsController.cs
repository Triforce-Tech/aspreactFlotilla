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
    public class TicketsController : ControllerBase
    {

        private readonly OraConnect _context;

        public TicketsController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("tickets")]
        public async Task<IActionResult> tickets()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<Tickets> tickets = new List<Tickets>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID_TICKET");
            query.From("Tickets");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                tickets = DataReaderMapper<Tickets>.MapToList(reader);
            });

            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, tickets);

        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Tickets request)
        {

            var query = new Query("Vehiculo").AsInsert(new
            {
                UUID_TICKET = request.UUID_TICKET,
                DESCRIPTION = request.DESCRIPTION,
                FECHA_REGISTRO = new DateTime(2009, 8, 4),
                ESTADO = request.ESTADO,
                FECHA_ASIGNACION = new DateTime(2009, 8, 4),
                FECHA_MODIFICACION = new DateTime(2009, 8, 4),
                FECHA_CANCELACION = new DateTime(2009, 8, 4),
                UUID_USUARIO = request.UUID_USUARIO
            });
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            var sql = execute.ExecuterCompiler(query);

            //var resp = execute.ExecuterOracle(sql);
            var resp = execute.ExecuterOracle(sql);
            return StatusCode(StatusCodes.Status200OK, resp);

        }

    }
}
