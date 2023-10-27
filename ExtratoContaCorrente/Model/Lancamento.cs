namespace ExtratoContaCorrente.Model
{
    using System;

    public class Lancamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public bool Avulso { get; set; }
        public string Status { get; set; }
    }
}
