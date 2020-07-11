using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class AdminsGymDbContext : DbContext
    {
        public AdminsGymDbContext(DbContextOptions<AdminsGymDbContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Players>()
                .HasMany(g => g.GallaryGyms)
                .WithOne(p => p.Player)
                .HasForeignKey(x => x.playerID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShowNewsType>()
                .HasMany(n => n.News)
                .WithOne(s => s.ShowNewsType)
                .HasForeignKey(x => x.isShow)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Players>()
                .HasMany<Attendance>(a => a.Attendances)
                .WithOne(p => p.Players)
                .HasForeignKey(x => x.Idplayer)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Users>()
                .HasMany<Attendance>(a => a.Attendances)
                .WithOne(p => p.Users)
                .HasForeignKey(x => x.Iduser)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Players>()
                .HasMany<DoctorsAppointment>(a => a.DoctorsAppointments)
                .WithOne(p => p.Players)
                .HasForeignKey(x => x.IDPlayer)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Users>()
                .HasMany<DoctorsAppointment>(a => a.DoctorsAppointments)
                .WithOne(p => p.Users)
                .HasForeignKey(x => x.Trainer)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Players>()
                .HasMany<Finance>(a => a.Finances)
                .WithOne(p => p.Players)
                .HasForeignKey(x => x.Idplayer)
                .OnDelete(DeleteBehavior.Cascade);
        }

        /* The identifier Of Classes To Call Him With Dbset's */

        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Clubs> Clubs { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Extra> Extra { get; set; }
        public virtual DbSet<Finance> Finance { get; set; }
        public virtual DbSet<Finish> Finish { get; set; }
        public virtual DbSet<FitnessTest> FitnessTest { get; set; }
        public virtual DbSet<FootWork> FootWork { get; set; }
        public virtual DbSet<Injury> Injury { get; set; }
        public virtual DbSet<Load> Load { get; set; }
        public virtual DbSet<LowerMachiens> LowerMachiens { get; set; }
        public virtual DbSet<Measurement> Measurement { get; set; }
        public virtual DbSet<Pool> Pool { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<ProgramForm> ProgramForm { get; set; }
        public virtual DbSet<Recovery> Recovery { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Sports> Sports { get; set; }
        public virtual DbSet<UpperMachiens> UpperMachiens { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Videofiles> Videofiles { get; set; }
        public virtual DbSet<WarmUp> WarmUp { get; set; }
        public DbSet<GallaryGym> gallarygym { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ShowNewsType> ShowNewsTypes { get; set; }
        public DbSet<GallaryStaticImage> GallaryStaticImages { get; set; }
        public DbSet<Players> Players { get; set; }
    }
}
