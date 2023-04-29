using ClassDB.ConnectDB;
using ClassDB.EntidadesDB;
using ClassDB.SqlKataTools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlKata;

namespace FlotillaNETCoreReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        //[HttpGet]
        //[Route("Lista")]
        //public async Task<IActionResult> Lista()
        //{
        //    //UserSession request = new UserSession();
        //    ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
        //    //var usuario = request.USUARIO;
        //    //var password = request.PASSWORD;
        //    List<UserSession> lista = new List<UserSession>();
        //    UserSession usuario = new UserSession();

        //    //query en sqlkata

        //    Query query = new Query();
        //    query.Select("*");
        //    query.From("USERSESSION");
        //    //query.Where("usuario", usuario);
        //    //query.Where("password", password);
        //    var sql = execute.ExecuterCompiler(query);

        //    await Task.Run(() =>
        //    execute.DataReader(sql.ToString(), reader =>
        //    {
        //        lista = DataReaderMapper<UserSession>.MapToList(reader).ToList();
        //    })

        //    );

        //    //List<Contacto> lista = await _dbcontext.Contactos.OrderByDescending(c => c.IdContacto).ToListAsync();

        //    return StatusCode(StatusCodes.Status200OK, lista);
        //}


        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser(UserSession request)
        {
            //UserSession request = new UserSession();
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            //var usuario = request.USUARIO;
            //var password = request.PASSWORD;
            List<UserSession> lista = new List<UserSession>();
            UserSession usuario = new UserSession();

            //query en sqlkata

            Query query = new Query();
            query.Select("COUNT(*)");
            query.From("USERSESSION");
            query.Where("USUARIO", "=", request.USUARIO);
            query.Where("PASSWORD", "=", request.PASSWORD);
            //query.Where("usuario", usuario);
            //query.Where("password", password);
            var sql = execute.ExecuterCompiler(query);

            await Task.Run(() =>
            execute.DataReader(sql.ToString(), reader =>
            {
                lista = DataReaderMapper<UserSession>.MapToList(reader).ToList();
            })

            );

            //List<Contacto> lista = await _dbcontext.Contactos.OrderByDescending(c => c.IdContacto).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);

        }


    }
}

