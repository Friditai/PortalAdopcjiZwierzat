namespace PortalAdopcjiZwierzat.Models.Zwierzeta
{
    public class Zwierze
    {
      
        public int Id { get; set; }
        public bool Adoptowany { get; set; }
        public string Nazwa { get; set; }
        public string Rasa { get; set; }
        public string Umaszczenie { get; set; }
        public string Siersc { get; set; }
        public int Wiek { get; set; }
        public string Opis { get; set; }
        public string ZdjecieUrl { get; set; }
    }
}

