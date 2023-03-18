using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesAPP2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebasController : ControllerBase
    {

        [HttpGet("Consultar")]
        public string Consultar()
        {
            return "Hola Mundo";
        }


        [HttpGet("Consultar 2")]
        public string Consultar2()
        {
            return "Hola Mundo 2";
        }
    }
}
