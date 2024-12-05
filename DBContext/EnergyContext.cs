using DBContext.Models2;
using Microsoft.EntityFrameworkCore;

namespace DBContext
{
    public class EnergyContext : DbContext
    {
        public DbSet<Hydro> Hydros { get; set; }
        public DbSet<Thermal> Thermals { get; set; }
        public DbSet<RenewableVarious> RenewableVariouses { get; set; }
        public DbSet<CentralHydro> CentralHydros { get; set; }
        public DbSet<SmallHydro> SmallHydros { get; set; }
        public DbSet<CentralThermal> CentralThermals { get; set; }
        public DbSet<RenewableThermal> RenewableThermals { get; set; }
        public DbSet<Biogas> Biogases { get; set; }
        public DbSet<Photovoltaic> Photovoltaics { get; set; }
        public DbSet<Wind> Winds { get; set; }

        public EnergyContext(DbContextOptions<EnergyContext> options) : base(options)
        {
        }

        public EnergyContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=tcp:2024nee.database.windows.net,1433;Initial Catalog=InstallationNEE;Persist Security Info=False;User ID=neeserver;Password=AdminHevs01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Hydro relationships
            modelBuilder.Entity<Hydro>().HasKey(h => h.Id);
            modelBuilder.Entity<Hydro>()
                .HasMany(h => h.CentralHydros)
                .WithOne(ch => ch.Hydro)
                .HasForeignKey(ch => ch.HydroId);
            modelBuilder.Entity<Hydro>()
                .HasMany(h => h.SmallHydros)
                .WithOne(sh => sh.Hydro)
                .HasForeignKey(sh => sh.HydroId);

            // Thermal relationships
            modelBuilder.Entity<Thermal>().HasKey(t => t.Id);
            modelBuilder.Entity<Thermal>()
                .HasMany(t => t.CentralThermals)
                .WithOne(ct => ct.Thermal)
                .HasForeignKey(ct => ct.ThermalId);
            modelBuilder.Entity<Thermal>()
                .HasMany(t => t.RenewableThermals)
                .WithOne(rt => rt.Thermal)
                .HasForeignKey(rt => rt.ThermalId);

            // RenewableVarious relationships
            modelBuilder.Entity<RenewableVarious>().HasKey(rv => rv.Id);
            modelBuilder.Entity<RenewableVarious>()
                .HasMany(rv => rv.Biogases)
                .WithOne(b => b.RenewableVarious)
                .HasForeignKey(b => b.RenewableVariousId);
            modelBuilder.Entity<RenewableVarious>()
                .HasMany(rv => rv.Photovoltaics)
                .WithOne(p => p.RenewableVarious)
                .HasForeignKey(p => p.RenewableVariousId);
            modelBuilder.Entity<RenewableVarious>()
                .HasMany(rv => rv.Winds)
                .WithOne(w => w.RenewableVarious)
                .HasForeignKey(w => w.RenewableVariousId);

            // Seed Data for RenewableVarious (required for Biogas, Photovoltaic, and Wind)
            modelBuilder.Entity<RenewableVarious>().HasData(
                new RenewableVarious { Id = 1, Total = 0, Year = 2010 } // Adjust Total if needed
            );

            // Seed Data for Biogas with foreign key reference to RenewableVarious
            modelBuilder.Entity<Biogas>().HasData(
                new Biogas { Id = 1, Year = 2010, Total = 3, RenewableVariousId = 1 },
                new Biogas { Id = 2, Year = 2011, Total = 3, RenewableVariousId = 1 },
                new Biogas { Id = 3, Year = 2012, Total = 4, RenewableVariousId = 1 },
                new Biogas { Id = 4, Year = 2013, Total = 4, RenewableVariousId = 1 },
                new Biogas { Id = 5, Year = 2014, Total = 4, RenewableVariousId = 1 },
                new Biogas { Id = 6, Year = 2015, Total = 5, RenewableVariousId = 1 },
                new Biogas { Id = 7, Year = 2016, Total = 5, RenewableVariousId = 1 },
                new Biogas { Id = 8, Year = 2017, Total = 5, RenewableVariousId = 1 },
                new Biogas { Id = 9, Year = 2018, Total = 5, RenewableVariousId = 1 }
            );

            // Seed Data for Photovoltaic with foreign key reference to RenewableVarious
            modelBuilder.Entity<Photovoltaic>().HasData(
                new Photovoltaic { Id = 1, Year = 2010, Total = 1, RenewableVariousId = 1 },
                new Photovoltaic { Id = 2, Year = 2011, Total = 1, RenewableVariousId = 1 },
                new Photovoltaic { Id = 3, Year = 2012, Total = 6, RenewableVariousId = 1 },
                new Photovoltaic { Id = 4, Year = 2013, Total = 22, RenewableVariousId = 1 },
                new Photovoltaic { Id = 5, Year = 2014, Total = 41, RenewableVariousId = 1 },
                new Photovoltaic { Id = 6, Year = 2015, Total = 60, RenewableVariousId = 1 },
                new Photovoltaic { Id = 7, Year = 2016, Total = 67, RenewableVariousId = 1 },
                new Photovoltaic { Id = 8, Year = 2017, Total = 74, RenewableVariousId = 1 },
                new Photovoltaic { Id = 9, Year = 2018, Total = 84, RenewableVariousId = 1 }
            );

            // Seed Data for Wind with foreign key reference to RenewableVarious
            modelBuilder.Entity<Wind>().HasData(
                new Wind { Id = 1, Year = 2010, Total = 10, RenewableVariousId = 1 },
                new Wind { Id = 2, Year = 2011, Total = 9, RenewableVariousId = 1 },
                new Wind { Id = 3, Year = 2012, Total = 14, RenewableVariousId = 1 },
                new Wind { Id = 4, Year = 2013, Total = 19, RenewableVariousId = 1 },
                new Wind { Id = 5, Year = 2014, Total = 18, RenewableVariousId = 1 },
                new Wind { Id = 6, Year = 2015, Total = 18, RenewableVariousId = 1 },
                new Wind { Id = 7, Year = 2016, Total = 18, RenewableVariousId = 1 },
                new Wind { Id = 8, Year = 2017, Total = 24, RenewableVariousId = 1 },
                new Wind { Id = 9, Year = 2018, Total = 22, RenewableVariousId = 1 }
            );

            // Seed Data for Hydro (required for SmallHydro)
            modelBuilder.Entity<Hydro>().HasData(
                new Hydro { Id = 1, Total = 0, Year = 2010 } // Adjust Total if needed
            );

            // Seed Data for SmallHydro with foreign key reference to Hydro
            modelBuilder.Entity<SmallHydro>().HasData(
                new SmallHydro { Id = 1, Year = 2010, Total = 429, HydroId = 1 },
                new SmallHydro { Id = 2, Year = 2011, Total = 401, HydroId = 1 },
                new SmallHydro { Id = 3, Year = 2012, Total = 451, HydroId = 1 },
                new SmallHydro { Id = 4, Year = 2013, Total = 435, HydroId = 1 },
                new SmallHydro { Id = 5, Year = 2014, Total = 492, HydroId = 1 },
                new SmallHydro { Id = 6, Year = 2015, Total = 496, HydroId = 1 },
                new SmallHydro { Id = 7, Year = 2016, Total = 512, HydroId = 1 },
                new SmallHydro { Id = 8, Year = 2017, Total = 474, HydroId = 1 },
                new SmallHydro { Id = 9, Year = 2018, Total = 549, HydroId = 1 }
            );

            modelBuilder.Entity<SmallHydro>().ToTable("SmallHydro");
            modelBuilder.Entity<Biogas>().ToTable("Biogas");
            modelBuilder.Entity<Photovoltaic>().ToTable("Photovoltaic");
            modelBuilder.Entity<Wind>().ToTable("Wind");

        }

    }
}

