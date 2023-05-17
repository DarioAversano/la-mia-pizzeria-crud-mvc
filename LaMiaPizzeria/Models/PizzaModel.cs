using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace LaMiaPizzeria.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string NomePizza { get; set; }
        [Column(TypeName = "text")]
        public string Descrizione { get; set; }
        [MaxLength(300)]
        public string Immagine { get; set; }
        [MaxLength(100)]
        public float Prezzo { get; set; }

    

    public PizzaModel(int id, string nomePizza, string descrizione, string immagine, float prezzo)
    {
        Id = id;
        NomePizza = nomePizza;
        Descrizione = descrizione;
        Immagine = immagine;
            Prezzo = prezzo;
    }

}
}
