using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HsPXL.Models
{
    public class Inschrijving
    {
        [Key]
        public int InschrijvingID { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int CursusID { get; set; }
        public Cursus Cursus { get; set; }


    }
}
