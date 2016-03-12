using System;
namespace MVC5Course.Models
{
    interface IProduct
    {
        bool? Active { get; set; }
        decimal? Price { get; set; }
        int ProductId { get; set; }
        string ProductName { get; set; }
    }
}
