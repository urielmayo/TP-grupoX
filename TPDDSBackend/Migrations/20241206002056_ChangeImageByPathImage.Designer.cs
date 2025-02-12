﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TPDDSBackend.Domain.EF.DBContexts;

#nullable disable

namespace TPDDSBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241206002056_ChangeImageByPathImage")]
    partial class ChangeImageByPathImage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entities.BenefitExchange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BenefitId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BenefitId");

                    b.HasIndex("UserId");

                    b.ToTable("BenefitExchanges");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entities.FridgeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("MaxTemperature")
                        .HasColumnType("real");

                    b.Property<float>("MinTemperature")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FridgeModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModificationAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxTemperature = 10f,
                            MinTemperature = -5f,
                            Name = "DefaultModel"
                        });
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.Collaborator", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("Collaborator");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.Contribution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CollaboratorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<DateTime>("LastModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CollaboratorId");

                    b.ToTable("Contributions");

                    b.HasDiscriminator().HasValue("Contribution");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.DeliveryReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ReasonDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DeliveryReasons");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Calories")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FridgeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("FridgeId");

                    b.HasIndex("StateId");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.FoodState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("FoodState");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.FoodXDelivery", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnType("integer");

                    b.Property<int>("DeliveryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("FoodId", "DeliveryId");

                    b.HasIndex("DeliveryId");

                    b.ToTable("FoodXDelivery");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.Fridge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FridgeModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("LastModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("LastTemperature")
                        .HasColumnType("real");

                    b.Property<decimal>("Latitud")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Longitud")
                        .HasColumnType("numeric");

                    b.Property<int>("MaxFoodCapacity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("SetUpAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FridgeModelId");

                    b.ToTable("Fridge");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.Neighborhood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Neighborhoods");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.PersonInVulnerableSituation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("text");

                    b.Property<int?>("DocumentTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MinorsInCare")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.ToTable("PersonInVulnerableSituations");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.Technician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NeighborhoodId")
                        .HasColumnType("integer");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WorkerIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("NeighborhoodId");

                    b.ToTable("Technicians");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.HumanPerson", b =>
                {
                    b.HasBaseType("TPDDSBackend.Domain.Entitites.Collaborator");

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("HumanPerson");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.LegalPerson", b =>
                {
                    b.HasBaseType("TPDDSBackend.Domain.Entitites.Collaborator");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrganizationType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("LegalPerson");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entities.Benefit", b =>
                {
                    b.HasBaseType("TPDDSBackend.Domain.Entitites.Contribution");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RequiredPoints")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("Benefit");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entities.Card", b =>
                {
                    b.HasBaseType("TPDDSBackend.Domain.Entitites.Contribution");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PersonInVulnerableSituationId")
                        .HasColumnType("integer");

                    b.HasIndex("PersonInVulnerableSituationId");

                    b.HasDiscriminator().HasValue("Card");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.FoodDelivery", b =>
                {
                    b.HasBaseType("TPDDSBackend.Domain.Entitites.Contribution");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int>("DeliveryReasonId")
                        .HasColumnType("integer");

                    b.Property<int>("DestinationFridgeId")
                        .HasColumnType("integer");

                    b.Property<int>("OriginFridgeId")
                        .HasColumnType("integer");

                    b.HasIndex("DeliveryReasonId");

                    b.HasIndex("DestinationFridgeId");

                    b.HasIndex("OriginFridgeId");

                    b.HasDiscriminator().HasValue("FoodDelivery");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.FoodDonation", b =>
                {
                    b.HasBaseType("TPDDSBackend.Domain.Entitites.Contribution");

                    b.Property<int?>("DoneeId")
                        .HasColumnType("integer");

                    b.Property<int>("FoodId")
                        .HasColumnType("integer");

                    b.HasIndex("DoneeId");

                    b.HasIndex("FoodId");

                    b.HasDiscriminator().HasValue("FoodDonation");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.FridgeOwner", b =>
                {
                    b.HasBaseType("TPDDSBackend.Domain.Entitites.Contribution");

                    b.Property<int>("FridgeId")
                        .HasColumnType("integer");

                    b.HasIndex("FridgeId");

                    b.HasDiscriminator().HasValue("FridgeOwner");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.MoneyDonation", b =>
                {
                    b.HasBaseType("TPDDSBackend.Domain.Entitites.Contribution");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Contributions", t =>
                        {
                            t.Property("Amount")
                                .HasColumnName("MoneyDonation_Amount");
                        });

                    b.HasDiscriminator().HasValue("MoneyDonation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TPDDSBackend.Domain.Entitites.Collaborator", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TPDDSBackend.Domain.Entitites.Collaborator", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPDDSBackend.Domain.Entitites.Collaborator", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TPDDSBackend.Domain.Entitites.Collaborator", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entities.BenefitExchange", b =>
                {
                    b.HasOne("TPDDSBackend.Domain.Entities.Benefit", "Benefit")
                        .WithMany()
                        .HasForeignKey("BenefitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPDDSBackend.Domain.Entitites.Collaborator", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benefit");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.Contribution", b =>
                {
                    b.HasOne("TPDDSBackend.Domain.Entitites.Collaborator", "Collaborator")
                        .WithMany()
                        .HasForeignKey("CollaboratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collaborator");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.Food", b =>
                {
                    b.HasOne("TPDDSBackend.Domain.Entitites.Fridge", "Fridge")
                        .WithMany()
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPDDSBackend.Domain.Entitites.FoodState", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");

                    b.Navigation("State");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.FoodXDelivery", b =>
                {
                    b.HasOne("TPDDSBackend.Domain.Entitites.FoodDelivery", "Delivery")
                        .WithMany()
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPDDSBackend.Domain.Entitites.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delivery");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.Fridge", b =>
                {
                    b.HasOne("TPDDSBackend.Domain.Entities.FridgeModel", "Model")
                        .WithMany()
                        .HasForeignKey("FridgeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.PersonInVulnerableSituation", b =>
                {
                    b.HasOne("TPDDSBackend.Domain.Entitites.DocumentType", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId");

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.Technician", b =>
                {
                    b.HasOne("TPDDSBackend.Domain.Entitites.DocumentType", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPDDSBackend.Domain.Entitites.Neighborhood", "Neighborhood")
                        .WithMany()
                        .HasForeignKey("NeighborhoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("Neighborhood");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entities.Card", b =>
                {
                    b.HasOne("TPDDSBackend.Domain.Entitites.PersonInVulnerableSituation", "Owner")
                        .WithMany()
                        .HasForeignKey("PersonInVulnerableSituationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.FoodDelivery", b =>
                {
                    b.HasOne("TPDDSBackend.Domain.Entitites.DeliveryReason", "DeliveryReason")
                        .WithMany()
                        .HasForeignKey("DeliveryReasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPDDSBackend.Domain.Entitites.Fridge", "DestinationFridge")
                        .WithMany()
                        .HasForeignKey("DestinationFridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPDDSBackend.Domain.Entitites.Fridge", "OriginFridge")
                        .WithMany()
                        .HasForeignKey("OriginFridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryReason");

                    b.Navigation("DestinationFridge");

                    b.Navigation("OriginFridge");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.FoodDonation", b =>
                {
                    b.HasOne("TPDDSBackend.Domain.Entitites.PersonInVulnerableSituation", "Donee")
                        .WithMany()
                        .HasForeignKey("DoneeId");

                    b.HasOne("TPDDSBackend.Domain.Entitites.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donee");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("TPDDSBackend.Domain.Entitites.FridgeOwner", b =>
                {
                    b.HasOne("TPDDSBackend.Domain.Entitites.Fridge", "Fridge")
                        .WithMany()
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");
                });
#pragma warning restore 612, 618
        }
    }
}
