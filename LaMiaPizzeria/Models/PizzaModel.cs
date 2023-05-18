using LaMiaPizzeria.Models.Validazione;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace LaMiaPizzeria.Models
{
    public class PizzaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo titolo è obbligatorio!")]
        [StringLength(50, ErrorMessage = "Il campo titolo può essere lungo al massimo 50 caratteri")]
        public string NomePizza { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Il campo descrizione è obbligatorio!")]
        [MoreFiveWords(ErrorMessage = "Il campo titolo deve contenere almeno 5 parole!")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "Il campo URL dell'immagine è obbligatorio")]
        [Url(ErrorMessage = "L'URL inserito non è un url valido!")]
        [StringLength(300, ErrorMessage = "Il campo URL immagine può contenere al massimo 300 caratteri")]
        public string Immagine { get; set; }

        [Required(ErrorMessage = "Il campo titolo è obbligatorio!")]
        [Range(0, 100, ErrorMessage = "Il campo Prezzo deve essere compreso tra 0 e 100")]
        public float Prezzo { get; set; }

        public PizzaModel()
        {

        }


        public PizzaModel(string nomePizza, string descrizione, string immagine, float prezzo)
        {
            NomePizza = nomePizza;
            Descrizione = descrizione;
            Immagine = immagine;
                Prezzo = prezzo;
        }

    }
}
