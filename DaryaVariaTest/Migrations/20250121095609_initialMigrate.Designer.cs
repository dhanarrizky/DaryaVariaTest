﻿// <auto-generated />
using System;
using DaryaVariaTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DaryaVariaTest.Migrations
{
    [DbContext(typeof(DaryaVariaAppContext))]
    [Migration("20250121095609_initialMigrate")]
    partial class initialMigrate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DaryaVariaTest.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("BankAccount")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("AccountId")
                        .HasName("PK__Accounts__349DA5A68E487DFA");

                    b.HasIndex(new[] { "PhoneNumber" }, "UQ__Accounts__85FB4E380FBE4B70")
                        .IsUnique();

                    b.HasIndex(new[] { "BankAccount" }, "UQ__Accounts__E166594B822F55F2")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DaryaVariaTest.Models.AccountDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("Id")
                        .HasName("PK__AccountD__3214EC07827895D4");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountDetail", (string)null);
                });

            modelBuilder.Entity("DaryaVariaTest.Models.AccountRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("Id")
                        .HasName("PK__AccountR__3214EC07BAA1B787");

                    b.ToTable("AccountRole", (string)null);
                });

            modelBuilder.Entity("DaryaVariaTest.Models.InformationOfPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FromBankNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Note")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime");

                    b.Property<string>("PaymentMethod")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("paymentMethod");

                    b.Property<string>("ToBankNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Informat__3214EC07E71E5E8B");

                    b.HasIndex("TransactionId");

                    b.ToTable("InformationOfPayment", (string)null);
                });

            modelBuilder.Entity("DaryaVariaTest.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("UnitTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("Id")
                        .HasName("PK__Inventor__3214EC07ED833853");

                    b.HasIndex("ProductId");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("Inventory", (string)null);
                });

            modelBuilder.Entity("DaryaVariaTest.Models.LoginAuth", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasIndex("AccountId");

                    b.HasIndex(new[] { "Username" }, "UQ__LoginAut__536C85E4B3DA3FBA")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__LoginAut__A9D10534C9131876")
                        .IsUnique();

                    b.HasIndex(new[] { "PasswordHash" }, "UQ__LoginAut__D60E46A2D7C49C48")
                        .IsUnique();

                    b.ToTable("LoginAuth", (string)null);
                });

            modelBuilder.Entity("DaryaVariaTest.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("Id")
                        .HasName("PK__Products__3214EC0731DC068C");

                    b.HasIndex("AccountId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DaryaVariaTest.Models.ProductsTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("quantity");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Products__3214EC076C14038F");

                    b.HasIndex("ProductId");

                    b.HasIndex("TransactionId");

                    b.ToTable("ProductsTransaction", (string)null);
                });

            modelBuilder.Entity("DaryaVariaTest.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Note")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Status")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id")
                        .HasName("PK__Transact__3214EC0734BBEC35");

                    b.HasIndex("AccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("DaryaVariaTest.Models.UnitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("Id")
                        .HasName("PK__UnitType__3214EC079043CF4F");

                    b.ToTable("UnitType", (string)null);
                });

            modelBuilder.Entity("DaryaVariaTest.Models.AccountDetail", b =>
                {
                    b.HasOne("DaryaVariaTest.Models.Account", "Account")
                        .WithMany("AccountDetails")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK__AccountDe__Accou__4BAC3F29");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DaryaVariaTest.Models.InformationOfPayment", b =>
                {
                    b.HasOne("DaryaVariaTest.Models.Transaction", "Transaction")
                        .WithMany("InformationOfPayments")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Informati__Trans__66603565");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("DaryaVariaTest.Models.Inventory", b =>
                {
                    b.HasOne("DaryaVariaTest.Models.Product", "Product")
                        .WithMany("Inventories")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__Inventory__Produ__5812160E");

                    b.HasOne("DaryaVariaTest.Models.UnitType", "UnitType")
                        .WithMany("Inventories")
                        .HasForeignKey("UnitTypeId")
                        .IsRequired()
                        .HasConstraintName("FK__Inventory__UnitT__59063A47");

                    b.Navigation("Product");

                    b.Navigation("UnitType");
                });

            modelBuilder.Entity("DaryaVariaTest.Models.LoginAuth", b =>
                {
                    b.HasOne("DaryaVariaTest.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK__LoginAuth__Accou__45F365D3");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DaryaVariaTest.Models.Product", b =>
                {
                    b.HasOne("DaryaVariaTest.Models.Account", "Account")
                        .WithMany("Products")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK__Products__Accoun__5070F446");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DaryaVariaTest.Models.ProductsTransaction", b =>
                {
                    b.HasOne("DaryaVariaTest.Models.Product", "Product")
                        .WithMany("ProductsTransactions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ProductsT__Produ__6383C8BA");

                    b.HasOne("DaryaVariaTest.Models.Transaction", "Transaction")
                        .WithMany("ProductsTransactions")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ProductsT__Trans__628FA481");

                    b.Navigation("Product");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("DaryaVariaTest.Models.Transaction", b =>
                {
                    b.HasOne("DaryaVariaTest.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK__Transacti__Accou__5EBF139D");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DaryaVariaTest.Models.Account", b =>
                {
                    b.Navigation("AccountDetails");

                    b.Navigation("Products");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("DaryaVariaTest.Models.Product", b =>
                {
                    b.Navigation("Inventories");

                    b.Navigation("ProductsTransactions");
                });

            modelBuilder.Entity("DaryaVariaTest.Models.Transaction", b =>
                {
                    b.Navigation("InformationOfPayments");

                    b.Navigation("ProductsTransactions");
                });

            modelBuilder.Entity("DaryaVariaTest.Models.UnitType", b =>
                {
                    b.Navigation("Inventories");
                });
#pragma warning restore 612, 618
        }
    }
}
