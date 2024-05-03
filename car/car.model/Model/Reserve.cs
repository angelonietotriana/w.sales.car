using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace w.sale.car.model.Model
{
    public class Reserve
    {

        public Reserve() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int IdReserve { get; set; }

        [Required]
        public string SN { get; set; }

        [Required]
         public DateTime ReserveDate { get; set; }
        
        [Required]
        public DateTime CollectDate { get; set; }
        
        [Required]
        public int IdCollectLocation { get; set; }

        public int? IdDeliveryLocation { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [Required]
        public int IdCar { get; set; }

        [Required]
        public int IdClient { get; set; }

        [Required]
        public float BaseCost { get; set; }

        [Required]
        public float OthersCosts { get; set; }

        [Required]
        public Boolean DoSale { get; set; }

    }
}
