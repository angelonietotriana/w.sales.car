using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using w.sale.car.model.statics;

namespace w.sale.car.model.Model
{
    public class Sale
    {

        public Sale() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSale { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [Required]
        public int IdCar { get; set; }

        [Required]
        public int IdUser { get; set; }

        [Required]
        public int IdVendor { get; set; }

        [Required] 
        public StatusSale Status { get; set; }

        [Required]
        public float TotalSale { get; set; }

        [Required]
        public String SnReserve { get; set; }

        [Required]
        public int IdDeliveryLocation { get; set; }



    }
}
