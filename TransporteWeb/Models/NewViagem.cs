using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransporteWeb.Models
{
    public class NewViagem
    {
        [Required]
        public string EnderecoSaida { get; set; }

        [Required]
        public string EnderecoChegada { get; set; }

        public Cliente Cliente { get; set; }

        public Motorista Motorista { get; set; }
    }
}
