using System;

namespace SalaoT2.Dominio
{
    public class ServicoSolicitado
    {
        public int Id { get; set; }
        public Servico Servico { get; set; }
        public Funcionario Funcionario { get; set; }
        public StatusServico Status { get; set; }
        public DateTime DtServico { get; set; }

        public enum StatusServico
        {
            ARealizar,
            Realizado,
            Reagendado,
            CanceladoPeloCliente,           
            CanceladoPeloSalao
        }

        public void IncluirServicoSolicitado(int id, Servico servico, Funcionario func)
        {
            Id = id;
            Servico = servico;
            Funcionario = func;
        }
    }
}
