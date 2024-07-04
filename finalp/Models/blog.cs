using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace finalp.Models
{
    public class blog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Resim URL'si gereklidir.")]
        public string ResimURL { get; set; }

        [Required(ErrorMessage = "Başlık gereklidir.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olmalıdır.")]
        public string Baslik { get; set; }

        [StringLength(50)]
        public string Yazar { get; set; }

        [Required(ErrorMessage = "Tarih gereklidir.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Tarih { get; set; }

        [StringLength(50, ErrorMessage = "Icerik en fazla 50 karakter olmalıdır.")]
        public string Icerik { get; set; }

    }
}