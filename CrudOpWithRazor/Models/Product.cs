﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudOpWithRazor.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required]
        public double Price { get; set; }

        public int Quantity { get; set; }


    }
}
