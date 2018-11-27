using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransporteWeb.Models
{
    public class NewMotorista
    {
        [Required]
        public string NomeMotorista { get; set; }

        public DateTimeOffset? DataNascimento { get; set; }

        public string Cpf { get; set; }

        public string NumeroCelular { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public bool Ativo { get; set; }

        public string CarteiraMotorista { get; set; }

        public DateTime DataCadastro = DateTime.Now;
    }
}
