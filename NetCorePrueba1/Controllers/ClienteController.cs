using Microsoft.AspNetCore.Mvc;
using NetCorePrueba1.Models;

namespace NetCorePrueba1.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {
            //Agregarmos code pero siempre con return para recibir respuesta del API

            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    id = "1",
                    nombre = "Adrian Celis",
                    cargo = "Analista Programador",
                    correo = "adriancelistorres184@gmail.com",
                    edad = "20"
                },
                new Cliente
                {
                    id = "2",
                    nombre = "Jhanpier Valdivia",
                    cargo = "Practicante de programación",
                    correo = "jhanpier.jack@gmail.com",
                    edad = "21"
                }
            };

            return clientes;
        }

        [HttpGet]
        [Route("listarxid")]
        public dynamic listarClientexid(int codigo)
        {
            //Obtenemos el cliente de la DB

            return new Cliente
            {
                id = codigo.ToString(),
                nombre = "Adrian Celis",
                cargo = "Analista Programador",
                correo = "adriancelistorres184@gmail.com",
                edad = "20"
            };
        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            //Guardamos en la BD y asignamos n° id
            cliente.id = "3";

            return new
            {
                success = true,
                message = "cliente registrado",
                result = cliente
            };
        }

        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarCliente(Cliente cliente)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            //Eliminamos de la BD

            if(token != "jhan123.")
            {
                return new
                {
                    success = false,
                    message = "token incorrecto",
                    result = ""
                };
            }

            return new
            {
                success = true,
                message = "cliente eliminado",
                result = cliente
            }; 
        }
    } 
}

