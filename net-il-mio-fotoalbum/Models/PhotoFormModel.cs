using Microsoft.AspNetCore.Mvc.Rendering;

namespace net_il_mio_fotoalbum.Models
{
    public class PhotoFormModel
    {
        public Photo Photo { get; set; }
        public List<SelectListItem>? Categories { get; set; }//elenco categorie selezionabili
        public List<string>? SelectedCategories { get; set; }//id cat selezionati
    }
}
