using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDashboard.Models
{
    [Table("TB_Card")]
    public class Card
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        public string Date_Preview { get; set; }
    }
}
