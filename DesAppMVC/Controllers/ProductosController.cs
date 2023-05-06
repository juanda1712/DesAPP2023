using DesAppMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesAppMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        public readonly WebApiContext _dbcontex;
        

        public ProductosController(WebApiContext _contex)
        {
            _dbcontex = _contex;
        }


        [HttpGet]
        [Route("Lista")]
        public IActionResult Listar()
        {

            List<Producto> listProd = new List<Producto>();

            try
            {
                listProd = _dbcontex.Productos.ToList();
                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Consulta Exitosa",
                    Detail = listProd
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Error al consultar",
                    Detail = ex.Message
                });

            }

        }

        [HttpGet]
        [Route("Detalle")]
        public IActionResult Detalle(int id)
        {

             Producto Prod = new Producto();

            try
            {
                //Prod = _dbcontex.Productos.Find(id);
                Prod = _dbcontex.Productos.Include(c => c.DetTipo).Where(p => p.IdProducto == id).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Consulta Exitosa",
                    Detail = Prod
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Error al consultar",
                    Detail = ex.Message
                });

            }

        }



        [HttpPost]
        [Route("Save")]
        public IActionResult Guardar([FromBody] Producto ObjProd)
        {


            try
            {
                _dbcontex.Productos.Add(ObjProd);
                var result = _dbcontex.SaveChanges();
                if(result > 0)
                {
                    return StatusCode(StatusCodes.Status201Created, new
                    {
                        code = "OK",
                        message = "Datos Almacendos Exitosamente",
                        Detail = ""
                    });
                }
                else

                {

                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        code = "OK",
                        message = "No es posible Almacenar Datos",
                        Detail = ""
                    });

                }


            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Error al Guardar",
                    Detail = ex.Message
                });
            }
        }



        [HttpPut]
        [Route("Update")]
        public IActionResult Editar([FromBody] Producto ObjProd)
        {

            Producto Prod = _dbcontex.Productos.Find(ObjProd.IdProducto);

            if (Prod == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    code = "HTTP 400",
                    message = "No es posible Editar Datos",
                    Detail = ""
                });
            }

            try
            {
                Prod.Nombre = ObjProd.Nombre;
                Prod.Descripcion = string.IsNullOrEmpty(ObjProd.Descripcion) ? Prod.Descripcion : ObjProd.Descripcion;

                if (ObjProd.Valor != 0 && ObjProd.Valor != null)
                {
                    Prod.Valor = ObjProd.Valor;
                }
              

                _dbcontex.Productos.Update(Prod);
                _dbcontex.SaveChanges();
              
                    return StatusCode(StatusCodes.Status201Created, new
                    {
                        code = "OK",
                        message = "Datos Modificados Exitosamente",
                        Detail = ""
                    });
          


            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Error al Modificar",
                    Detail = ex.Message
                });
            }
        }


        [HttpDelete]
        [Route("Delete")]
        public IActionResult Eliminar(int id)
        {

            Producto Prod = _dbcontex.Productos.Find(id);

            if (Prod == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    code = "HTTP 400",
                    message = "Datos no encontrados",
                    Detail = ""
                });
            }

            try
            {
           

                _dbcontex.Productos.Remove(Prod);
                _dbcontex.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Datos Eliminados Exitosamente",
                    Detail = ""
                });



            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Error al Eliminar",
                    Detail = ex.Message
                });
            }
        }



    }
}
