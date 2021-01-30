using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaoT2.Dominio
{
    public class Agendamento
    {

        /*
         Thamirys
            Progressiva / Maria - 14:00 - 4hs
            Manicure / Joana - 18:00 - 1h
            Corte Cabelo / Maria - 19:00 - 30           
         29/01/2021 as 14 hs
         A Realizar
         */


        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        //public List<ServicoSolicitado> ServicosSolicitados { get; set; }
        public ServicoSolicitado ServicoSolicitado { get; set; }
        public DateTime? DtAgendamento { get; set; }
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

        public string IncluirAgendamento(int id, Cliente cliente,
            //List<ServicoSolicitado> servicosSolicitados, 
            ServicoSolicitado servicoParaAgendar,
            DateTime dtAgendamento, List<Agendamento> agenda, string anotacao = "")
        {
            if (PermiteAgendar(agenda, servicoParaAgendar, dtAgendamento))
            {
                return "Esse horário não está livre.";
            }
            else
            {
                Id = id;
                Cliente = cliente;
                //ServicosSolicitados = servicosSolicitados;
                ServicoSolicitado = servicoParaAgendar;
                DtAgendamento = dtAgendamento;
                Anotacao = anotacao;

                return "Agendamento feito com sucesso.";
            }
        }

        public string AlterarAgendamento(Cliente cliente, ServicoSolicitado servicoParaAgendar,
            DateTime dtAgendamento, List<Agendamento> agenda, string anotacao = "")
        {
            if (PermiteAgendar(agenda, servicoParaAgendar, dtAgendamento))
            {
                return "Esse horário não está livre.";
            }
            else
            {
                servicoParaAgendar.Status = ServicoSolicitado.StatusServico.Reagendado;
                Cliente = cliente;
                //ServicosSolicitados = servicosSolicitados;
                ServicoSolicitado = servicoParaAgendar;
                DtAgendamento = dtAgendamento;
                Anotacao = anotacao;

                return "Agendamento feito com sucesso.";
            }
        }

        private bool PermiteAgendar(List<Agendamento> agenda, ServicoSolicitado servicoParaAgendar, DateTime dtAgendamento)
        {
            DateTime dataTerminoParaAgendar = dtAgendamento.AddMinutes(servicoParaAgendar.Servico.MinutosParaExecucao);
            return (agenda.Any(a => a.DtAgendamento >= dtAgendamento &&
                    (a.Status != StatusAgenda.CanceladoPeloSalao || a.Status != StatusAgenda.CanceladoPeloCliente)) &&
                agenda.Any(a => a.DtAgendamento <= dataTerminoParaAgendar &&
                    (a.Status != StatusAgenda.CanceladoPeloSalao || a.Status != StatusAgenda.CanceladoPeloCliente)));
        }

        public void IncluirServicoSolicitado(int id, Servico servico, Funcionario func)
        {
            ServicoSolicitado ss = new ServicoSolicitado();
            ss.IncluirServicoSolicitado(id, servico, func);
            //ServicosSolicitados.Add(ss);
        }

        public void ExcluirServicoSolicitado(int id)
        {
            //ServicosSolicitados.RemoveAll(x => x.Id == id);
        }

    }
}
