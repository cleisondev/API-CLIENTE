using System.ComponentModel.DataAnnotations;

namespace API_CLIENTE.Models
{
    public class Clientes
    {
        [Key]
        public int ClientID { get; set; }
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "O nome deve conter apenas letras.")]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
        [MinLength(11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O campo CPF deve conter apenas números.")]
        public string Cpf { get; set; }
        [Required]
        [MaxLength(9, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
        [MinLength(9, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O campo RG deve conter apenas números.")]
        public string Rg { get; set; }
        public Contatos Contatos { get; set; }
        public Enderecos Enderecos { get; set; }

    }


    public class Contatos
    {
        [Key]
        public int ContatoID { get; set; }
        public string Tipo { get; set; }
        public int DDD { get; set; }
        public decimal Telefone { get; set; }
    }

    public class Enderecos
    {
        [Key]
        public int EnderecoID { get; set; }
        public string Tipo { get; set; }
        [Required]
        [MaxLength(8, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
        [MinLength(8, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O campo CEP deve conter apenas números.")]
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Referencia { get; set; }

    }


}
