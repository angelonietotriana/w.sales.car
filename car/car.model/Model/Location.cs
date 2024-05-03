using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w.sale.car.model.Model
{
    public class Location
    {
        public Location() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLocation { get; set; }

        [Required]
        public bool Available { get; set; }


        [Required]
        public string Zone { get; set; }

        [Required]
        public string Locality { get; set; }

        [Required]
        public int ZipCode { get; set; }



    }
}
