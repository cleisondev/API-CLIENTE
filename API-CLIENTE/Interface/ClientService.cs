using API_CLIENTE.Context;
using API_CLIENTE.Interface;
using API_CLIENTE.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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


            // Configurar a formatação do JSON
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(), // Converte para camelCase
                NullValueHandling = NullValueHandling.Ignore // Ignora propriedades nulas
            };

            // Serializar os clientes usando as configurações personalizadas
            var jsonClientes = JsonConvert.SerializeObject(resultado, settings);






            return resultado;
        }

        public void AdicionarCliente(Clientes cliente)
        {
            _dbContext.Cliente.Add(cliente);
            _dbContext.SaveChanges();
        }

        public void AtualizarCliente(int id, Clientes clienteAtualizado)
        {
            var clienteExistente = _dbContext.Cliente
                .Include(c => c.Contatos)
                    .Include(c => c.Enderecos)
                .FirstOrDefault(c => c.ClientID == id);

            if (clienteExistente != null)
            {
                // Atualizar propriedades do cliente
                clienteExistente.Nome = clienteAtualizado.Nome;
                clienteExistente.Email = clienteAtualizado.Email;
                clienteExistente.Cpf = clienteAtualizado.Cpf;
                clienteExistente.Rg = clienteAtualizado.Rg;

                // Atualizar propriedades de Contatos
                clienteExistente.Contatos.Tipo = clienteAtualizado.Contatos.Tipo;
                clienteExistente.Contatos.DDD = clienteAtualizado.Contatos.DDD;
                clienteExistente.Contatos.Telefone = clienteAtualizado.Contatos.Telefone;

                // Atualizar propriedades de Enderecos
                clienteExistente.Enderecos.Tipo = clienteAtualizado.Enderecos.Tipo;
                clienteExistente.Enderecos.Cep = clienteAtualizado.Enderecos.Cep;
                clienteExistente.Enderecos.Logradouro = clienteAtualizado.Enderecos.Logradouro;
                clienteExistente.Enderecos.Numero = clienteAtualizado.Enderecos.Numero;
                clienteExistente.Enderecos.Bairro = clienteAtualizado.Enderecos.Bairro;
                clienteExistente.Enderecos.Complemento = clienteAtualizado.Enderecos.Complemento;
                clienteExistente.Enderecos.Cidade = clienteAtualizado.Enderecos.Cidade;
                clienteExistente.Enderecos.Estado = clienteAtualizado.Enderecos.Estado;
                clienteExistente.Enderecos.Referencia = clienteAtualizado.Enderecos.Referencia;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception();
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
            else
            {
                throw new Exception();
            }
        }
    }
}
