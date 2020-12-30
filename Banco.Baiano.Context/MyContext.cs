using Banco.Baiano.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Baiano.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<SituacaoContrato> SituacaoContratos { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }
        public DbSet<Negociacao> Negociacao { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Negociacao>();


            modelBuilder.Entity<Cliente>()
                .HasMany(l => l.Contratos)
                .WithOne()
                .HasForeignKey(l => l.IdCliente);

            modelBuilder.Entity<Contrato>()
                .HasOne(l => l.SituacaoContrato)
                .WithOne()
                .HasForeignKey<Contrato>(l => l.IdSituacao);

            modelBuilder.Entity<Contrato>()
                .HasMany(l => l.Parcelas)
                .WithOne()
                .HasForeignKey(l => l.IdContrato);


        }


    }
}
