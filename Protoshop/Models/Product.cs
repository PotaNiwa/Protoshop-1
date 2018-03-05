using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Protoshop.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Du måste fylla i namn.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Du måste fylla i en beskrivning.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Beskrivningen måste vara mellan 10 och 500 tecken lång.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Du måste fylla i ett pris.")]
        [Range(0,10000, ErrorMessage = "Priset måste vara mellan 0 och 10000 kr.")]
        public double Price { get; set; }

        public string ImageFile { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}