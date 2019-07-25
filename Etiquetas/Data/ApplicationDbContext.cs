using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Etiquetas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Models.Ingredientes> Ingredientes { get; set; }
        public DbSet<Models.Formulaciones> Formulaciones { get; set; }
        public DbSet<Models.Proximales> Proximales { get; set; }
        public DbSet<Models.Porciones> Porciones { get; set; }
    }
}
