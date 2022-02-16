using System.Collections.Generic;

namespace Web.Site.GerenciadorCartao.Models
{
    public class Cartao
    {
        public int Id { get; set; }
        public string NomeBanco { get; set; }
        public string NumeroCartao { get; set; }
        public double Limite { get; set; }
        public ICollection<Gasto> Gastos { get; set; }
    }   
}