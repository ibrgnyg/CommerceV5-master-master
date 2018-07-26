using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommerceV3.Models
{
    public class CartItem
    {
		public String Id { get; set; }
        [Display(Name = "Sepet")]
        public String CartId { get; set; }
        [Display(Name = "Sepet")]
        [ForeignKey("CartId")]
		public Cart Cart { get; set; }

        [Display(Name = "Ürün")]
        public String ProductId { get; set; }
        [Display(Name = "Ürün")]
        [ForeignKey("ProductId")]
		public Product Product { get; set; }

        [Display(Name = "Adet")]
        public int Quantity { get; set; }

		[NotMapped]
		public decimal TotalPrice {
			get
			{
				return Product.Price * Quantity;
			}
		}
	}
}
