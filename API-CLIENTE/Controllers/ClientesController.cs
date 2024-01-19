
using API_CLIENTE.Interface;
using API_CLIENTE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API_CLIENTE.Context.AppDBContext;

namespace API_CLIENTE.Controllers
{
    [Route("cliente/")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientService clienteService;

        public ClientesController (IClientService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet("listar")]
        public IActionResult ListarClientes(string Nome, string Email, string CPF)
        {
            Task<List<Clientes>> clientes = clienteService.ListarClientes(Nome, Email, CPF);
            return Ok(clientes.Result);
        }

        [HttpPost("criar")]
        public IActionResult CriarCliente([FromBody] Clientes cliente)
        {
            clienteService.AdicionarCliente(cliente);

            return Ok(new { message = "Cliente adicionado com sucesso!" });
        }

        [HttpPut("atualizar/{id}")]
        public IActionResult AtualizarCliente(int id, [FromBody] Clientes cliente)
        {
            clienteService.AtualizarCliente(id, cliente);

            return Ok(new { message = "Cliente atualizado com sucesso!" });
        }

        [HttpDelete("remover/{id}")]
        public IActionResult RemoverCliente(int id)
        {
            clienteService.RemoverCliente(id);
            return Ok(new { message = "Cliente removido com sucesso!" });
        }

    }
}
