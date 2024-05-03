using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using w.sale.car.model.statics;

namespace w.sale.car.db.Dtos
{
    public class ReportFindDto
    {
        public ReportFindDto()
        {

        }
 
        public int IdSale { set; get; }
        public int IdCar { set; get; }
        public int Status { set; get; }
        public DateTime SaleDate { set; get; }
        public int IdDeliveryLocation { set; get;}
        public int IdVendor { set; get;}
        public int IdUser { set; get; }
        public float TotalSale { set; get; }
        public String SnReserve { set; get; }
        public int IdReserve { set; get; }
        public DateTime ReserveDate { set; get;}
        public float BaseCost { set; get;}
        public float OthersCosts { set; get; }



    }
}

