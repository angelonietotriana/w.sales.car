using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace w.sale.car.db.Dtos
{
    public class ReserveInDto
    {

        public ReserveInDto() { }

        [JsonPropertyName("id_reserve")]
        public int IdReserve { get; set; }

        [JsonPropertyName("reserve_date")]
        public DateTime ReserveDate { get; set; }

        [JsonPropertyName("collect_date")]
        public DateTime CollectDate { get; set; }

        [JsonPropertyName("id_collect_location")]
        public int IdCollectLocation { get; set; }

        [JsonPropertyName("id_delivery_location")]
        public int? IdDeliveryLocation { get; set; }

        [JsonPropertyName("delivery_date")]
        public DateTime? DeliveryDate { get; set; }

        [JsonPropertyName("id_car")]
        public int IdCar { get; set; }

        [JsonPropertyName("id_client")]
        public int IdClient { get; set; }

        [JsonPropertyName("base_cost")]
        public float BaseCost { get; set; }

        [JsonPropertyName("others_costs")]
        public float OthersCosts { get; set; }
        
        [JsonPropertyName("do_sale")]
        public Boolean DoSale { get; set; }




    }
}

