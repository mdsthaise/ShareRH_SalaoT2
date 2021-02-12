using System.Collections.Generic;
using System.Linq;

namespace SalaoT2.Dominio
{
    public class MinhaBaseServicos
    {
        public List<Servico> Servicos { get; set; }

        public MinhaBaseServicos()
        {
            Servicos = new List<Servico>();
            DadosIniciais();
        }

        public void Incluir(Servico serv)
        {
            Servicos.Add(serv);            
        }

        public void AlterarUmServico(int id, string nomeNovo, int minutosParaExecucaoNovo, decimal precoNovo)
        {
            Servico servico = Servicos.FirstOrDefault(x => x.Id == id);
            if (servico != null)
            {
                servico.Alterar(nomeNovo, minutosParaExecucaoNovo, precoNovo);
            }
        }

        public void ExcluirUmServico(int id)
        {
            Servicos.RemoveAll(serv => serv.Id == id);
        }

        public Servico ConsultarPorId(int id)
        {
            return Servicos.FirstOrDefault(x => x.Id == id);
        }

        private void DadosIniciais()
        {
            Servico s1 = new Servico();
            s1.Incluir(1, "Corte de Cabelo", 59, 130);

            Servico s2 = new Servico();
            s2.Incluir(2, "Manicure", 59, 20);

            Servico s3 = new Servico();
            s3.Incluir(3, "Pedicure", 59, 30);

            Servico s4 = new Servico();
            s4.Incluir(4, "Limpeza de pele", 59, 100);

            Incluir(s1);
            Incluir(s2);
            Incluir(s3);
            Incluir(s4);            
        }
    }
}
