using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccessLayer.Models
{
    public partial class CommerceforallContext : DbContext
    {
        public CommerceforallContext()
        {
        }

        public CommerceforallContext(DbContextOptions<CommerceforallContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Orderdetail> Orderdetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = tcp:commerceforall.database.windows.net,1433; Initial Catalog = Commerceforall; Persist Security Info = False; User ID = dbcloudadmin; Password = Commerceconnect1; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Categoryid)
                    .ValueGeneratedNever()
                    .HasColumnName("categoryid");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(50)
                    .HasColumnName("categoryname");

                entity.Property(e => e.Productname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("productname");
            });

            modelBuilder.Entity<Orderdetail>(entity =>
            {
                entity.HasKey(e => e.Orderid);

                entity.HasIndex(e => e.Productid, "IX_Orderdetails_Productid");

                entity.HasIndex(e => e.Userid, "IX_Orderdetails_userid");

                entity.Property(e => e.Gpslocation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gpslocation");

                entity.Property(e => e.Quotation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("quotation");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Verification)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("verification");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orderdetails_products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orderdetails_users");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.Categoryid, "IX_products_categoryid");

                entity.Property(e => e.Productid).ValueGeneratedNever();

                entity.Property(e => e.Available)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Gpslocation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gpslocation");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("productname");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userid");

                entity.Property(e => e.Verification)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("verification");

                entity.Property(e => e.Whichdate)
                    .HasColumnType("datetime")
                    .HasColumnName("whichdate");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_products_categories");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Roleid).ValueGeneratedNever();

                entity.Property(e => e.Rolename)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Roleid, "IX_users_Roleid");

                //entity.Property(e => e.Id)
                //    .ValueGeneratedNever()
                //    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
