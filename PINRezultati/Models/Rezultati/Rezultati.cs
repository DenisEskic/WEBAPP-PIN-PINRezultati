using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PINRezultati.Models.Rezultati
{
    public class Rezultati
    {
        [Key]
        public int studId { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        [Required]
        public int studMb { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string ime { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string prezime { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public int ocjenaKolokvij { get; set; }
        public int ocjenaProjekt { get; set; }
    }
}
