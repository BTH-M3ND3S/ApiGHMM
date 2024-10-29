using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiGHMM.Data
{
    public class TecnicosMaps : IEntityTypeConfiguration<TecnicosModel>
    {
        public void Configure(EntityTypeBuilder<TecnicosModel> builder)
        {
            builder.HasKey(x => x.TecnicosId);
            builder.Property(x => x.TecnicoNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TecnicoDetalhes).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TecnicoTipo);
        }

    }
}
