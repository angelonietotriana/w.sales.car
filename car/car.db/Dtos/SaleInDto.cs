using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace w.sale.car.db.Dtos
{
    public class SaleInDto
    {
        [JsonPropertyName("id_sale")]
        public int? IdSale { get; set; }

        [JsonPropertyName("date_sale")]
        public DateTime SaleDate { get; set; }

        [JsonPropertyName("status")]
        public int? Status { get; set; }

        [JsonPropertyName("total_sale")]
        public float TotalSale { get; set; }

        [JsonPropertyName("id_car")]
        public int IdCar { get; set; }

        [JsonPropertyName("sn_reserve")]
        public String SnReserve { get; set; }

        [JsonPropertyName("id_user")]
        public int IdUser { get; set; }

        [JsonPropertyName("id_vendor")]
        public int IdVendor { get; set; }

        [JsonPropertyName("id_delivery_location")]
        public int IdDeliveryLocation { get; set; }



    }
}

