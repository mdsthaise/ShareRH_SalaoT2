using System;
using System.Collections.Generic;
using System.Text;

namespace SalaoT2.Dominio
{
    public class MinhaBaseAgendamento
    {
        public List<Agendamento> Agendamentos { get; set; }

        public bool AgendarServicos(int id, Cliente cliente, List<ServicoSolicitado> servicosSolicitados, 
            DateTime dtAgendamento, string anotacao = "")
        {
            Agendamento agenda = new Agendamento();
            //agenda.IncluirAgendamento(id, cliente, servicosSolicitados, dtAgendamento, anotacao);
            return true;
        }
    }
}
