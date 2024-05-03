using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace w.sale.car.db.Dtos
{
    public class UserInDto
    {
        [JsonPropertyName("id_user")]
        public int IdUser { get; set; }

        [JsonPropertyName("document")]
        public int Document { get; set; }

        [JsonPropertyName("document_type")]
        public string DocumentType { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("payment_type")]
        public string PaymentType { get; set; }

        [JsonPropertyName("amount_approved")]
        public int AmountApproved { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }


        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}

