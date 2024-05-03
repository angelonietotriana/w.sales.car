using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace w.sale.car.db.Dtos
{
    public class SaleFindDto
    {

        [JsonPropertyName("date_sale")]
        public DateTime? SaleDate { get; set; }

        [JsonPropertyName("id_car")]
        public int? IdCar { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("total_sale")]
        public float? TotalSale { get; set; }

        [JsonPropertyName("sn_reserve")]
        public String? SnReserve { get; set; }

        [JsonPropertyName("id_user")]
        public int? IdUser { get; set; }

        [JsonPropertyName("id_vendor")]
        public int? IdVendor { get; set; }

        [JsonPropertyName("id_delivery_location")]
        public int? IdDeliveryLocation { get; set; }

        [JsonPropertyName("id_reserve")]
        public int? IdReserve { get; set; }

        [JsonPropertyName("reserve_date")]
        public DateTime? ReserveDate { get; set; }


        [JsonPropertyName("base_cost")]
        public float? BaseCost { get; set; }


        [JsonPropertyName("others_costs")]
        public float? OthersCosts { get; set; }


    }
}

