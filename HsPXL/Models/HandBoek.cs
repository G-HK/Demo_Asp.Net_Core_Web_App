using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HsPXL.Models
{
    public class HandBoek
    {

        [Key]
        public int HandBoekID { get; set; }

        [Required(ErrorMessage = "Vul u de boek Titel in.")]
        [StringLength(200)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Vul u de boek Titel in.")]
        [Column(TypeName = "decimal(8,2)" )]
        public decimal KostPrijs { get; set; }
        [Required(ErrorMessage = "Geef de uitgift Datum van de boek.")]
        public DateTime UitgiftDatum { get; set; }

        public string Afbeelding { get; set; }

        public DateTime? CreationDate { get; set; }

   
    }
}