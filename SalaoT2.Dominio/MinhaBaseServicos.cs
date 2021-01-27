using System.Collections.Generic;

namespace SalaoT2.Dominio
{
    public class MinhaBaseServicos
    {
        public List<Servico> Servicos { get; set; }

        public MinhaBaseServicos()
        {
            Servicos = new List<Servico>();
        }

        public void Incluir(Servico serv)
        {
            Servicos.Add(serv);            
        }

        public void AlterarUmServico(int id, string nomeNovo, int minutosParaExecucaoNovo, decimal precoNovo)
        {
            foreach(var serv in Servicos)
            {
                if(serv.Id == id)
                {
                    serv.Alterar(nomeNovo, minutosParaExecucaoNovo, precoNovo);
                    break;
                }
            }
        }

        public void ExcluirUmServico(int id)
        {
            for (int i = 0; i < Servicos.Count; i++)
            {
                if (Servicos[i].Id == id)
                {
                    Servicos.RemoveAt(i);
                    break;
                }                    
            }
        }
    }
}
