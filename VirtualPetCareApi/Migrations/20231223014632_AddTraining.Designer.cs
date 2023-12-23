﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VirtualPetCareApi.Database;

#nullable disable

namespace VirtualPetCareApi.Migrations
{
    [DbContext(typeof(GameDbContext))]
    [Migration("20231223014632_AddTraining")]
    partial class AddTraining
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VirtualPetCareApi.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CleanlinessReduction")
                        .HasColumnType("integer");

                    b.Property<int>("HappinessBonus")
                        .HasColumnType("integer");

                    b.Property<int>("HealthBonus")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.ActivityPet", b =>
                {
                    b.Property<int>("PetId")
                        .HasColumnType("integer");

                    b.Property<int>("ActivityId")
                        .HasColumnType("integer");

                    b.HasKey("PetId", "ActivityId");

                    b.HasIndex("ActivityId");

                    b.ToTable("ActivityPet");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HealthBonus")
                        .HasColumnType("integer");

                    b.Property<int>("HungerReduction")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.FoodPet", b =>
                {
                    b.Property<int>("PetId")
                        .HasColumnType("integer");

                    b.Property<int>("FoodId")
                        .HasColumnType("integer");

                    b.HasKey("PetId", "FoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("FoodPet");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.HealthStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CleanlinessLevel")
                        .HasColumnType("integer");

                    b.Property<int>("HappinessLevel")
                        .HasColumnType("integer");

                    b.Property<int>("Health")
                        .HasColumnType("integer");

                    b.Property<int>("HungerLevel")
                        .HasColumnType("integer");

                    b.Property<int>("PetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PetId")
                        .IsUnique();

                    b.ToTable("HealthStatuses");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<decimal>("Fee")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.ActivityPet", b =>
                {
                    b.HasOne("VirtualPetCareApi.Models.Activity", "Activity")
                        .WithMany("ActivityPets")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VirtualPetCareApi.Models.Pet", "Pet")
                        .WithMany("ActivityPets")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.FoodPet", b =>
                {
                    b.HasOne("VirtualPetCareApi.Models.Food", "Food")
                        .WithMany("FoodPets")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VirtualPetCareApi.Models.Pet", "Pet")
                        .WithMany("FoodPets")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.HealthStatus", b =>
                {
                    b.HasOne("VirtualPetCareApi.Models.Pet", "Pet")
                        .WithOne("HealthStatus")
                        .HasForeignKey("VirtualPetCareApi.Models.HealthStatus", "PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.Pet", b =>
                {
                    b.HasOne("VirtualPetCareApi.Models.User", "User")
                        .WithMany("Pets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.Activity", b =>
                {
                    b.Navigation("ActivityPets");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.Food", b =>
                {
                    b.Navigation("FoodPets");
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.Pet", b =>
                {
                    b.Navigation("ActivityPets");

                    b.Navigation("FoodPets");

                    b.Navigation("HealthStatus")
                        .IsRequired();
                });

            modelBuilder.Entity("VirtualPetCareApi.Models.User", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
