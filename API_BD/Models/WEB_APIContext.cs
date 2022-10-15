using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_BD.Models
{
    public partial class WEB_APIContext : DbContext
    {
        public WEB_APIContext()
        {
        }

        public WEB_APIContext(DbContextOptions<WEB_APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacto> Contactos { get; set; } = null!;
        public virtual DbSet<Tipo> Tipos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => e.IdContacto)
                    .HasName("PK__CONTACTO__A4D6BBFA22BB092E");

                entity.ToTable("CONTACTOS");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ObjTipo)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK_IDTIPO");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__TIPO__9E3A29A5B42043D9");

                entity.ToTable("TIPO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
