using System;
using System.Collections.Generic;
using Colamdo_Azul.domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Colmado_Azul.Persistence.Context;

public partial class ColmadoAzulContext : DbContext
{
	public ColmadoAzulContext()
	{
	}

	public ColmadoAzulContext(DbContextOptions<ColmadoAzulContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Categoria> Categoria { get; set; }

	public virtual DbSet<Producto> Productos { get; set; }

	public virtual DbSet<Suplidor> Suplidors { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseSqlServer("Server=Berlyng;Database=Colmado_Azul;Trusted_Connection=True;TrustServerCertificate=True;");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Categoria>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC074C54365C");

			entity.Property(e => e.Descripcion)
				.HasMaxLength(50)
				.IsUnicode(false);
		});

		modelBuilder.Entity<Producto>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC071E968254");

			entity.Property(e => e.Descripcion)
				.HasMaxLength(100)
				.IsUnicode(false);
			entity.Property(e => e.FechaDeVencimiento).HasColumnName("Fecha_De_Vencimiento");

			entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
				.HasForeignKey(d => d.CategoriaId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Productos__Categ__3B75D760");

			entity.HasOne(d => d.Suplidor).WithMany(p => p.Productos)
				.HasForeignKey(d => d.SuplidorId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Productos__Supli__3C69FB99");
		});

		modelBuilder.Entity<Suplidor>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__Suplidor__3214EC07F9E4F64F");

			entity.ToTable("Suplidor");

			entity.Property(e => e.Correo)
				.HasMaxLength(30)
				.IsUnicode(false);
			entity.Property(e => e.Direccion)
				.HasMaxLength(250)
				.IsUnicode(false);
			entity.Property(e => e.NombreDeEmpresa)
				.HasMaxLength(50)
				.IsUnicode(false)
				.HasColumnName("Nombre_De_Empresa");
			entity.Property(e => e.Telefono)
				.HasMaxLength(12)
				.IsUnicode(false);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
