using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kpi.Models
{
    public partial class kpiContext : DbContext
    {
        public kpiContext()
        {
        }

        public kpiContext(DbContextOptions<kpiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agencia> Agencia { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<AreaAgencia> AreaAgencia { get; set; }
        public virtual DbSet<Indicadores> Indicadores { get; set; }
        public virtual DbSet<Logrado> Logrado { get; set; }
        public virtual DbSet<Meta> Meta { get; set; }
        public virtual DbSet<Objetivo> Objetivo { get; set; }
        public virtual DbSet<Subobjetivos> Subobjetivos { get; set; }
        public virtual DbSet<SubojetivoArea> SubojetivoArea { get; set; }
        public virtual DbSet<Tiempo> Tiempo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Tokens> Tokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencia>(entity =>
            {
                entity.HasKey(e => e.IdAgencia)
                    .HasName("PRIMARY");

                entity.ToTable("agencia");

                entity.Property(e => e.IdAgencia)
                    .HasColumnName("Id_Agencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreAgencia)
                    .IsRequired()
                    .HasColumnName("Nombre_agencia")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea)
                    .HasName("PRIMARY");

                entity.ToTable("area");

                entity.Property(e => e.IdArea)
                    .HasColumnName("Id_Area")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreArea)
                    .IsRequired()
                    .HasColumnName("Nombre_Area")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<AreaAgencia>(entity =>
            {
                entity.HasKey(e => e.IdAreaAgencia)
                    .HasName("PRIMARY");

                entity.ToTable("area_agencia");

                entity.HasIndex(e => e.IdAgencia)
                    .HasName("Id_Agencia_idx");

                entity.HasIndex(e => e.IdArea)
                    .HasName("Id_Area_idx");

                entity.HasIndex(e => e.IdCodigoIndiador)
                    .HasName("Id_CodigoIndiador_idx");

                entity.Property(e => e.IdAreaAgencia)
                    .HasColumnName("Id_Area_Agencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdAgencia)
                    .HasColumnName("Id_Agencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdArea)
                    .HasColumnName("Id_Area")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCodigoIndiador)
                    .HasColumnName("Id_CodigoIndiador")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdAgenciaNavigation)
                    .WithMany(p => p.AreaAgencia)
                    .HasForeignKey(d => d.IdAgencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_Agencia_FK");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.AreaAgencia)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_Area_FK");

                entity.HasOne(d => d.IdCodigoIndiadorNavigation)
                    .WithMany(p => p.AreaAgencia)
                    .HasForeignKey(d => d.IdCodigoIndiador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_CodigoIndiador_FK");
            });

            modelBuilder.Entity<Indicadores>(entity =>
            {
                entity.HasKey(e => e.IdCodigoIndiador)
                    .HasName("PRIMARY");

                entity.ToTable("indicadores");

                entity.HasIndex(e => e.IdSubobjetivos)
                    .HasName("Id_subobjetivos_idx");

                entity.HasIndex(e => e.IdTiempo)
                    .HasName("Id_Tiempo_idx");

                entity.Property(e => e.IdCodigoIndiador)
                    .HasColumnName("Id_CodigoIndiador")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Detalle)
                    .IsRequired()
                    .HasMaxLength(245);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.Formula)
                    .IsRequired()
                    .HasMaxLength(245);

                entity.Property(e => e.IdSubobjetivos)
                    .HasColumnName("Id_subobjetivos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTiempo)
                    .HasColumnName("Id_Tiempo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreIndicador)
                    .IsRequired()
                    .HasColumnName("Nombre_Indicador")
                    .HasMaxLength(255);

                entity.Property(e => e.Proceso)
                    .IsRequired()
                    .HasMaxLength(225);

                entity.Property(e => e.Responsables)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdSubobjetivosNavigation)
                    .WithMany(p => p.Indicadores)
                    .HasForeignKey(d => d.IdSubobjetivos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_subobjetivos");

                entity.HasOne(d => d.IdTiempoNavigation)
                    .WithMany(p => p.Indicadores)
                    .HasForeignKey(d => d.IdTiempo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_Tiempo");
            });

            modelBuilder.Entity<Logrado>(entity =>
            {
                entity.HasKey(e => e.IdCodigoIndiador)
                    .HasName("PRIMARY");

                entity.ToTable("logrado");

                entity.HasIndex(e => e.IdAreaAgencia)
                    .HasName("Id_Area_Agencia_idx");

                entity.Property(e => e.IdCodigoIndiador)
                    .HasColumnName("Id_CodigoIndiador")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdAreaAgencia)
                    .HasColumnName("Id_Area_Agencia")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Logrado1)
                    .IsRequired()
                    .HasColumnName("Logrado")
                    .HasMaxLength(30);

                entity.Property(e => e.Meta)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.PorcentajeCumplimiento)
                    .IsRequired()
                    .HasColumnName("Porcentaje_Cumplimiento")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdAreaAgenciaNavigation)
                    .WithMany(p => p.Logrado)
                    .HasForeignKey(d => d.IdAreaAgencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_Area_Agencia");
            });

            modelBuilder.Entity<Meta>(entity =>
            {
                entity.HasKey(e => e.IdCodigoIndiador)
                    .HasName("PRIMARY");

                entity.ToTable("meta");

                entity.HasIndex(e => e.IdAreaAgencia)
                    .HasName("Id_Area_Agencia_idx");

                entity.HasIndex(e => e.IdCodigoIndiador)
                    .HasName("Id_Area_idx");

                entity.HasIndex(e => new { e.IdAreaAgencia, e.IdCodigoIndiador })
                    .HasName("Id_Area_Agencia_idx1");

                entity.Property(e => e.IdCodigoIndiador)
                    .HasColumnName("Id_CodigoIndiador")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdAreaAgencia)
                    .HasColumnName("Id_Area_Agencia")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdAreaAgenciaNavigation)
                    .WithMany(p => p.Meta)
                    .HasForeignKey(d => d.IdAreaAgencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_Area_Agencia_FK");
            });

            modelBuilder.Entity<Objetivo>(entity =>
            {
                entity.HasKey(e => e.IdObjetivo)
                    .HasName("PRIMARY");

                entity.ToTable("objetivo");

                entity.HasComment("Tabla para registrar objetivos");

                entity.Property(e => e.IdObjetivo)
                    .HasColumnName("id_Objetivo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreObjetivo)
                    .IsRequired()
                    .HasColumnName("Nombre_objetivo")
                    .HasMaxLength(500);

                entity.Property(e => e.PorcentajeObjetivo).HasColumnName("Porcentaje_Objetivo");
            });

            modelBuilder.Entity<Subobjetivos>(entity =>
            {
                entity.HasKey(e => e.IdSubobjetivos)
                    .HasName("PRIMARY");

                entity.ToTable("subobjetivos");

                entity.HasIndex(e => e.IdArea)
                    .HasName("Id_Area_idx");

                entity.HasIndex(e => e.IdObjetivo)
                    .HasName("Id_Objetivo_idx");

                entity.Property(e => e.IdSubobjetivos)
                    .HasColumnName("Id_subobjetivos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdArea)
                    .HasColumnName("Id_Area")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdObjetivo)
                    .HasColumnName("Id_Objetivo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreSubobjetivo)
                    .IsRequired()
                    .HasColumnName("Nombre_Subobjetivo")
                    .HasMaxLength(45);

                entity.Property(e => e.SubObjetivo)
                    .IsRequired()
                    .HasColumnName("% SubObjetivo")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Subobjetivos)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_Area");

                entity.HasOne(d => d.IdObjetivoNavigation)
                    .WithMany(p => p.Subobjetivos)
                    .HasForeignKey(d => d.IdObjetivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_Objetivo");
            });

            modelBuilder.Entity<SubojetivoArea>(entity =>
            {
                entity.HasKey(e => e.IdSubobjetivos)
                    .HasName("PRIMARY");

                entity.ToTable("subojetivo_area");

                entity.HasIndex(e => e.IdArea)
                    .HasName("Id_Area_idx");

                entity.Property(e => e.IdSubobjetivos)
                    .HasColumnName("Id_subobjetivos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdArea)
                    .HasColumnName("Id_Area")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.SubojetivoArea)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_Area_FKK");
            });

            modelBuilder.Entity<Tiempo>(entity =>
            {
                entity.HasKey(e => e.IdTiempo)
                    .HasName("PRIMARY");

                entity.ToTable("tiempo");

                entity.Property(e => e.IdTiempo)
                    .HasColumnName("Id_Tiempo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombrePeriodo)
                    .IsRequired()
                    .HasColumnName("Nombre_Periodo")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.IdAgencia)
                    .HasName("ID_Agencia_idx");

                entity.HasIndex(e => e.IdArea)
                    .HasName("Id_Area_idx");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_Usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.IdAgencia)
                    .HasColumnName("Id_Agencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdArea)
                    .HasColumnName("Id_Area")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsuarioTipo)
                    .IsRequired()
                    .HasColumnName("Usuario_Tipo")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdAgenciaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdAgencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_Agencia");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Idarea");
            });

            modelBuilder.Entity<Tokens>(entity =>
            {
                entity.HasKey(e => e.RefreshTokenId)
                    .HasName("PRIMARY");

                entity.ToTable("tokens");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("Id_Usuario");

                entity.Property(e => e.RefreshTokenId).HasColumnType("int(11)");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_Usuario")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.JwtId)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Used)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'NULL'");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
