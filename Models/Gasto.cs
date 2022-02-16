namespace Web.Site.GerenciadorCartao.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public int CartaoId { get; set; }
        public Cartao Cartao { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}