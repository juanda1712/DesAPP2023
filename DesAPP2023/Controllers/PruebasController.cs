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
             new clsPruebas()
            {
                ID = 2,
                Name = "Prueba3"

            },

        };


        [HttpGet("Consultar")]
        public List<clsPruebas> Consultar()
        {
            return ListItem;
        }


        [HttpGet("Item")]
        public clsPruebas Item(int id)
        {
            return ListItem[id];
        }

        [HttpGet("Detalle")]
        public dynamic Detail(int id)
        {
            //var hdr_key = Request.Headers["key_app"];
            var hdr_key = Request.Headers.Where(x => x.Key.Equals("key_app")).FirstOrDefault();

            if (hdr_key.Value.Count == 0 )
            {
                return new
                {
                    code = "API ERROR",
                    message = "No esta autorizado",
                    Detail = "N/A"

                };
            }
            else 
            {
               if ( hdr_key.Value != "x1234")
                {
                    return new
                    {
                        code = "API ERROR",
                        message = "Key invalido",
                        Detail = "N/A"

                    };

                }              
            
            
            }



            var item =  ListItem.Where(x => x.ID == id ).ToList();
            if (item.Count > 0)
            {

                if ( id == 0)
                {
                    return new
                    {
                        Data = item,
                        code = "OK",
                        message = "Respuesta Exitosa",
                        Detail = "N/A"
                    };
                }
                else
                {
                 return item;
                }
            }   
            else 
            {
                return new
                {
                    code = "API COUNT",
                    message = "No existen registros",
                    Detail = "N/A"

                };
            
            }


        }
    }
}
