using ApiGHMM.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Data
{
    public class Contexto : DbContext
    {
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public Contexto(DbContextOptions<Contexto> options) : base(options)
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        {

        }

        public DbSet<UsuarioModel> Usuario { get; set; }

        public DbSet<CargoModel> Cargo { get; set; }

        public DbSet<SetorModel> Setor { get; set; }

        public DbSet<FornecedorModel> Fornecedor { get; set; }
        public DbSet<FabricanteModel> Fabricante { get; set; }

        public DbSet<PecaModel> Peca { get; set; }

        public DbSet<TipoMaquinaModel> TipoMaquina { get; set; }
        public DbSet<TipoManutencaoModel> TipoManutencao { get; set; }

        public DbSet<CategoriaPecaModel> CategoriaPeca { get; set; }

        public DbSet<ManutencaoEPecasModel> ManutencaoEPecas { get; set; }

        public DbSet<MaquinaModel> Maquina { get; set; }
        public DbSet<ManutencaoModel> Manutencao { get; set; }

        public DbSet<TecnicosModel> Tecnicos { get; set; }

        public DbSet<TecnicoUsuarioModel> TecnicoUsuario { get; set; }

        public DbSet<TecnicoTipoModel> TecnicoTipo { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMaps());
            modelBuilder.ApplyConfiguration(new CargoMap());
            modelBuilder.ApplyConfiguration(new SetorMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new FabricanteMap());
            modelBuilder.ApplyConfiguration(new PecaMap());
            modelBuilder.ApplyConfiguration(new TipoMaquinaMap());
            modelBuilder.ApplyConfiguration(new TipoManutencaoMap());
            modelBuilder.ApplyConfiguration(new CategoriaPecaMap());
            modelBuilder.ApplyConfiguration(new ManutencaoEPecasMap());
            modelBuilder.ApplyConfiguration(new MaquinaMap());
            modelBuilder.ApplyConfiguration(new ManutencaoMap());
            modelBuilder.ApplyConfiguration(new TecnicosMaps());
            modelBuilder.ApplyConfiguration(new TecnicoUsuarioMaps());
            modelBuilder.ApplyConfiguration(new TecnicoTipoMaps());
            base.OnModelCreating(modelBuilder);
        }

    }
}
