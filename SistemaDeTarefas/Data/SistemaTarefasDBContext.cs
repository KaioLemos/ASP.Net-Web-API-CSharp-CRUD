using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Map;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    public class SistemaTarefasDBContext : DbContext //foi dado um import no EntityFramework Core para o DbContet
    {
        //CONSTRUTOR >>>Construtores são basicamente funções de inicialização de uma classe, as quais são invocadas no momento em que objetos desta classe são criadas. Eles permitem inicializar campos internos da classe e alocar recursos que um objeto da classe possa demandar, tais como memória, arquivos, semáforos, soquetes, etc.
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

// EXPLICACAO >>> Aqui esta trabalhando com ORM. O ORM facilita para trabalhar com o banco, fazendo toda estrutura de entidade para o codigo e depois criar o banco de dados e as tabelas atraves do codigo C#. Nesse DBContext esta configurando as tabelas e as configuracoes gerais do banco de dados. Por ex a UuarioModel  representa uma tabela no banco. Qnd rodar o script do migration do entity ele vai criar uma tabela com o nome Usuarios