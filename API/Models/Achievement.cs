using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EFitnessAPI.Models
{
    public class Achievement
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Član je obvezen.")]
        [Range(1, int.MaxValue, ErrorMessage = "Prosimo, izberite veljavnega člana.")]
        public int MemberId { get; set; }

        [ValidateNever] // Skip validating the navigation property
        public Member Member { get; set; }

        [Required(ErrorMessage = "Opis je obvezen.")]
        [StringLength(500, ErrorMessage = "Opis ne sme biti daljši od 500 znakov.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Datum dosežka je obvezen.")]
        public DateTime DateAchieved { get; set; }
    }
}
