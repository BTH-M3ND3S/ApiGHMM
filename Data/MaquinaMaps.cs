using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
    public class MaquinaMap : IEntityTypeConfiguration<MaquinaModel>
    {
        public void Configure(EntityTypeBuilder<MaquinaModel> builder)
        {
            builder.HasKey(x => x.MaquinaId);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TipoMaquinaId).IsRequired();
            builder.Property(x => x.SetorId).IsRequired();
            builder.Property(x => x.Modelo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.NumeroSerie).IsRequired();
            builder.Property(x => x.FabricanteId).IsRequired();
            builder.Property(x => x.DataAquisicao).IsRequired();
            builder.Property(x => x.FotoUrl).IsRequired();
            builder.Property(x => x.Peso).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Voltagem).IsRequired().HasMaxLength(255);
        }
    }
}
