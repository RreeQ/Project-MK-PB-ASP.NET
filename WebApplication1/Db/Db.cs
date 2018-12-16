using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.DbContexts
{
    public class Db : DbContext
    {
        public Db() : base()
        {
        }

        public DbSet<HotDog> HotDog { get; set; }
        public DbSet<Sauce> Sauces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BestHotDogs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
 }