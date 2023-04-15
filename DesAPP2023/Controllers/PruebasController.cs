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

            if (hdr_key.Value.Count == 0)
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
                if (hdr_key.Value != "x1234")
                {
                    return new
                    {
                        code = "API ERROR",
                        message = "Key invalido",
                        Detail = "N/A"

                    };

                }


            }



            var item = ListItem.Where(x => x.ID == id).ToList();
            if (item.Count > 0)
            {

                if (id == 0)
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


        [HttpPost("Save")]
        public IActionResult Save([FromBody] clsPruebas item)
        {
            //var hdr_key = Request.Headers["key_app"];
            var hdr_key = Request.Headers.Where(x => x.Key.Equals("key_app")).FirstOrDefault();

            if (hdr_key.Value.Count == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    code = "API001",
                    message = "Falta Parametro",
                    Detail = ""
                });


            }
            else
            {
                if (hdr_key.Value != "x1234")
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new
                    {
                        code = "API002",
                        message = "No Autorizado",
                        Detail = ""
                    });
                }


                ListItem.Add(item);
                return StatusCode(StatusCodes.Status201Created, new
                {
                    code = "OK",
                    message = "Datos Almacenados",
                    Detail = item
                });

            }

        }




        [HttpPut("update")]
        public IActionResult update([FromBody] clsPruebas item)
        {
            //var hdr_key = Request.Headers["key_app"];
            var hdr_key = Request.Headers.Where(x => x.Key.Equals("key_app")).FirstOrDefault();

            if (hdr_key.Value.Count == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    code = "API001",
                    message = "Falta Parametro",
                    Detail = ""
                });


            }
            else
            {
                if (hdr_key.Value != "x1234")
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new
                    {
                        code = "API002",
                        message = "No Autorizado",
                        Detail = ""
                    });
                }



                foreach ( var det in ListItem.Where(x => x.ID == item.ID).ToList())
                {                    
                     det.Name = item.Name;                
                }


                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Datos Modificados",
                    Detail = item
                });


            }

        }



        [HttpDelete("Delete")]
        public IActionResult delete( int id)
        {
            //var hdr_key = Request.Headers["key_app"];
            var hdr_key = Request.Headers.Where(x => x.Key.Equals("key_app")).FirstOrDefault();

            if (hdr_key.Value.Count == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    code = "API001",
                    message = "Falta Parametro",
                    Detail = ""
                });


            }
            else
            {
                if (hdr_key.Value != "x1234")
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new
                    {
                        code = "API002",
                        message = "No Autorizado",
                        Detail = ""
                    });
                }


                if(id.Equals(0))
                {
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        code = "OK",
                        message = "ID invalido",
                        Detail = "0"
                    });
                }
                else 
                {

                    clsPruebas objprueba = (clsPruebas) ListItem.Where(x => x.ID == id).First();
                    if (objprueba != null)
                        ListItem.Remove(objprueba);

                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        code = "OK",
                        message = "Datos Eliminados",
                        Detail = id
                    });
                }






            }

        }




    }
}
