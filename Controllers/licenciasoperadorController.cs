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
    public class licenciasoperadorController : ControllerBase
    {

        private readonly OraConnect _context;

        public licenciasoperadorController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("licenciasoc")]
        public async Task<IActionResult> licenciasoc()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<LicenciasPorOperador> licenceop = new List<LicenciasPorOperador>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID_LICENCIA");
            query.From("LicenciasPorOperador");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                licenceop = DataReaderMapper<LicenciasPorOperador>.MapToList(reader);
            });
            
            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, licenceop);

        }

        
    }
}