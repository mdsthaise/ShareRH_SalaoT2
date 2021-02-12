using SalaoT2.Dominio;
using System.Linq;
using System;
using System.IO;
using System.Collections.Generic;

namespace SalaoT2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var meusClientes = IncluirMeusClientes();
                var meusServicos = IncluirMeusServicos();
                //var meusFuncionarios = IncluirFuncionarios(meusServicos);

                //meusFuncionarios.ExcluirServicoDeUmFuncionario(10, 1);

                //meusClientes.AlterarUmCliente(1, "Diego", "199999999");
                //meusClientes.ExcluirUmCliente(2);

                List<Agendamento> agenda = new List<Agendamento>();
                agenda.Add(new Agendamento { Id = 2, ServicoSolicitado = 
                            new ServicoSolicitado { Id = 2, Servico = meusServicos.Servicos.First()}, 
                            DtAgendamento = new DateTime(2021, 1, 29, 12, 0, 0) });
                agenda.Add(new Agendamento
                {
                    Id = 2,
                    ServicoSolicitado =
                            new ServicoSolicitado { Id = 3, Servico = meusServicos.Servicos.First() },
                    DtAgendamento = new DateTime(2021, 1, 29, 11, 0, 0), Status = Agendamento.StatusAgenda.CanceladoPeloCliente
                });

                var dia = DateTime.Today.Day;

                var servicoDia = agenda.FindAll(a => a.DtAgendamento.Day == dia);


                Agendamento agendamento = new Agendamento();
                agendamento.IncluirAgendamento(1, meusClientes.Clientes.First(), 
                    new ServicoSolicitado { Id = 1, Servico = meusServicos.Servicos.First() }, new DateTime(2021, 1, 29, 10, 0, 0), 
                    agenda);
            }
            catch (IOException)
            {
                Console.WriteLine("Ocorreu um erro. Tente novamente mais tarde. ");
            }
            catch (ArgumentNullException nrEx)
            {
                Console.WriteLine("Aqui caiu a Null Reference!");
                throw;
            }
            catch (Exception)
            {
                Console.WriteLine("Deu ruim!!!");
                //throw;
            }
            Console.WriteLine("Continuando...");
            Console.ReadLine();
        }

        static MinhaBaseClientes IncluirMeusClientes()
        {
            Cliente c1 = new Cliente();
            c1.Incluir(1, "Thamirys", "999999999", "12345678901");

            Cliente c2 = new Cliente();
            c2.Incluir(2, "Thaise", "999999998", "12345678902");

            MinhaBaseClientes mc = new MinhaBaseClientes();
            mc.Incluir(c1);
            mc.Incluir(c2);

            var c3 = new Cliente();
            c3.Incluir(3, "Maria", "999999997", "12345678903");

            var c4 = new Cliente();
            c4.Incluir(4, "Joana", "999999996", "12345678904");

            mc.IncluirLista(c3, c4);

            return mc;
        }

        static void ChamarOExcluir()
        { 
            
        }
    }
}
