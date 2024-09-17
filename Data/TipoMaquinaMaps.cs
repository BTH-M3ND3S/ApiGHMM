using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
    public class TipoManutencaoMap : IEntityTypeConfiguration<TipoManutencaoModel>
    {
        public void Configure(EntityTypeBuilder<TipoManutencaoModel> builder)
        {
            builder.HasKey(x => x.TipoManutencaoId);
            builder.Property(x => x.TipoManutencaoNome).IsRequired().HasMaxLength(255);
        }
    }
}
