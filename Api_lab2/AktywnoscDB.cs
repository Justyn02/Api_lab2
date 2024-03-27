using Api_lab2;
using Lab2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class AktywnoscDB : DbContext
    {
        public DbSet<Aktywnosc> aktywnosc { get; set; }
        public AktywnoscDB()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"DataSource=Aktywnosc.db");
        }


    }
}
