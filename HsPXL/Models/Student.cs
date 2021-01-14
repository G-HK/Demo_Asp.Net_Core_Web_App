using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HsPXL.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Vul u naam in.")]
        [StringLength(30)]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Vul u Voornaam in.")]
        [StringLength(30)]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Vul u je E-mail address in.")]
        [StringLength(255)]
        public string Email { get; set; }


        public DateTime? CreationDate { get; set; }
        
        
        public ICollection<Inschrijving> Inschrijvings{ get; set; }



    }
}