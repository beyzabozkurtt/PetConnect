using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace finalp.Models
{
    [Table("tbl_adopt")]
    public class tbl_adopt
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(50), Required]
        public string tur { get; set; }

        [StringLength(50), Required]
        public string isim { get; set; }

        [StringLength(50), Required]
        public string cinsiyet { get; set; }

        [Required]
        public string yas { get; set; }

        [StringLength(50), Required]
        public string cins { get; set; }

        [StringLength(100), Required]
        public string ozellik { get; set; }



    }
}