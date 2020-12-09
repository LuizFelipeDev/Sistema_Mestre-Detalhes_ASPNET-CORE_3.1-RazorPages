﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrabTerceiro.Data
{
    public partial class LojaprodutosContext : DbContext
    {
        public LojaprodutosContext()
        {
        }

        public LojaprodutosContext(DbContextOptions<LojaprodutosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Venda> Venda { get; set; }
        public virtual DbSet<VendaProduto> VendaProduto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=FLPPC\\FLPPC;Initial Catalog=LojaProdutos;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.CatNome).IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.CliCpf).IsUnicode(false);

                entity.Property(e => e.CliEmail).IsUnicode(false);

                entity.Property(e => e.CliNome).IsUnicode(false);
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.Property(e => e.ForNome).IsUnicode(false);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.ProNome).IsUnicode(false);

                entity.HasOne(d => d.ProCategoriaNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.ProCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produto_Categoria");

                entity.HasOne(d => d.ProFornecedorNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.ProFornecedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produto_Fornecedor");
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.HasOne(d => d.IdCliNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.IdCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venda_Cliente");
            });

            modelBuilder.Entity<VendaProduto>(entity =>
            {
                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.VendaProduto)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VendaProduto_Produto");

                entity.HasOne(d => d.IdVendaNavigation)
                    .WithMany(p => p.VendaProduto)
                    .HasForeignKey(d => d.IdVenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VendaProduto_Venda");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}