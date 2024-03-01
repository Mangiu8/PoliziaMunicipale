﻿namespace PoliziaMunicipale.Models
{
    // la classe Trasgressori rappresenta la tabella DatiAnagrafici del database
    public class Trasgressori
    {
        public int IDAnagrafica { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public int Cap { get; set; }
    }
}