using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
    public class AvisoTipoMap : IEntityTypeConfiguration<AvisoTipoModel>
    {
        public void Configure(EntityTypeBuilder<AvisoTipoModel> builder)
        {
            builder.HasKey(x => x.AvisoTipoId);
            builder.Property(x => x.AvisoTipoNome).IsRequired().HasMaxLength(255);
        }
    }
}
