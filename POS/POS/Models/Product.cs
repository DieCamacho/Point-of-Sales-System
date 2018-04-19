using POS.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace POS.Models
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180414183005_Initial")]
    public class Product
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        public int PID { get; set; }

        [Required, StringLength(50), Display(Name = "Name")]
        public string ProductName { get; set; }

        [Required, StringLength(50), Display(Name = "Product Brand")]
        public string I_productBrand { get; set; }

        [Required, StringLength(50), Display(Name = "Product Model")]
        public string I_productModel { get; set; }

        [Required, Display(Name = "Price")]
        public double ProductCost { get; set; }
        
        [Required, StringLength(50), Display(Name = "Model Number")]
        public string ModelNumber { get; set; }

        public virtual ICollection<Inventory> GetInventories { get; set; }
    }
}
