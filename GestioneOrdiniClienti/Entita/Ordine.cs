using System;
using System.Runtime.Serialization;

namespace Core.Entita
{
    [DataContract]
    public class Ordine
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CodOrdine { get; set; }

        [DataMember]
        public string CodProdotto { get; set; }

        [DataMember]
        public DateTime Data { get; set; }

        [DataMember]
        public decimal Importo { get; set; }

        [DataMember]
        public Cliente Cliente { get; set; } //navigation property
    }
}
