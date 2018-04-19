using System;
using POS.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{

    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180414183005_Initial")]
    public class Inventory
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Inventory_PID { get; set; }

        [Required, StringLength(50), Display(Name = "Product Name")]
        public string I_productName { get; set; }

        [Required, StringLength(50), Display(Name = "Product Brand")]
        public string I_productBrand { get; set; }

        [Required, StringLength(50), Display(Name = "Product Model")]
        public string I_productModel { get; set; }

        [Required, StringLength(50)]
        public string ModelNumber { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int Product_PID { get; set; }

        [Required]
        public int ProductQTY { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdated { get; set; }

        public virtual ICollection<Sup_Trans> GetSup_Trans { get; set; }
    }
}
