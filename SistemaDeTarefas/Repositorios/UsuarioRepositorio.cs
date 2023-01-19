using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio  // Na classe UsuarioRepositorio foi implementado IUsuarioRepositorio, e automaticamente já obriga a implementar, ou seja, assinar todos os metodos que tem como obrigacao dessa interface. Essa parte de baixo foi gerada após aceitar a implementacao, mas fiz alguma mudancas como o (return await ...)
    {
        private readonly SistemaTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) // construtor criado por atalho >>> ctor +TAB+ TAB
        {
            _dbContext = sistemaTarefasDBContext;
        }

        //BUSCAR POR ID
        public async Task<UsuarioModel> BuscarPorId(int id)  //async pq ta usando Task
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id); // x.Id (id do usuario), for igual ao id que está sendo passado por parametro
        }

        //BUSCAR TODOS USUARIOS
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync(); // ToListAsync > pra buscar todo mundo da tabela Usuario
        }

        //ADICIONAR
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);  //como tem um Async pode dar um await
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        //ATUALIZAR
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email= usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }
        
        //APAGAR
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;

        }
    }
}
