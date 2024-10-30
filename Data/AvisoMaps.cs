using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
   
    
        public class AvisoMap : IEntityTypeConfiguration<AvisoModel>
        {
            public void Configure(EntityTypeBuilder<AvisoModel> builder)
            {
                builder.HasKey(x => x.AvisoId);
                builder.Property(x => x.AvisoConteudo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Usuario).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AvisoTipo).IsRequired().HasMaxLength(255);
        }
        }
    
}
