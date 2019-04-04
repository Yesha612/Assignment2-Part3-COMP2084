using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheIcecreamParlourAPI.Models
{
    public class Icecream
    {
        [Key]
        public int FlavourID { get; set; }

        [Required]
        public string Flavour { get; set; }
        public int Calories { get; set; }
        public bool Gluten_Free { get; set; }
        public bool Dairy_Free { get; set; }

    }
}
