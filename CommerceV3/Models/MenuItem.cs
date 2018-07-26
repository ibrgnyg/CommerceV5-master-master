using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommerceV3.Models
{
    public class MenuItem
    {
		public String Id { get; set; }
		[Display(Name = "Menü Öğesi Adı")]
		public String Name { get; set; }
		[Display(Name = "Bağlantı")]
		public String Url { get; set; }
		[Display(Name = "Hedef")]
		public String Target { get; set; }
		[Display(Name = "Yayında Mı ?")]
		public bool IsPublished { get; set; }
		[Display(Name = "Pozisyon")]
		public int Position { get; set; }

        [Display(Name = "Üst Menü Öğesi")]
        public string ParentMenuItemId { get; set; }
        [Display(Name = "Üst Menü Öğesi")]
        [ForeignKey("ParentMenuItemId")]
		public MenuItem ParentMenuItem { get; set; }
		public virtual ICollection<MenuItem> ChildMenuItems { get; set; }

	}
}
