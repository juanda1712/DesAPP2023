using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesAPP2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebasController : ControllerBase
    {


        public static List<clsPruebas> ListItem = new List<clsPruebas>()
        {
            new clsPruebas()
            {
                ID = 0,
                Name = "Prueba1"

            },

               new clsPruebas()
            {
                ID = 1,
                Name = "Prueba2"

            },

        };


        [HttpGet("Consultar")]
        public List<clsPruebas> Consultar()
        {
            return ListItem;
        }


        [HttpGet("Consultar 2")]
        public string Consultar2()
        {
            return "Hola Mundo 2";
        }
    }
}
