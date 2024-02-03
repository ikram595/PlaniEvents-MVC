using System.ComponentModel.DataAnnotations;

namespace PlaniEvents123.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        [Required(ErrorMessage = "champ obligatoire")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Champ doit être de longueur comprise entre 3 et 20 caractères")]
        public string NomTag { get; set; } = null!;
        public int EventId { get; set; }
    }
}
