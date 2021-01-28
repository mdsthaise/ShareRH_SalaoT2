using SalaoT2.Dominio;
using System.Linq;
using System;
using System.IO;

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
                var meusFuncionarios = IncluirFuncionarios(meusServicos);

                meusFuncionarios.ExcluirServicoDeUmFuncionario(10, 1);
                Console.WriteLine("Aqui tá certo!");

                //meusClientes.AlterarUmCliente(1, "Diego", "199999999");
                //meusClientes.ExcluirUmCliente(2);
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

        static MinhaBaseServicos IncluirMeusServicos()
        {
            Servico s1 = new Servico();
            s1.Incluir(1, "Corte de Cabelo", 60, 130);

            Servico s5 = new Servico();
            s5.Incluir(1, "Corte de Cabelo", 60, 130);

            Servico s2 = new Servico();
            s2.Incluir(2, "Manicure", 60, 20);

            Servico s3 = new Servico();
            s3.Incluir(3, "Pedicure", 60, 30);

            Servico s4 = new Servico();
            s4.Incluir(4, "Limpeza de pele", 60, 100);

            MinhaBaseServicos bs = new MinhaBaseServicos();
            bs.Incluir(s1);
            bs.Incluir(s2);
            bs.Incluir(s3);
            bs.Incluir(s4);
            bs.Incluir(s5);

            return bs;
        }

        static MinhaBaseFuncionarios IncluirFuncionarios(MinhaBaseServicos baseDeServico)
        {
            Funcionario f1 = new Funcionario();
            Endereco e1 = new Endereco();
            e1.Incluir(1, "Rua dos bobos", "12345-010", "Vila dos Devs", "São Paulo", "SP", "0", string.Empty);

            f1.Incluir("Maria", "999999999", e1, Funcionario.CargoFunc.Cabelereira);

            Funcionario f2 = new Funcionario();
            f2.Incluir("Rosana", "999999998", e1, Funcionario.CargoFunc.Manicure);

            Funcionario f3 = new Funcionario();
            f3.Incluir("Joana", "999999997", e1, Funcionario.CargoFunc.Esteticista);

            MinhaBaseFuncionarios bf = new MinhaBaseFuncionarios();
            bf.Incluir(f1);
            bf.Incluir(f2);
            bf.Incluir(f3);


            bf.IncluirServicoDeUmFuncionario(1, baseDeServico.Servicos.FirstOrDefault(x => x.Id == 1));
            bf.IncluirServicoDeUmFuncionario(2, baseDeServico.Servicos.FirstOrDefault(x => x.Id == 2));
            bf.IncluirServicoDeUmFuncionario(2, baseDeServico.Servicos.FirstOrDefault(x => x.Id == 3));
            bf.IncluirServicoDeUmFuncionario(3, baseDeServico.Servicos.FirstOrDefault(x => x.Id == 4));

            return bf;
        }

        static void ChamarOExcluir()
        { 
            
        }
    }
}
