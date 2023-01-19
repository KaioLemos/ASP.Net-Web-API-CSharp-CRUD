using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Map;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    public class SistemaTarefasDBContext : DbContext //foi dado um import no EntityFramework Core para o DbContext // : >>> significa que SistemaTarefasDBContext está herdando de DBContext
    {
        
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        //ADICIONAR O MAPEAMENTO
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());  //Adicionado o mapeamento (Data>Map>UsuarioMap)
            modelBuilder.ApplyConfiguration(new TarefaMap());   ////Adicionado o mapeamento (Data>Map>TarefaMap)
            base.OnModelCreating(modelBuilder);
        }
    }
}

// EXPLICACAO >>> Aqui esta trabalhando com ORM. O ORM facilita para trabalhar com o banco, fazendo toda estrutura de entidade para o codigo e depois criar o banco de dados e as tabelas atraves do codigo C#. Nesse DBContext esta configurando as tabelas e as configuracoes gerais do banco de dados. Por ex a UuarioModel  representa uma tabela no banco. Qnd rodar o script do migration do entity ele vai criar uma tabela com o nome Usuarios