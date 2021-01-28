using System.Collections.Generic;
using System.Linq;

namespace SalaoT2.Dominio
{
    public class MinhaBaseClientes
    {
        public List<Cliente> Clientes { get; set; }

        public MinhaBaseClientes()
        {
            Clientes = new List<Cliente>();
        }

        public void Incluir(Cliente cliente)
        {
            Clientes.Add(cliente);            
        }

        public void IncluirLista(Cliente cliente1, Cliente cliente2)
        {
            List<Cliente> lst = new List<Cliente> { cliente1, cliente2};
            Clientes.AddRange(lst);
        }

        public void AlterarUmCliente(int id, string nomeNovo, string telefoneNovo)
        {
            Cliente cliente = Clientes.FirstOrDefault(cli => cli.Id == id);
            if (cliente != null)
            {
                cliente.Alterar(nomeNovo, telefoneNovo);
            }
        }

        public void ExcluirUmCliente(int id)
        {
            Clientes.RemoveAll(cli => cli.Id == id);
        }
    }
}
