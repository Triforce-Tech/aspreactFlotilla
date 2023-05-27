const { createProxyMiddleware } = require('http-proxy-middleware');
const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:44422';

const context = [
    "/weatherforecast",
    "/api/session",
    "/api/login",
    "/api/analista",
    "/api/catalogo",
    "/api/catalogoprecio",
    "/api/drivers",
    "/api/estado",
    "/api/historicogeneral",
    "/api/licenciasoperador",
    "/api/logins",
    "/api/nivelacceso",
    "/api/operador",
    "/api/ordenop",
    "/api/ordenvehiculo",
    "/api/ruta",
    "/api/soporte",
    "/api/soporteresultado",
    "/api/tickets",
    "/api/tipousuario",
    "/api/tipovehiculo",
    "/api/usuario",
    "/api/vehicle",
    "/api/registro",
    "/api/persona",
];



module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: target,
        secure: false,
        headers: {
            Connection: 'Keep-Alive'
        }
    });

    app.use(appProxy);
};
