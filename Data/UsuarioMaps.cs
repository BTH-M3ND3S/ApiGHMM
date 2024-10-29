using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiGHMM.Data
{
    public class UsuarioMaps : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.UsuarioId);
            builder.Property(x => x.FotoUrl).IsRequired().HasMaxLength(255);
            builder.Property(x=> x.UsuarioNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioSenha).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioEmail).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioCpf).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioTelefone).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioDataNascimento).IsRequired();
            builder.Property(x => x.UsuarioEscolaridade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CargoId).IsRequired();
            builder.Property(x => x.SetorId).IsRequired();
        }
    }
}
