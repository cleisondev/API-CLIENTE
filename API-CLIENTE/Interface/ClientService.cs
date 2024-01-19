using API_CLIENTE.Context;
using API_CLIENTE.Interface;
using API_CLIENTE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API_CLIENTE.Context.AppDBContext;

namespace API_CLIENTE.Interface
{
    public class ClientService : IClientService
    {
        // Implemente as operações da interface utilizando Entity Framework ou outro mecanismo de armazenamento
        // Exemplo simples utilizando uma lista em memória
        private List<Clientes> clientes = new List<Clientes>();
        private readonly AppDbContext _dbContext;

        public ClientService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<List<Clientes>> ListarClientes(string filtroNome, string filtroEmail, string filtroCPF)
        {
            var resultado = clientes;

            if (!string.IsNullOrEmpty(filtroNome))
            {
                resultado = _dbContext.Cliente
                .Include(c => c.Contatos)
                  .Include(c => c.Enderecos)
                    .Where(c => c.Nome.Contains(filtroNome))
                        .ToList();
            }

            if (!string.IsNullOrEmpty(filtroEmail))
            {
                resultado = _dbContext.Cliente
                .Include(c => c.Contatos)
                  .Include(c => c.Enderecos)
                    .Where(c => c.Nome.Contains(filtroEmail))
                        .ToList();
            }

            if (!string.IsNullOrEmpty(filtroCPF))
            {
                resultado = _dbContext.Cliente
                .Include(c => c.Contatos)
                   .Include(c => c.Enderecos)
                    .Where(c => c.Nome.Contains(filtroCPF))
                        .ToList();
            }

            if (string.IsNullOrEmpty(filtroCPF) && string.IsNullOrEmpty(filtroEmail) && string.IsNullOrEmpty(filtroNome))
            {
                resultado = _dbContext.Cliente
                .Include(c => c.Contatos)
                    .Include(c => c.Enderecos)
                      .ToList();
            }

            return resultado;
        }

        public void AdicionarCliente(Clientes cliente)
        {
            _dbContext.Cliente.Add(cliente);
            _dbContext.SaveChanges();
        }

        public void AtualizarCliente(int id, Clientes cliente)
        {
            var clienteExistente = clientes.FirstOrDefault(c => c.ClientID == id);
            if (clienteExistente != null)
            {
                clienteExistente.Nome = cliente.Nome;
                clienteExistente.Email = cliente.Email;
                clienteExistente.Cpf = cliente.Cpf;
            }
        }

        public void RemoverCliente(int id)
        {
            var clienteExistente = _dbContext.Cliente
              .Include(c => c.Contatos)
                .Include(c => c.Enderecos)
                    .FirstOrDefault(c => c.ClientID == id);

            if (clienteExistente != null)
            {
                _dbContext.Contatos.Remove(clienteExistente.Contatos);
                _dbContext.Enderecos.Remove(clienteExistente.Enderecos);
                _dbContext.Remove(clienteExistente);
                _dbContext.SaveChanges();
            }
        }
    }
}
