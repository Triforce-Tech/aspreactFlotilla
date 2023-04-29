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
    public class DriversController : ControllerBase
    {

        private readonly OraConnect _context;

        public DriversController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("drivers")]
        public async Task<IActionResult> drivers()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<Operador> driver = new List<Operador>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID");
            query.From("Operador");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                driver = DataReaderMapper<Operador>.MapToList(reader);
            });

            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, driver);

        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Operador request)
        {

            var query = new Query("Operador").AsInsert(new
            {
                
                UUID_USUARIO = request.UUID_USUARIO,
                FECHA_ALTA = new DateTime(2009, 8, 4),
                FECHA_BAJA = new DateTime(2009, 8, 4),
                UUID_LICENCIA = request.UUID_LICENCIA,
                NO_LICENCIAS = request.NO_LICENCIAS
            });
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            var sql = execute.ExecuterCompiler(query);

    
            //var resp = execute.ExecuterOracle(sql);


        var resp = "";
            return StatusCode(StatusCodes.Status200OK, resp);

        }

    }
}
