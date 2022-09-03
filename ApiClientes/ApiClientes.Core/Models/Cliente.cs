using System.ComponentModel.DataAnnotations;

namespace ApiClientes.Models
{
    public class Cliente
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "CPF � obrigat�rio")]
        public string Cpf { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Nome � obrigat�rio")]
        public DateTime DataNascimento { get; set; }
        public int Idade { get; private set; }

        public Cliente(long id, string cpf, string nome, DateTime dataNascimento, int idade)
        {
            Id = id;
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Idade = ObterIdade();
        }

        public int ObterIdade()
        {
            int idade = DateTime.Now.Year - DataNascimento.Year;
            if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
            {
                idade--;
            }
            return idade;
        }
    }
}