using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiGHMM.Data
{
    public class FuncionarioMap : IEntityTypeConfiguration<FuncionarioModel>
    {
        public void Configure(EntityTypeBuilder<FuncionarioModel> builder)
        {
            builder.HasKey(x => x.FuncionarioId);
            builder.Property(x => x.FotoUrl).IsRequired().HasMaxLength(255);
            builder.Property(x=> x.FuncionarioNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.FuncionarioSenha).IsRequired().HasMaxLength(255);
            builder.Property(x => x.FuncionarioEmail).IsRequired().HasMaxLength(255);
            builder.Property(x => x.FuncionarioCpf).IsRequired().HasMaxLength(255);
            builder.Property(x => x.FuncionarioTelefone).IsRequired().HasMaxLength(255);
            builder.Property(x => x.FuncionarioDataNascimento).IsRequired();
            builder.Property(x => x.FuncionarioEscolaridade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CargoId).IsRequired();
            builder.Property(x => x.SetorId).IsRequired();
        }
    }
}
