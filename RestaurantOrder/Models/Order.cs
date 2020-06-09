using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantOrder.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "This field is required.")]
        public string Input { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "This field is required.")]
        public string Output { get; set; }

    }
}
