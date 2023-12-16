using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün adı boş bırakılamaz.")]
        [MaxLength(50)]
        [DisplayName("Ürün")]
       
        public string ProductName { get; set; }


        [Required(ErrorMessage = "Ücret boş bırakılamaz.")]
        [DisplayName("Ücret")]
        public decimal? Price { get; set; }


        [Required(ErrorMessage = "Adet boş bırakılamaz.")]
        [DisplayName("Adet")]
        public int? Quantity { get; set; }

    }
}
