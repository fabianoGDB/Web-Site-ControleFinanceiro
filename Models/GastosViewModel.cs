using System.Collections.Generic;

namespace Web.Site.GerenciadorCartao.Models
{
    public class GastosViewModel
    {
        public int CartaoId { get; set; }
        public string NumeroCartao { get; set; }
        public IList<Gasto> ListaGastos { get; set; }
        public int PorcentagemGasto { get; set; }
    }
}