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
            //Funcionario func = Funcionarios.Find(func => func.Matricula == matricula);
            //if (func != null)
            //{
            //    func.Servicos.RemoveAll(serv => serv.Id == idServ);
            //}

            Funcionarios.Find(func => func.Matricula == matricula)
                .Servicos.RemoveAll(serv => serv.Id == idServ);
        }
    }
}
