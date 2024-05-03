using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace w.sale.car.db.Dtos
{
    public class CarInDto
    {
        public int IdCar { get; set; }

        [JsonPropertyName("make")]
        public string Make { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }

        [JsonPropertyName("mileage")]
        public int Mileage { get; set; }

        [JsonPropertyName("cost")]
        public int Cost { get; set; }

        [JsonPropertyName("model")]
        public int Model { get; set; }

        [JsonPropertyName("sub_model")]
        public int SubModel { get; set; }

        [JsonPropertyName("year_model")]
        public int YearModel { get; set; }

        [JsonPropertyName("available")]
        public bool Available { get; set; }

    }
}

