using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
    public class TipoMaquinaMap : IEntityTypeConfiguration<TipoMaquinaModel>
    {
        public void Configure(EntityTypeBuilder<TipoMaquinaModel> builder)
        {
            builder.HasKey(x => x.TipoMaquinaId);
            builder.Property(x => x.TipoMaquinaNome).IsRequired().HasMaxLength(255);
        }
    }
}
