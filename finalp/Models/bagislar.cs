using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace finalp.Models
{
    public class bagislar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim gereklidir.")]
        public string Isim { get; set; }

        [Required(ErrorMessage = "Soyisim gereklidir.")]
        public string Soyisim { get; set; }

        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Tutar gereklidir.")]
        [Range(0, double.MaxValue, ErrorMessage = "Geçerli bir tutar giriniz.")]
        public decimal Tutar { get; set; }

        [Required(ErrorMessage = "Ödeme şekli gereklidir.")]
        public string Odeme { get; set; }
    }
}