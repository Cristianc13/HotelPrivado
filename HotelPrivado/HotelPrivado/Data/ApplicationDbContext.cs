using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelPrivado.Models;

namespace HotelPrivado.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HotelPrivado.Models.Tipo> Tipo { get; set; }
        public DbSet<HotelPrivado.Models.Habitacion> Habitacion { get; set; }
        public DbSet<HotelPrivado.Models.Alquiler> Alquiler { get; set; }

        public DbSet<HotelPrivado.Models.Cliente> Cliente { get; set; }
        public DbSet<HotelPrivado.Models.Vendedor> Vendedor { get; set; }

    }
}
