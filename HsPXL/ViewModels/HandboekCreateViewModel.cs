using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HsPXL.ViewModel
{
    public class HandboekCreateViewModel
    {

        [Key]
        public int HandBoekID { get; set; }

        [Required(ErrorMessage = "Vul u de boek Titel in.")]
        [StringLength(200)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Vul u de boek Titel in.")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal KostPrijs { get; set; }

        [Required(ErrorMessage = "Geef de uitgift Datum van de boek.")]
        public DateTime UitgiftDatum { get; set; }

        public IFormFile Afbeelding { get; set; }

    }
}
