using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaVenda.Model;

namespace SistemaVenda.DAL.DBContext;

public partial class DbvendaContext : DbContext
{
    public DbvendaContext()
    {
    }

    public DbvendaContext(DbContextOptions<DbvendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<DetalheVenda> DetalheVenda { get; set; }

    public virtual DbSet<Imposto> Impostos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<NumeroDocumento> NumeroDocumentos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venda> Venda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240C558ADAE0");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.DataActualizacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataActualizacao");
            entity.Property(e => e.DataRegisto)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataRegisto");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.IsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActivo");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<DetalheVenda>(entity =>
        {
            entity.HasKey(e => e.IdDetalheVenda).HasName("PK__DetalheV__61EFE30E1A5FCD57");

            entity.Property(e => e.IdDetalheVenda).HasColumnName("idDetalheVenda");
            entity.Property(e => e.Desconto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("desconto");
            entity.Property(e => e.IdProduto).HasColumnName("idProduto");
            entity.Property(e => e.IdVenda).HasColumnName("idVenda");
            entity.Property(e => e.Preco)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("preco");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.DetalheVenda)
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("FK__DetalheVe__idPro__2180FB33");

            entity.HasOne(d => d.IdVendaNavigation).WithMany(p => p.DetalheVenda)
                .HasForeignKey(d => d.IdVenda)
                .HasConstraintName("FK__DetalheVe__idVen__208CD6FA");
        });

        modelBuilder.Entity<Imposto>(entity =>
        {
            entity.HasKey(e => e.IdImposto).HasName("PK__Imposto__C67D0E284788EB15");

            entity.ToTable("Imposto");

            entity.Property(e => e.IdImposto).HasColumnName("idImposto");
            entity.Property(e => e.DataActualizacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataActualizacao");
            entity.Property(e => e.DataRegisto)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataRegisto");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Taxa)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("taxa");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("PK__Marca__70331812CAD89DBB");

            entity.ToTable("Marca");

            entity.Property(e => e.IdMarca).HasColumnName("idMarca");
            entity.Property(e => e.DataActualizacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataActualizacao");
            entity.Property(e => e.DataRegisto)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataRegisto");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.IsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActivo");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__C26AF483A77D7218");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Icone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("icone");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.IdMenuRol).HasName("PK__MenuRol__9D6D61A41CFCC39E");

            entity.ToTable("MenuRol");

            entity.Property(e => e.IdMenuRol).HasColumnName("idMenuRol");
            entity.Property(e => e.DataActualizacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataActualizacao");
            entity.Property(e => e.DataRegisto)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataRegisto");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__MenuRol__idMenu__778AC167");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__MenuRol__idRol__787EE5A0");
        });

        modelBuilder.Entity<NumeroDocumento>(entity =>
        {
            entity.HasKey(e => e.IdNumeroDocumento).HasName("PK__NumeroDo__471E421A8CBB396C");

            entity.ToTable("NumeroDocumento");

            entity.Property(e => e.IdNumeroDocumento).HasColumnName("idNumeroDocumento");
            entity.Property(e => e.DataActualizacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataActualizacao");
            entity.Property(e => e.DataRegisto)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataRegisto");
            entity.Property(e => e.UltimoNumero).HasColumnName("ultimo_Numero");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__Produto__5EEDF7C3FEC27A46");

            entity.ToTable("Produto");

            entity.Property(e => e.IdProduto).HasColumnName("idProduto");
            entity.Property(e => e.DataActualizacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataActualizacao");
            entity.Property(e => e.DataRegisto)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataRegisto");
            entity.Property(e => e.Foto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("foto");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.IdImposto).HasColumnName("idImposto");
            entity.Property(e => e.IdMarca).HasColumnName("idMarca");
            entity.Property(e => e.IsActico)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActico");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Preco)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("preco");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
            entity.Property(e => e.Unidade)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("unidade");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Produto__idCateg__114A936A");

            entity.HasOne(d => d.IdImpostoNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdImposto)
                .HasConstraintName("FK__Produto__idImpos__1332DBDC");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdMarca)
                .HasConstraintName("FK__Produto__idMarca__123EB7A3");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F766F933A17");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.DataActualizacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataActualizacao");
            entity.Property(e => e.DataRegisto)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataRegisto");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A67DEE9F75");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.DataActualizacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataActualizacao");
            entity.Property(e => e.DataRegisto)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataRegisto");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Foto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("foto");
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActivo");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Sobrenome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sobrenome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefone");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__idRol__7D439ABD");
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey(e => e.IdVenda).HasName("PK__Venda__077BEC280E614986");

            entity.Property(e => e.IdVenda).HasColumnName("idVenda");
            entity.Property(e => e.DataActualizacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataActualizacao");
            entity.Property(e => e.DataRegisto)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataRegisto");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.TipoPagamento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoPagamento");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
