//Essa interface terá os contratos de Usuario, por ex: buscar, adicionar, remover

using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();  // Task para manter assíncrono
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario); // Pra adicionar um Usuario é necessário receber um UsuarioModel e depois armazenar na vari'ável ``usuario``
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
        Task<bool> Apagar(int id);
    }
}
