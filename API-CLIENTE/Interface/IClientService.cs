using API_CLIENTE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CLIENTE.Interface
{
    public interface IClientService
    {
        Task<List<Clientes>> ListarClientes(string filtroNome, string filtroEmail, string filtroCPF);
        void AdicionarCliente(Clientes cliente);
        void AtualizarCliente(int id, Clientes cliente);
        void RemoverCliente(int id);


    }
}
