using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Core.Entita
{

    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Codice { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Cognome { get; set; }

        [DataMember]
        public List<Ordine> Ordini { get; set; } //navigation property
    }
}
