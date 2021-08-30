using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFrame.Data
{
    public class Vitrine
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }



    }
}
