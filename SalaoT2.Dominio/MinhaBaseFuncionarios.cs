using System.Collections.Generic;
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
            Funcionarios.Add(func);            
        }

        public void AlterarUmFuncionario(int matricula, string nomeNovo, string telefoneNovo, Endereco enderecoNovo, CargoFunc cargoNovo)
        {
            foreach(var func in Funcionarios)
            {
                if(func.Matricula == matricula)
                {
                    func.Alterar(nomeNovo, telefoneNovo, enderecoNovo, cargoNovo);
                    break;
                }
            }
        }

        public void IncluirServicoDeUmFuncionario(int matricula, Servico servico)
        {
            foreach (var func in Funcionarios)
            {
                if (func.Matricula == matricula)
                {
                    func.IncluirServico(servico);
                    break;
                }
            }
        }

        public void ExcluirUmFuncionario(int matricula)
        {
            for (int i = 0; i < Funcionarios.Count; i++)
            {
                if (Funcionarios[i].Matricula == matricula)
                {
                    Funcionarios.RemoveAt(i);
                    break;
                }                    
            }
        }

        public void ExcluirServicoDeUmFuncionario(int matricula, int idServ)
        {
            for (int i = 0; i < Funcionarios.Count; i++)
            {
                if (Funcionarios[i].Matricula == matricula)
                {
                    for (int t = 0; t < Funcionarios[i].Servicos?.Count; t++)
                    {
                        if(Funcionarios[i].Servicos[t].Id == idServ)
                        {
                            Funcionarios[i].Servicos.RemoveAt(t);
                            break;
                        }    
                    }                    
                }
            }
        }
    }
}
