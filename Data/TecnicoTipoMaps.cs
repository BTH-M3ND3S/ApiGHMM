using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
    public class TecnicoTipoMaps : IEntityTypeConfiguration<TecnicoTipoModel>
    {
        public void Configure(EntityTypeBuilder<TecnicoTipoModel> builder)
        {
            builder.HasKey(x => x.TecnicoTipoId);
            builder.Property(x => x.TecnicoDescricao).IsRequired();
        }
    }
}
