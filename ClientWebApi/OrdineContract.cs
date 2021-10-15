using System;

namespace ClientWebApi
{
    internal class OrdineContract
    {
        public int Id { get; set; }
        public string CodOrdine { get; set; }
        public string CodProdotto { get; set; }
        public DateTime Data { get; set; }
        public decimal Importo { get; set; }
        public int ClienteId { get; set; }
    }
}
