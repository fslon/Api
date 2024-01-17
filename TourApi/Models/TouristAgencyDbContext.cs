using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TourApi.Models
{
    public partial class TouristAgencyDbContext : DbContext
    {
        public TouristAgencyDbContext()
        {
        }

        public TouristAgencyDbContext(DbContextOptions<TouristAgencyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<FoodSystem> FoodSystems { get; set; }
        public virtual DbSet<FoodType> FoodTypes { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderTour> OrderTours { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserOrder> UserOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-J8BIJAB;Database=TouristAgencyDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityName);

                entity.Property(e => e.CityName).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<FoodSystem>(entity =>
            {
                entity.ToTable("Food_systems");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FoodType>(entity =>
            {
                entity.ToTable("Food_types");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.Property(e => e.AirportDistance).HasColumnName("Airport_distance");

                entity.Property(e => e.BeachDistance).HasColumnName("Beach_distance");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FoodSystem).HasColumnName("Food_system");

                entity.Property(e => e.FoodType).HasColumnName("Food_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Parking)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Photo1)
                    .IsRequired()
                    .HasColumnName("Photo_1");

                entity.Property(e => e.Photo2)
                    .IsRequired()
                    .HasColumnName("Photo_2");

                entity.Property(e => e.Photo3)
                    .IsRequired()
                    .HasColumnName("Photo_3");

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Wifi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.City)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Goods_Cities");

                entity.HasOne(d => d.FoodSystemNavigation)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.FoodSystem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Goods_Food_systems");

                entity.HasOne(d => d.FoodTypeNavigation)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.FoodType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Goods_Food_types");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TourId).HasColumnName("Tour_id");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Goods");
            });

            modelBuilder.Entity<OrderTour>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Order_Tours");

                entity.Property(e => e.GoodId).HasColumnName("Good_id");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.HasOne(d => d.Good)
                    .WithMany()
                    .HasForeignKey(d => d.GoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Tours_Goods1");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Tours_Orders");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User_orders");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_orders_Orders");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_orders_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
