using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HsPXL.Models
{
    public class Cursus
    {
        [Key]
        public int CursusID { get; set; }

        [Required(ErrorMessage = "Vul u de Cursus Name in.")]
        public string CursusName { get; set; }

        [Required(ErrorMessage = "Vul de Studiepunten voor het vak in.")]
        public int Studiepunten { get; set; }
        

        public int HandboekID { get; set; }
        public HandBoek handboek { get; set; }
        public ICollection<HandBoek> HandBoeken { get; set; }


    }
}
