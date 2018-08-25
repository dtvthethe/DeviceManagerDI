using DeviceManager.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Model.Models
{
    [Table("Categories")]
    public class Category : IIDKeyName
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        public virtual ICollection<Device> Devices { get; set; }

    }
}
