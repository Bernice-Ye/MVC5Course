using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class ProductList
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1, 9999, ErrorMessage = "輸入價格需介於1~9999之間")]
        public Nullable<decimal> Price { get; set; }
        [Required]
        [Range(0, 9999, ErrorMessage = "輸入數字需介於0~9999之間")]
        public Nullable<decimal> Stock { get; set; }

    }
}