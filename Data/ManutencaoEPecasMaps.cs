using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
    public class ManutencaoEPecasMap : IEntityTypeConfiguration<ManutencaoEPecasModel>
    {
        public void Configure(EntityTypeBuilder<ManutencaoEPecasModel> builder)
        {
            builder.HasKey(x => x.ManutencaoEPecasId);
            builder.Property(x => x.ManutencaoId).IsRequired();
            builder.Property(x => x.PecaId).IsRequired();
        }
    }
}
