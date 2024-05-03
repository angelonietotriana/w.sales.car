using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace w.sale.car.model.Model
{
    public class User
    {
        public User()
        {
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }

        [Required]
        public int Document { get; set; }

        [Required]
        public string DocumentType { get; set; }

        [Required]
        public string Phone { get; set; }

        public string PaymentType { get; set; }

        public float AmountApproved { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Type { get; set; }

    }
}
