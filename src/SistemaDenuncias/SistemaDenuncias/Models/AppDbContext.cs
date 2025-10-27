using Microsoft.EntityFrameworkCore;

namespace SistemaDenuncias.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Denuncia> Denuncias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Opcional: Configuração explícita da chave estrangeira,
            // mas o Entity Framework geralmente a infere automaticamente
            modelBuilder.Entity<Denuncia>()
                .HasOne(d => d.Usuario)
                .WithMany() // Se um usuário pode ter muitas denúncias, mas uma denúncia tem apenas um usuário
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict); // Evita a exclusão em cascata por padrão

            base.OnModelCreating(modelBuilder);
        }
    }
}
