using System.Globalization;

namespace WebApplication1.Entities
{
    public class Telefone
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        //public string Tipo { get; set; } = string.Empty;
        public int? PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
    }
}