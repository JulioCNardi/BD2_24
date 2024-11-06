using Microsoft.EntityFrameworkCore;

namespace ProtBc.Models;

public partial class CompeticaoDbContext : DbContext
{
    public CompeticaoDbContext(DbContextOptions<CompeticaoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Competico> Competicoes { get; set; }
    public virtual DbSet<Equipe> Equipes { get; set; }
    public virtual DbSet<Modalidade> Modalidades { get; set; }
    public virtual DbSet<Resultado> Resultados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Competico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Competic__3214EC07C24FC88A");

            entity.Property(e => e.DataFim).HasColumnType("datetime");
            entity.Property(e => e.DataInicio).HasColumnType("datetime");
            entity.Property(e => e.Nome).HasMaxLength(100);

            entity.HasOne(d => d.Modalidade).WithMany(p => p.Competicos)
                .HasForeignKey(d => d.ModalidadeId)
                .HasConstraintName("FK__Competico__Modal__60A75C0F");
        });

        modelBuilder.Entity<Equipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Equipes__3214EC07A5516F85");

            entity.Property(e => e.Nome).HasMaxLength(100);

            entity.HasOne(d => d.Competicao).WithMany(p => p.Equipes)
                .HasForeignKey(d => d.CompeticaoId)
                .HasConstraintName("FK__Equipes__Competi__6383C8BA");
        });

        modelBuilder.Entity<Modalidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Modalida__3214EC07559BFDCD");

            entity.Property(e => e.Descricao).HasMaxLength(255);
            entity.Property(e => e.Nome).HasMaxLength(100);
        });

        modelBuilder.Entity<Resultado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resultad__3214EC07D9A884D9");

            entity.HasOne(d => d.Competicao).WithMany(p => p.Resultados)
                .HasForeignKey(d => d.CompeticaoId)
                .HasConstraintName("FK__Resultado__Compe__66603565");

            entity.HasOne(d => d.Equipe).WithMany(p => p.Resultados)
                .HasForeignKey(d => d.EquipeId)
                .HasConstraintName("FK__Resultado__Equip__6754599E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
