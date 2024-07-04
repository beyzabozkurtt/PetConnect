using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace finalp.Models
{

    public class ilanlar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Resim URL'si gereklidir.")]
        public string ResimURL { get; set; }

        [Required(ErrorMessage = "Başlık gereklidir.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olmalıdır.")]
        public string Baslik { get; set; }

        [StringLength(50, ErrorMessage = "Tür en fazla 50 karakter olmalıdır.")]
        public string Tur { get; set; }

        [StringLength(50, ErrorMessage = "Cinsi en fazla 50 karakter olmalıdır.")]
        public string Cinsi { get; set; }

        [StringLength(50, ErrorMessage = "Konum en fazla 50 karakter olmalıdır.")]
        public string Konum { get; set; }
        [StringLength(200)]
        public string DetayliBilgi { get; set; }
    }

}
