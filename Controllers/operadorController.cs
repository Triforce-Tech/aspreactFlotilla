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
    public class operadorController : Controller
    {
         [HttpPost]
        [Route("guardaOperador")]
        public async Task<IActionResult> guardaOperador([FromBody] Operador request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("OPERADOR").AsInsert(new
            {
            UUID_USUARIO = request.UUID_USUARIO,
            FECHA_ALTA = request.FECHA_ALTA,
            FECHA_BAJA = request.FECHA_BAJA,
            UUID_LICENCIA = request.UUID_LICENCIA,
            NO_LICENCIAS = request.NO_LICENCIAS
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp);

        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<Operador> listaOperador = new List<Operador>();

            Query query = new Query();
            query.Select(
            "UUID_USUARIO",
            "FECHA_ALTA",
            "FECHA_BAJA",
            "UUID_LICENCIA",
            "NO_LICENCIAS"
            );
            query.From("OPERADOR");

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                listaOperador = DataReaderMapper<Operador>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, listaOperador);
        }

        [HttpPut]
        [Route("actualizaOperador")]
        public async Task<IActionResult> actualizaOperador([FromBody] Operador request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("OPERADOR").AsInsert(new
            {
            UUID_USUARIO = request.UUID_USUARIO,
            FECHA_ALTA = request.FECHA_ALTA,
            FECHA_BAJA = request.FECHA_BAJA,
            UUID_LICENCIA = request.UUID_LICENCIA,
            NO_LICENCIAS = request.NO_LICENCIAS
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp);

        }
   

    }
}