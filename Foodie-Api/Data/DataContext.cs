using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Foodie_Api.Models;


namespace Foodie_Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        // Name of the Db will be the name of the table like Users
        public DbSet<User> Users => Set<User>();
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Items> Items => Set<Items>();
        public DbSet<Booking> Booking => Set<Booking>();
    }
}