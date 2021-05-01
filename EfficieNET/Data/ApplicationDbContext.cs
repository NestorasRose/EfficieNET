using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VRtour.Lib.Models;

namespace EfficieNET.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BuyRealEstate> Buy { get; set; }

        public DbSet<RentRealEstate> Rent { get; set; }

        public DbSet<BookRealEstate> Book { get; set; }
    }
}
