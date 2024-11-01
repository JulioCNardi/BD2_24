using Microsoft.EntityFrameworkCore;
using Competicao.Models; // Ajuste conforme necessário

namespace Competicao.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para as entidades
        public DbSet<Competicao.Models.Competicao> Competicoes { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        // Adicione outros DbSet conforme necessário

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais, se necessário
            // Por exemplo, se precisar definir chaves primárias ou relacionamentos
            modelBuilder.Entity<Competicao.Models.Competicao>()
                .HasOne(c => c.Modalidade) // Relacionamento com Modalidade
                .WithMany() // Supondo que Modalidade não tem coleção de Competicoes
                .HasForeignKey(c => c.ModalidadeId);

            // Adicione configurações para outras entidades se necessário
        }
    }
}
