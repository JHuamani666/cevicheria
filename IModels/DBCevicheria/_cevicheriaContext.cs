using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBModel.DBCevicheria;

public partial class _cevicheriaContext : DbContext
{
    public _cevicheriaContext()
    {
    }

    public _cevicheriaContext(DbContextOptions<_cevicheriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Boleta> Boletas { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Platillo> Platillos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-HBV87UV;Initial Catalog=DBCEVICHERIA;Integrated Security=True;Trusted_Connection=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Boleta>(entity =>
        {
            entity.HasKey(e => e.IdBoleta).HasName("PK__Boletas__75FF3CD6C08E92A1");

            entity.Property(e => e.FechaBoleta).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Boleta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Boletas__ID_Pedi__3A81B327");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__02AA0785012AF87E");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.OrdenVisualizacion).HasDefaultValue(0);
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DetalleP__B3E0CED3A1BD8973");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallePe__ID_Pe__35BCFE0A");

            entity.HasOne(d => d.IdPlatilloNavigation).WithMany(p => p.DetallePedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallePe__ID_Pl__36B12243");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedidos__FD768070E8C68105");

            entity.Property(e => e.Estado).HasDefaultValue("En preparación");
            entity.Property(e => e.FechaPedido).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__ID_Usua__32E0915F");
        });

        modelBuilder.Entity<Platillo>(entity =>
        {
            entity.HasKey(e => e.IdPlatillo).HasName("PK__Platillo__28C8FA3814425216");

            entity.Property(e => e.Disponible).HasDefaultValue(true);
            entity.Property(e => e.Estado).HasDefaultValue("Disponible");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Platillos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Platillos__ID_Ca__2E1BDC42");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__DE4431C5E91189F9");

            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
