using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio  // Na classe TarefaRepositorio foi implementado ITarefaRepositorio, e automaticamente já obriga a implementar, ou seja, assinar todos os metodos que tem como obrigacao dessa interface. Essa parte de baixo foi gerada após aceitar a implementacao, mas fiz alguma mudancas como o (return await ...)
    {
        private readonly SistemaTarefasDBContext _dbContext;
        public TarefaRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) // construtor criado por atalho >>> ctor +TAB+ TAB
        {
            _dbContext = sistemaTarefasDBContext;
        }

        //BUSCAR POR ID
        public async Task<TarefaModel> BuscarPorId(int id)  //async pq ta usando Task
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario) 
                .FirstOrDefaultAsync(x => x.Id == id); // x.Id (id do usuario), for igual ao id que está sendo passado por parametro. Include para incluir o Usuario na tarefa
        }
        
        //BUSCAR TODOS USUARIOS
        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas
                .Include (x => x.Usuario)
                .ToListAsync(); // ToListAsync > pra buscar todo mundo da tabela Usuario
        }

        //ADICIONAR
        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);  //como tem um Async pode dar um await
            await _dbContext.SaveChangesAsync();
            return tarefa;
        }

        //ATUALIZAR
        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if(tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }

            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }
        
        //APAGAR
        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return true;

        }
    }
}
