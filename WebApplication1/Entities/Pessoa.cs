namespace WebApplication1.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        //public DateTime DataNascimento { get; set; }
        //public bool EstaAtivo { get; set; } = true;
        public List<Telefone>? Telefones { get; set; } = new();
    }
}
