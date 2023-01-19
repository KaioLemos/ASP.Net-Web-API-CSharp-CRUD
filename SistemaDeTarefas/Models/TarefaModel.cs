using SistemaDeTarefas.Enums;

namespace SistemaDeTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get;set; }

        //VINCULAR COM O USUARIO
        public int? UsuarioId { get; set; }  // ? >>> pode ser nulo >>> nullable, pq pode criar uma tarefa e não vincular uma Tarefa e não vincular ao Usuario

        public virtual UsuarioModel? Usuario { get; set; } //O nome dessa propriedade é Usuario pq Automaticamente qnd trabalha com Entity FrameWork, se tem uma ligacao do usuario com a tarefa, e deu o atributo de UsuarioId, vai procurar a referencia da classe agregada exatamente com o msm nome do atributo, removendo o Id. O EntityFrameWOrk automatia isso.
    }
}