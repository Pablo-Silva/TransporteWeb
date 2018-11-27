using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransporteWeb.Models
{
    class MyContextViagem : DbContext
    {
        public DbSet<Viagem> Viagens { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Viagem>()
                .HasKey(b => b.IdViagem)
                .HasName("IdViagem");             
        }
    }

    [Table("VIAGEM", Schema = "transporteweb")]
    public class Viagem
    {
        [Column("IdViagem", TypeName = "Integer(10)")]
        public Guid IdViagem { get; set; }

        [Column("IsDone", TypeName = "Bool")]
        public bool IsDone { get; set; }

        [ForeignKey("IdCliente")]
        [Column("IdCliente", TypeName = "Integer(10)")]
        public Cliente Cliente { get; set; }

        [ForeignKey("IdMotorista")]
        [Column("IdMotorista", TypeName = "Integer(10)")]
        public Motorista Motorista { get; set; }

        [Column("EnderecoSaida", TypeName = "varchar(200)")]
        public string EnderecoSaida { get; set; }

        [Column("DataSaida", TypeName = "DateTime")]
        public DateTime DataSaida = DateTime.Now;

        [Column("EnderecoChegada", TypeName = "varchar(200)")]
        public string EnderecoChegada { get; set; }

        [Column("DataChegada", TypeName = "DateTime")]
        public DateTime DataChegada = DateTime.Now;
    }
}
