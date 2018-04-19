using System;
using POS.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using POS.Models;

namespace POS.Models
{

    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180414183005_Initial")]
    public class Sales
    {
        [Required, StringLength(50)]
        public string S_productName { get; set; }

        [Required, StringLength(50)]
        public string S_productModel { get; set; }

        [Required, StringLength(50)]
        public string S_productBrand { get; set; }

        [Required, Display(Name = "Cost")]
        public decimal S_productCost { get; set; }

        [Required, Display(Name = "Order Total")]
        public decimal OrderTotal { get; set; }

        public decimal DiscountPercentage { get; set; }

        [Required]
        public int TransactionID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TransactionDate { get; set; }

        [Required, Key]
        public int Sales_PID { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [Required]
        public decimal RetailCost { get; set; }

        [Required]
        public int SalesUpdate { get; set; }

        public virtual ICollection<Product> GetProducts { get; set; } 
    }
}