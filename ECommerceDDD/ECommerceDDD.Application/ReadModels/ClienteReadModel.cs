namespace ECommerceDDD.Application.ReadModels
{
    public class ClienteReadModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime DataNascimento { get; set; }
    }
}