//Essa interface terá os contratos de Usuario, por ex: buscar, adicionar, remover

using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<TarefaModel>> BuscarTodasTarefas();  // Task para manter assíncrono
        Task<TarefaModel> BuscarPorId(int id);
        Task<TarefaModel> Adicionar(TarefaModel tarefa); // Pra adicionar um Usuario é necessário receber um UsuarioModel e depois armazenar na vari'ável ``usuario``
        Task<TarefaModel> Atualizar(TarefaModel tarefa, int id);
        Task<bool> Apagar(int id);
    }
}
