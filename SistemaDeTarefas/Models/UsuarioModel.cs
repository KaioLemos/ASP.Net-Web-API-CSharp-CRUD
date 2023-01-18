namespace SistemaDeTarefas.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; } // ? > Name can be Null
        public string? Email { get; set; }

    }
}
