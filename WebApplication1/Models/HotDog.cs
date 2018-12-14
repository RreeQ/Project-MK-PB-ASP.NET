using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class HotDog
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int SauceId { get; set; }
        public Sauce Sauce { get; set; }
        public int Phone { get; set; }


    }
}