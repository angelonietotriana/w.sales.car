using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace w.sale.car.model.Model
{
    public class Car
    {
        public Car() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCar { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public int Model { get; set; }

        [Required]
        public int SubModel { get; set; }

        [Required]
        public int YearModel { get; set; }

        [Required]
        public bool Available { get; set; }

    }
}
