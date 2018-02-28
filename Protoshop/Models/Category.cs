using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Protoshop.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Du måste fylla i ett namn på kategorin.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Kategorinamnet måste vara mellan 1 och 100 tecken långt.")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}