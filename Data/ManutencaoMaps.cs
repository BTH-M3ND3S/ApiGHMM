using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
    public class ManutencaoMap : IEntityTypeConfiguration<ManutencaoModel>
    {
        public void Configure(EntityTypeBuilder<ManutencaoModel> builder)
        {
            builder.HasKey(x => x.ManutencaoId);
            builder.Property(x => x.TipoManutencaoId).IsRequired();
            builder.Property(x => x.ManutencaoData).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ManutencaoDescricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ManutencaoCusto).IsRequired();
            builder.Property(x => x.TecnicosId).IsRequired();
        }
    }
}
