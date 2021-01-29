using System;
using System.Collections.Generic;

namespace SalaoT2.Dominio
{
    public class Agendamento
    {

        /*
         Thamirys
            Progressiva / Maria - 14,00 - 4hs
            Manicure / Joana - 18,00 - 1h
            Corte Cabelo / Maria - 18,00 - 30           
         29/01/2021 as 14 hs
         A Realizar
         */


        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<ServicoSolicitado> ServicosSolicitados { get; set; }
        public DateTime DataChegada { get; set; }
        public string Anotacao { get; set; }
        public StatusAgenda Status { get; set; }

        public enum StatusAgenda
        {
            ARealizar,
            Realizado,
            Reagendado,
            CanceladoPeloCliente,
            NaoCompareceu,
            CanceladoPeloSalao,
            Pendente
        }

        public void IncluirAgendamento(int id, Cliente cliente, List<ServicoSolicitado> servicosSolicitados, 
            DateTime dtAgendamento, string anotacao = "")
        {
            Id = id;
            Cliente = cliente;
            ServicosSolicitados = servicosSolicitados;
            DtAgendamento = dtAgendamento;
            Anotacao = anotacao;
        }

        public void AlterarAgendamento(Cliente cliente, List<ServicoSolicitado> servicosSolicitados, 
            DateTime dtAgendamento, string anotacao = "")
        {
            Cliente = cliente;
            ServicosSolicitados = servicosSolicitados;
            DtAgendamento = dtAgendamento;
            Anotacao = anotacao;
        }

        public void IncluirServicoSolicitado(int id, Servico servico, Funcionario func)
        {
            ServicoSolicitado ss = new ServicoSolicitado();
            ss.IncluirServicoSolicitado(id, servico, func);
            ServicosSolicitados.Add(ss);
        }

        public void ExcluirServicoSolicitado(int id)
        {
            ServicosSolicitados.RemoveAll(x => x.Id == id);
        }

    }
}
