namespace PoliziaMunicipale.Models
{
    // classe Punti che rappresenta i punti decurtati per ogni verbale e il totale dei verbali per ogni persona
    // mi serve per la view Punti e per la view Verbali cosi da poter asociare anche i nomi e i cognomi delle persone
    // e non solo i loro ID
    public class Punti
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int PuntiDecurtati { get; set; }
        public int TotaleVerbali { get; set; }
    }
}