using Classwork.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.DAL
{
    public class AppDbContext:IdentityDbContext<User>
    {
       
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<Slider>Sliders { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Position> Positions{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<FlowerCategory> FlowerCategories { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<FlowerImage> FlowerImages { get; set; }
        public DbSet<Layout> Layouts { get; set; }
    }
}
