// See https://aka.ms/new-console-template for more information
using ClassDB.ConnectDB;
using ClassDB.ConnectDB.ConectionDecider;
using ClassDB.EntidadesDB;
using ClassDB.SqlKataTools;
using Microsoft.Win32;
using SqlKata;

Console.WriteLine("Hello, World!");
//Environment.CurrentDirectory = Environment.GetEnvironmentVariable("HKCU\\Environment");
//DirectoryInfo info = new DirectoryInfo(".");




ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

//var usuario = request.USUARIO;
//var password = request.PASSWORD;
UserSession users = new UserSession();

//query en sqlkata

Query query = new Query();
query.Select("USUARIO");
query.From("USERSESSION");
//query.Where("usuario", usuario);
//query.Where("password", password);
var sql = execute.ExecuterCompiler(query);


execute.DataReader(sql.ToString(), reader =>
{
    users = DataReaderMapper<UserSession>.MapToObject(reader);
});


Console.WriteLine("data : "+users.USUARIO);
Console.WriteLine("data : "+users.USUARIO);
Console.WriteLine("data : "+users.USUARIO);
Console.WriteLine("data : "+users.USUARIO);