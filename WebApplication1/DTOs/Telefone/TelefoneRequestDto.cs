namespace WebApplication1.DTOs.Telefone
{
    public class TelefoneRequestDto
    {
        public string Numero { get; set; } = string.Empty;

        public int? PessoaId { get; set; }
    }
}
