using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
    public class TecnicoUsuarioMaps : IEntityTypeConfiguration<TecnicoUsuarioModel>
    {
        public void Configure(EntityTypeBuilder<TecnicoUsuarioModel> builder)
        {
            builder.HasKey(x => x.TecnicoUsuarioId);
            builder.Property(x => x.Tecnicos).IsRequired();
            builder.Property(x => x.Usuario).IsRequired();
        }
    }
}
