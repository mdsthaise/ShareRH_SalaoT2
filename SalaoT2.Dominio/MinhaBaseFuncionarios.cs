using System.Collections.Generic;
using System.Linq;
using static SalaoT2.Dominio.Funcionario;

namespace SalaoT2.Dominio
{
    public class MinhaBaseFuncionarios
    {
        public List<Funcionario> Funcionarios { get; set; }

        public MinhaBaseFuncionarios()
        {
            Funcionarios = new List<Funcionario>();
        }

        public void Incluir(Funcionario func)
        {
            int matricula = 0;
            if (Funcionarios.Any())
                matricula = Funcionarios.Last().Matricula + 1;
            else
                matricula++;
            func.Matricula = matricula;
            Funcionarios.Add(func);
        }

        public void AlterarUmFuncionario(int matricula, string nomeNovo, string telefoneNovo, Endereco enderecoNovo, CargoFunc cargoNovo)
        {
            Funcionarios.Find(func => func.Matricula == matricula)
                .Alterar(nomeNovo, telefoneNovo, enderecoNovo, cargoNovo);
        }

        public void IncluirServicoDeUmFuncionario(int matricula, Servico servico)
        {
            Funcionarios.Find(func => func.Matricula == matricula)
                .IncluirServico(servico);
        }

        public void ExcluirUmFuncionario(int matricula)
        {
            Funcionarios.RemoveAll(func => func.Matricula.Equals(matricula));
        }

        public void ExcluirServicoDeUmFuncionario(int matricula, int idServ)
        {
            Funcionario func = Funcionarios.Find(func => func.Matricula == matricula);
            if (func != null)
            {
                func.Servicos.RemoveAll(serv => serv.Id == idServ);
            }

            //Funcionarios.Find(func => func.Matricula == matricula)
            //.Servicos.RemoveAll(serv => serv.Id == idServ);
        }

        private void DadosIniciais(MinhaBaseServicos baseDeServico)
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

            //return bf;
        }
    }
}
