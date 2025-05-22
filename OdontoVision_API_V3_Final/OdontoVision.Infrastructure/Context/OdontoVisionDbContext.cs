using Microsoft.EntityFrameworkCore;
using OdontoVision.Domain.Entities;

public class OdontoVisionDbContext : DbContext
{
    public OdontoVisionDbContext(DbContextOptions<OdontoVisionDbContext> options) : base(options) { }

    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Procedimento> Procedimentos { get; set; }
    public DbSet<Diagnostico> Diagnosticos { get; set; }
    public DbSet<Dentista> Dentistas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseOracle("User Id=rm554199;Password=160103;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)))");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Dentista>(entity =>
        {
            entity.ToTable("DENTISTAS");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome).HasColumnName("NOME");
            entity.Property(e => e.Cro).HasColumnName("CRO");
            entity.Property(e => e.Especialidade).HasColumnName("ESPECIALIDADE");
            entity.Property(e => e.Email).HasColumnName("EMAIL");
            entity.Property(e => e.Telefone).HasColumnName("TELEFONE");    
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.ToTable("PACIENTES");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome).HasColumnName("NOME");
            entity.Property(e => e.DataNascimento).HasColumnName("DATA_NASCIMENTO");
        });

        modelBuilder.Entity<Procedimento>(entity =>
        {
            entity.ToTable("PROCEDIMENTOS");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");
        });

        modelBuilder.Entity<Diagnostico>(entity =>
        {
            entity.ToTable("DIAGNOSTICOS");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");
            entity.Property(e => e.DataDiagnostico).HasColumnName("DATA_DIAGNOSTICO");
            entity.Property(e => e.PacienteId).HasColumnName("PACIENTE_ID");
            entity.Property(e => e.DentistaId).HasColumnName("DENTISTA_ID");
        });
    }
}
