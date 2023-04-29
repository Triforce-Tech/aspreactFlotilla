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
    public class EstadoController : ControllerBase
    {
        private readonly OraConnect _context;

        public EstadoController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("state")]
        public async Task<IActionResult> state()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<Estado> estados = new List<Estado>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID_ESTADO");
            query.From("Estado");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                estados = DataReaderMapper<Estado>.MapToList(reader);
            });
            
            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, estados);


        
    }
}