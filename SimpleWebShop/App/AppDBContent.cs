﻿using Microsoft.EntityFrameworkCore;
using SimpleWebShop.App.Models;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace SimpleWebShop.App
{
    public class AppDBContent : DbContext
    {

        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) 
        {
            
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
