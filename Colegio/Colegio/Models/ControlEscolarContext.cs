using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Colegio.Models
{
    public partial class ControlEscolarContext : DbContext
    {
        public ControlEscolarContext()
        {
        }

        public ControlEscolarContext(DbContextOptions<ControlEscolarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<EstudianteMateria> EstudianteMateria { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ControlEscolar;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCursos);

                entity.Property(e => e.IdCursos)
                    .HasColumnName("Id_Cursos")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEtudiante)
                    .HasName("PK__Estudian__E0374A08BD4A3EA5");

                entity.Property(e => e.IdEtudiante).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Estudiante)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Curso");
            });

            modelBuilder.Entity<EstudianteMateria>(entity =>
            {
                entity.HasKey(e => new { e.IdEstudiante, e.IdMateria })
                    .HasName("PK_Est_Mat");

                entity.ToTable("Estudiante_Materia");

                entity.Property(e => e.IdEstudiante).HasColumnName("Id_estudiante");

                entity.Property(e => e.IdMateria).HasColumnName("Id_Materia");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.EstudianteMateria)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Estudiante");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.EstudianteMateria)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Materia");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.IdMateria)
                    .HasName("PK__Materia__EC1746702B916344");

                entity.Property(e => e.IdMateria).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
