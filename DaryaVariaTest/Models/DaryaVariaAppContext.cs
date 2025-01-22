using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DaryaVariaTest.Models;

public partial class DaryaVariaAppContext : DbContext
{
    public DaryaVariaAppContext()
    {
    }

    public DaryaVariaAppContext(DbContextOptions<DaryaVariaAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountDetail> AccountDetails { get; set; }

    public virtual DbSet<AccountRole> AccountRoles { get; set; }

    public virtual DbSet<InformationOfPayment> InformationOfPayments { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<LoginAuth> LoginAuths { get; set; }

    public virtual DbSet<LoginAuth2> LoginAuth2s { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsTransaction> ProductsTransactions { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<UnitType> UnitTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__349DA5A68E487DFA");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Accounts__85FB4E380FBE4B70").IsUnique();

            entity.HasIndex(e => e.BankAccount, "UQ__Accounts__E166594B822F55F2").IsUnique();

            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.BankAccount)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<AccountDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountD__3214EC07827895D4");

            entity.ToTable("AccountDetail");

            entity.HasIndex(e => e.AccountId, "IX_AccountDetail_AccountId");

            entity.Property(e => e.AccountType)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountDetails)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AccountDe__Accou__4BAC3F29");
        });

        modelBuilder.Entity<AccountRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountR__3214EC07BAA1B787");

            entity.ToTable("AccountRole");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<InformationOfPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Informat__3214EC07E71E5E8B");

            entity.ToTable("InformationOfPayment");

            entity.HasIndex(e => e.TransactionId, "IX_InformationOfPayment_TransactionId");

            entity.Property(e => e.FromBankNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("paymentMethod");
            entity.Property(e => e.ToBankNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Transaction).WithMany(p => p.InformationOfPayments)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK__Informati__Trans__66603565");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC07ED833853");

            entity.ToTable("Inventory");

            entity.HasIndex(e => e.ProductId, "IX_Inventory_ProductId");

            entity.HasIndex(e => e.UnitTypeId, "IX_Inventory_UnitTypeId");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasDefaultValue(0);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Produ__5812160E");

            entity.HasOne(d => d.UnitType).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.UnitTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__UnitT__59063A47");
        });

        modelBuilder.Entity<LoginAuth>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LoginAuth");

            entity.HasIndex(e => e.AccountId, "IX_LoginAuth_AccountId");

            entity.HasIndex(e => e.Username, "UQ__LoginAut__536C85E4B3DA3FBA").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__LoginAut__A9D10534C9131876").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash).IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserRole)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LoginAuth__Accou__45F365D3");
        });

        modelBuilder.Entity<LoginAuth2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LoginAuth2");

            entity.HasIndex(e => e.Username, "UQ__LoginAut__536C85E4FCBEB718").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__LoginAut__A9D1053477324F3B").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash).IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserRole)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LoginAuth__Accou__70DDC3D8");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC0731DC068C");

            entity.HasIndex(e => e.AccountId, "IX_Products_AccountId");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Products)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Accoun__5070F446");
        });

        modelBuilder.Entity<ProductsTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC076C14038F");

            entity.ToTable("ProductsTransaction");

            entity.HasIndex(e => e.ProductId, "IX_ProductsTransaction_ProductId");

            entity.HasIndex(e => e.TransactionId, "IX_ProductsTransaction_TransactionId");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1)
                .HasColumnName("quantity");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsTransactions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductsT__Produ__6383C8BA");

            entity.HasOne(d => d.Transaction).WithMany(p => p.ProductsTransactions)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK__ProductsT__Trans__628FA481");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC0734BBEC35");

            entity.HasIndex(e => e.AccountId, "IX_Transactions_AccountId");

            entity.Property(e => e.AccountType)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Account).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Accou__5EBF139D");
        });

        modelBuilder.Entity<UnitType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UnitType__3214EC079043CF4F");

            entity.ToTable("UnitType");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
