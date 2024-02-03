using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaniEvents123.Models
{
    //validation de date
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not string date)
            {
                return new ValidationResult("La date n'est pas valide.");
            }

            if (!DateTime.TryParse(date, out var parsedDate))
            {
                return new ValidationResult("La date n'est pas valide.");
            }

            if (parsedDate.Date <= DateTime.Today)
            {
                return new ValidationResult("La date doit être ultérieure à aujourd'hui.");
            }

            return ValidationResult.Success;
        }
    }

public partial class Event
    {
        public int EventId { get; set; }
        [Required(ErrorMessage = "champ obligatoire")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Champ doit être de longueur comprise entre 3 et 100 caractères")]
        public string Nom { get; set; } = null!;
        [Required(ErrorMessage = "champ obligatoire")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Champ doit être de longueur comprise entre 10 et 500 caractères")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "champ obligatoire")]
        [FutureDate(ErrorMessage = "La date doit être ultérieure à aujourd'hui.")]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = "Format de date non valide. Utilisez le format jj/mm/aaaa.")]
        [Display(Name = "Date (mm/jj/aaaa)")]
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
        public string Categorie { get; set; } = null!;
        // liste des tags
        [Display(Name = "Tags")]
        [RegularExpression(@"^#\w+$", ErrorMessage = "Chaque tag doit debuter par '#' ou contient des letters, numeroes, ou _")]
        public string TagsInput { get; set; }

        public virtual  List<Tag> Tags { get; set; } = new List<Tag>();


    }
}
