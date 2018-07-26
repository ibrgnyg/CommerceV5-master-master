using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommerceV3.Models
{
    public class ProductCategory
    {
		public String ProductId { get; set; }
		public Product Product { get; set; }

		public String CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
