namespace SalaoT2.Dominio
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MinutosParaExecucao { get; set; }
        public decimal Preco { get; set; }

        public void Incluir(int id, string nome, int minutosParaExecucao, decimal preco)
        {
            Agendamento a = new Agendamento();

            Id = id;
            Nome = nome;
            MinutosParaExecucao = minutosParaExecucao;
            Preco = preco;
        }

        public void Alterar(string nome, int minutosParaExecucao, decimal preco)
        {   
            Nome = nome;
            MinutosParaExecucao = minutosParaExecucao;
            Preco = preco;
        }

    }
}
