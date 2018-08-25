using DeviceManager.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Model.Models
{
    [Table("Deliveries")]
    public class Delivery : Auditable, IIDKey
    {

        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar")]
        public string DeliveryToUser { set; get; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar")]
        public string DeliveryFromUser { set; get; }

        [ForeignKey("DeliveryToUser")]
        public User UserDeliveryTo { get; set; }

        [ForeignKey("DeliveryFromUser")]
        public User UserDeliveryFrom { get; set; }

        public virtual ICollection<DeliveryDetail> DeliveryDetails { get; set; }

    }
}