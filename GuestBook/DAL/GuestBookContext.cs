using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using GuestBook.Models;

namespace GuestBook.DAL
{
    public class GuestBookContext : DbContext
    {
        public GuestBookContext() : base("GuestBookContext")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Face> Faces { get; set; }
        public DbSet<Country> Country { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}