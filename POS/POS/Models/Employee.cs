using System;
using POS.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using POS.Models;

namespace POS.Models
{

    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180414183005_Initial")]
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int EmployerID { get; set; }

        [Required]
        public int StoreID { get; set; }

        [Required, StringLength(50), Display(Name = "First Name")]
        public string FName { get; set; }

        [Required, StringLength(50), Display(Name = "Middle Initial")]
        public string MInit { get; set; }

        [Required, StringLength(50), Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required, StringLength(50)]
        public string JobTitle { get; set; }

        [Required, StringLength(50)]
        public string Supervisor { get; set; }

        [Required, StringLength(50)]
        public int E_streetNum { get; set; }

        [Required, StringLength(50)]
        public string E_StreetName { get; set; }

        [Required, StringLength(50)]
        public string E_CityState { get; set; }

        [Required]
        public int E_zipCode { get; set; }
    }
}