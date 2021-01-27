using System.Collections.Generic;

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
            foreach(var cli in Clientes)
            {
                if(cli.Id == id)
                {
                    cli.Alterar(nomeNovo, telefoneNovo);
                    break;
                }
            }
        }

        public void ExcluirUmCliente(int id)
        {
            for (int i = 0; i < Clientes.Count; i++)
            {
                if (Clientes[i].Id == id)
                {
                    Clientes.RemoveAt(i);
                    break;
                }                    
            }
        }
    }
}
