using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransporteWeb.Models
{
    class MyContextMotorista : DbContext
    {
        public DbSet<Motorista> Motoristas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motorista>()
                .HasKey(b => b.IdMotorista)
                .HasName("IdMotorista");
        }
    }


    [Table("MOTORISTA", Schema = "transporteweb")]
    public class Motorista
    {
        [Column("IdMotorista", TypeName = "Integer(10)")]
        public Guid IdMotorista { get; set; }

        [Column("IsDone", TypeName = "Bool")]
        public bool IsDone { get; set; }

        [Column("NomeMotorista", TypeName = "varchar(200)")]
        public string NomeMotorista { get; set; }

        [Column("DataNascimento", TypeName = "Date")]
        public DateTimeOffset? DataNascimento { get; set; }

        [Column("Cpf", TypeName = "varchar(15)")]
        public string Cpf { get; set; }

        [Column("NumeroCelular", TypeName = "varchar(15)")]
        public string NumeroCelular { get; set; }

        [Column("Email", TypeName = "varchar(200)")]
        public string Email { get; set; }

        [Column("Senha", TypeName = "varchar(50)")]
        public string Senha { get; set; }

        [Column("Ativo", TypeName = "Bool)")]
        public bool Ativo { get; set; }

        [Column("CarteiraMotorista", TypeName = "varchar(15)")]
        public string CarteiraMotorista { get; set; }

        [Column("DataCadastro", TypeName = "DateTime")]
        public DateTime DataCadastro = DateTime.Now;

        List<Viagem> Viagems { get; set; }
    }
}
