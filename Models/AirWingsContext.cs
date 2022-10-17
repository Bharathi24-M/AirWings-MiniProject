using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AirWings.Models
{
    public partial class AirWingsContext : DbContext
    {
        public AirWingsContext()
        {
        }

        public AirWingsContext(DbContextOptions<AirWingsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citydetail> Citydetails { get; set; } = null!;
        public virtual DbSet<Flightdetail> Flightdetails { get; set; } = null!;
        public virtual DbSet<Offer> Offers { get; set; } = null!;
        public virtual DbSet<Paymentmode> Paymentmodes { get; set; } = null!;
        public virtual DbSet<Register> Registers { get; set; } = null!;
        public virtual DbSet<Ticketdetail> Ticketdetails { get; set; } = null!;
        public virtual DbSet<Tripdetail> Tripdetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LHUHC4U\\SQLEXPRESS;Database=AirWings;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citydetail>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__citydeta__B4BEB95EDAD39A8F");

                entity.ToTable("citydetails");

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.Property(e => e.Cityname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cityname");
            });

            modelBuilder.Entity<Flightdetail>(entity =>
            {
                entity.HasKey(e => e.FlightId)
                    .HasName("PK__flightde__0E018642D6E1DD11");

                entity.ToTable("flightdetails");

                entity.Property(e => e.FlightId).HasColumnName("flightId");

                entity.Property(e => e.Business).HasColumnName("business");

                entity.Property(e => e.Economic).HasColumnName("economic");

                entity.Property(e => e.FlightName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("flightName");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("offer");

                entity.Property(e => e.Offerid).HasColumnName("offerid");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Offername)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("offername");

                entity.Property(e => e.Offerprice).HasColumnName("offerprice");
            });

            modelBuilder.Entity<Paymentmode>(entity =>
            {
                entity.HasKey(e => e.Paymodeid)
                    .HasName("PK__paymentm__3C99DD26909C53A6");

                entity.ToTable("paymentmode");

                entity.Property(e => e.Paymodeid).HasColumnName("paymodeid");

                entity.Property(e => e.Paymode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("paymode");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.Regid)
                    .HasName("PK__register__184A6B04A32551EE");

                entity.ToTable("register");

                entity.Property(e => e.Regid).HasColumnName("regid");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("emailId");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.Psword)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("psword");

                entity.Property(e => e.Username)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Ticketdetail>(entity =>
            {
                entity.HasKey(e => e.Pnr)
                    .HasName("PK__ticketde__DD37C14C995991CA");

                entity.ToTable("ticketdetails");

                entity.Property(e => e.Pnr).HasColumnName("pnr");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Emailaddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fare).HasColumnName("fare");

                entity.Property(e => e.Netamount).HasColumnName("netamount");

                entity.Property(e => e.Offerid).HasColumnName("offerid");

                entity.Property(e => e.Passengername)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("passengername");

                entity.Property(e => e.Passengerpnumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("passengerpnumber");

                entity.Property(e => e.Paymodeid).HasColumnName("paymodeid");

                entity.Property(e => e.Taxamount).HasColumnName("taxamount");

                entity.Property(e => e.Ticketstatus).HasColumnName("ticketstatus");

                entity.Property(e => e.Tripid).HasColumnName("tripid");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.Ticketdetails)
                    .HasForeignKey(d => d.Offerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticketdet__offer__44FF419A");

                entity.HasOne(d => d.Paymode)
                    .WithMany(p => p.Ticketdetails)
                    .HasForeignKey(d => d.Paymodeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticketdet__paymo__45F365D3");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Ticketdetails)
                    .HasForeignKey(d => d.Tripid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticketdet__tripi__440B1D61");
            });

            modelBuilder.Entity<Tripdetail>(entity =>
            {
                entity.HasKey(e => e.TripId)
                    .HasName("PK__tripdeta__303EBF85CC5E06C2");

                entity.ToTable("tripdetails");

                entity.Property(e => e.TripId).HasColumnName("tripId");

                entity.Property(e => e.Arrivaltime)
                    .HasColumnType("datetime")
                    .HasColumnName("arrivaltime");

                entity.Property(e => e.Availableseats).HasColumnName("availableseats");

                entity.Property(e => e.Businessavailableseats).HasColumnName("businessavailableseats");

                entity.Property(e => e.Businessfare).HasColumnName("businessfare");

                entity.Property(e => e.Departuretime)
                    .HasColumnType("datetime")
                    .HasColumnName("departuretime");

                entity.Property(e => e.Destination).HasColumnName("destination");

                entity.Property(e => e.Fare).HasColumnName("fare");

                entity.Property(e => e.FlightId).HasColumnName("flightId");

                entity.Property(e => e.Origin).HasColumnName("origin");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Tripdetails)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tripdetai__fligh__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
