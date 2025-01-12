using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EFitnessAPI.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Član je obvezen.")]
        [Range(1, int.MaxValue, ErrorMessage = "Prosimo, izberite veljavnega člana.")]
        public int MemberId { get; set; }

        [ValidateNever] // Skip validation for navigation property
        public Member Member { get; set; }

        [Required(ErrorMessage = "Aktivnost je obvezna.")]
        [Range(1, int.MaxValue, ErrorMessage = "Prosimo, izberite veljavno aktivnost.")]
        public int ActivityId { get; set; }

        [ValidateNever] // Skip validation for navigation property
        public Activity1 Activity { get; set; }

        [Required(ErrorMessage = "Datum je obvezen.")]
        public DateTime Date { get; set; }
    }
}
