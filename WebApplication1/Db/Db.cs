﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.DbContext
{
    public class Db : Microsoft.EntityFrameworkCore.DbContext
    {
        public Db() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BestHotDogs;Integrated Security=True;")
        {

        }
        public DbSet<HotDog> HotDog { get; set; }
        public DbSet<Sauce> Sauces { get; set; }

    }
}