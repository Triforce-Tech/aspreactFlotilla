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
    public class OrdenOpController : ControllerBase
    {

        private readonly OraConnect _context;

        public OrdenOpController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("orderop")]
        public async Task<IActionResult> orderop()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<OrdenOp> order = new List<OrdenOp>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID");
            query.From("OrdenOp");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                order = DataReaderMapper<OrdenOp>.MapToList(reader);
            });
            
            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, order);

        }





    }
}