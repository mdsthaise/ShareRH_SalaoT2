namespace SalaoT2.Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }        

        public void Incluir(int id, string nome, string telefone, string cpf)
        {
            Id = id;
            Nome = nome + " Gameiro";
            Telefone = telefone;
            CPF = cpf;
        }

        public void Alterar(string nome, string telefone)
        {
            Nome = string.IsNullOrEmpty(nome) ? Nome : nome;
            //Nome = nome ?? Nome;
            //Nome = "";
            //Nome = null;

            Telefone = string.IsNullOrEmpty(telefone) ? Telefone : telefone;
        }

    }
}
