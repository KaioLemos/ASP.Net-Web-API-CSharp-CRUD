using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.UsuarioId); //mapeamento da propriedade UsuarioI

            builder.HasOne(x => x.Usuario); // Relacionamento. Tem um usuario vinculado a ele. Dessa forma cria uma relacao do Usuario com a Tarefa

        }
    }
}
