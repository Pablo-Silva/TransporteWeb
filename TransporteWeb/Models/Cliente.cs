using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransporteWeb.Models
{
    class MyContextCliente : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasKey(b => b.IdCliente)
                .HasName("IdCliente");
        }
    }


    [Table("CLIENTE", Schema = "transporteweb")]
    public class Cliente
    {
        [Column("IdCliente", TypeName = "Integer(10)")]
        public Guid IdCliente { get; set; }

        [Column("IsDone", TypeName = "Bool")]
        public bool IsDone { get; set; }

        [Column("NomeCliente", TypeName = "varchar(200)")]
        public string NomeCliente { get; set; }

        [Column("DataNascimento", TypeName = "Date")]
        public DateTimeOffset? DataNascimento { get; set; }

        [Column("Cpf", TypeName = "varchar(15)")]
        public string Cpf { get; set; }

        [Column("NumeroCelular", TypeName ="varchar(15)")]
        public string NumeroCelular { get; set; }

        [Column("Email", TypeName = "varchar(200)")]
        public string Email { get; set; }

        [Column("Senha", TypeName = "varchar(50)")]
        public string Senha { get; set; }

        [Column("Deficiencia", TypeName = "varchar(50)")]
        public string Deficiencia { get; set; }

        [Column("DataCadastro", TypeName = "DateTime")]
        public DateTime DataCadastro = DateTime.Now;

        List<Viagem> Viagems { get; set; }
    }
}
