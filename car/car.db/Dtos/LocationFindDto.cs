using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace w.sale.car.db.Dtos
{
    public class LocationFindDto
    {

        [JsonPropertyName("available")]
        public bool? Available { get; set; }

        [JsonPropertyName("zone")]
        public string? Zone { get; set; }

        [JsonPropertyName("locality")]
        public string? Locality { get; set; }

        [JsonPropertyName("zip_code")]
        public int? ZipCode { get; set; }
    }
}

