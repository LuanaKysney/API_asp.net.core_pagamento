using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Pagamento.Models
{
    public class Bandeiras_cartao_credito
    {
        [Key]
        public Guid id { get; set; }
        public string American_Express {get; set;}
        public string Aura { get; set; }
        public string Banescard { get; set; }
        public string Diners { get; set; }
        public string Discover { get; set; }
        public string ELO { get; set; }
        public string Hipercard { get; set; }
        public string JCB { get; set; }
        public string Mastercard { get; set; }
        public string Visa { get; set; }
    }
}
