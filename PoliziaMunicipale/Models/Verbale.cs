using System;
using System.ComponentModel.DataAnnotations;

namespace PoliziaMunicipale.Models
{
    public class Verbale
    {
        public int IDVerbale { get; set; }
        public int IDAnagrafica { get; set; }
        public int IDViolazione { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string NominativoAgente { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataTrascrizioneVerbale { get; set; }
        public int Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
        public bool Contestazioni { get; set; }
        public int TotaleVerbaliXAnagrafe { get; set; }
    }
}