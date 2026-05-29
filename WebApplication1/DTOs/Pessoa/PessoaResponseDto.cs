using WebApplication1.DTOs.Telefone;

namespace WebApplication1.DTOs.Pessoa
{
    public class PessoaResponseDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public List<TelefoneResponseDto> Telefones { get; set; } = new();
    }
}
