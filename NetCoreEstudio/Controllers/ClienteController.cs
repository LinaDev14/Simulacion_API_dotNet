using Microsoft.AspNetCore.Mvc;
using NetCoreEstudio.Models;

namespace NetCoreEstudio.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {
            List<ClienteModel> clientes = new List<ClienteModel>
            {
                new ClienteModel
                {
                    Id = 1,
                    Name = "Lina María",
                    Age = 24,
                    Email = "HolaMundo@gmail.com"
                },
                new ClienteModel
                {
                    Id = 2,
                    Name = "Mateo",
                    Age = 26,
                    Email = "HolaMundoMateo@gmail.com"
                },
                new ClienteModel
                {
                    Id = 3,
                    Name = "Sebastian",
                    Age = 38,
                    Email = "Sebastian@gmail.com"
                },
                new ClienteModel
                {
                    Id = 4,
                    Name = "Juan Pablo",
                    Age = 28,
                    Email = "JP12@gmail.com"
                },

                new ClienteModel
                {
                    Id = 5,
                    Name = "Margarita",
                    Age = 30,
                    Email = "Margarita@gmail.com"
                }

            };

            return clientes;
        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(ClienteModel cliente)
        {
            cliente.Id = 6;
            return new
            {
                success = true,
                massage = "Cliente registrado",
                result = cliente
            };
        }


        [HttpGet]
        [Route("listarPorId")]
        public dynamic listarClientePorId(int _Id)
        {
            return new ClienteModel
            {
                Id = _Id,
                Name = "Lina María",
                Age = 24,
                Email = "HolaMundo@gmail.com"
            };
        }

        [HttpDelete]
        [Route("eliminar")]
        public dynamic eliminarCliente(ClienteModel cliente)
        {
           string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
           if (token != "linadev14.")
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
                message = "Cliente eliminado",
                result = cliente
            };
        }
    }
}
