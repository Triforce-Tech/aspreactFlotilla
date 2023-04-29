using ClassDB.ConnectDB;
using ClassDB.EntidadesDB;
using ClassDB.SqlKataTools;
using Microsoft.AspNetCore.Mvc;
using SqlKata;

namespace ASPFLOTILLANETREACT.Controllers
{
    public class RegistroController : Controller
    {

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            //UserSession request = new UserSession();
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            //var usuario = request.USUARIO;
            //var password = request.PASSWORD;
            List<Estado> lista = new List<Estado>();
            UserSession usuario = new UserSession();

            //query en sqlkata

            Query query = new Query();
            query.Select("*");
            query.From("ESTADO");
            //query.Where("usuario", usuario);
            //query.Where("password", password);
            var sql = execute.ExecuterCompiler(query);

            await Task.Run(() =>
            execute.DataReader(sql.ToString(), reader =>
            {
                lista = DataReaderMapper<Estado>.MapToList(reader).ToList();
            })

            );

            //List<Contacto> lista = await _dbcontext.Contactos.OrderByDescending(c => c.IdContacto).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }






    }
}
