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
    public class SoporteController : ControllerBase
    {

        private readonly OraConnect _context;

        public SoporteController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("support")]
        public async Task<IActionResult> support()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<Soporte> support = new List<Soporte>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID");
            query.From("Soporte");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                support = DataReaderMapper<Soporte>.MapToList(reader);
            });

            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, support);

        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Soporte request)
        {

            var query = new Query("Soporte").AsInsert(new
            {
                UUID = request.UUID,
                UUID_TICKET = request.UUID_TICKET,
                FECHA_ASIGNACION = new DateTime(2009, 8, 4),
                FECHA_REGISTRO = new DateTime(2009, 8, 4),
                ESTADO = request.ESTADO,
                FECHA_MODIFICACION = new DateTime(2009, 8, 4),
                UUID_ANALISTA = request.UUID_ANALISTA
            });
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            var sql = execute.ExecuterCompiler(query);

            //var resp = execute.ExecuterOracle(sql);
        var resp = "";
            return StatusCode(StatusCodes.Status200OK, resp);

        }

    }
}
