using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PortalAdopcjiZwierzat.Models.Zwierzeta
{
    public class Zwierze
    {
      
        public int Id { get; set; }
        public bool Adoptowany { get; set; }

        [Display(Name = "Imię")]
        public string Imie { get; set; }
        public string Nazwa { get; set; }

        [Display(Name = "Płeć")]
        public string Plec { get; set; }
        public string Rasa { get; set; }
        public string Umaszczenie { get; set; }

        [Display(Name = "Sierść")]
        public string Siersc { get; set; }
        public int Wiek { get; set; }
        public string Opis { get; set; }

        [Display(Name = "Zdjęcie")]
        public string ZdjecieUrl { get; set; }
    }
}

