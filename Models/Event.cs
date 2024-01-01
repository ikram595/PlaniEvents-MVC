using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaniEvents123.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        [Required(ErrorMessage = "champ obligatoire")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Champ doit être de longueur comprise entre 3 et 50 caractères")]
        public string Nom { get; set; } = null!;
        [Required(ErrorMessage = "champ obligatoire")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Champ doit être de longueur comprise entre 10 et 500 caractères")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "champ obligatoire")]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = "Format de date non valide. Utilisez le format jj/mm/aaaa.")]
        [Display(Name = "Date (jj/mm/aaaa)")]
        public string Jour { get; set; } = null!;
        [Required(ErrorMessage = "champ obligatoire")]
        [RegularExpression(@"^\d{2}:\d{2}$", ErrorMessage = "Format d'heure non valide. Utilisez le format HH:mm.")]
        [Display(Name = "Temps (HH:mm)")]
        public string Temps { get; set; } = null!;
        [Required(ErrorMessage = "champ obligatoire")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Champ doit être de longueur comprise entre 3 et 15 caractères")]
        public string Lieu { get; set; } = null!;

        // liste des participants
        public virtual List<IdentityUser> Participants { get; set; } = new List<IdentityUser>();
        
    }
}
