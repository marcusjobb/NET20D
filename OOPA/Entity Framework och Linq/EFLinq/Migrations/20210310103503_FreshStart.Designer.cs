﻿// <auto-generated />
using System;
using EFLinq.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFLinq.Migrations
{
    [DbContext(typeof(EFLinqContext))]
    [Migration("20210310103503_FreshStart")]
    partial class FreshStart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFLinq.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("House");
                });

            modelBuilder.Entity("EFLinq.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("EFLinq.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("HousePerson", b =>
                {
                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<int>("TenantsId")
                        .HasColumnType("int");

                    b.HasKey("HomeId", "TenantsId");

                    b.HasIndex("TenantsId");

                    b.ToTable("HousePerson");
                });

            modelBuilder.Entity("EFLinq.Models.Pet", b =>
                {
                    b.HasOne("EFLinq.Models.Person", null)
                        .WithMany("Pets")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("HousePerson", b =>
                {
                    b.HasOne("EFLinq.Models.House", null)
                        .WithMany()
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFLinq.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("TenantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFLinq.Models.Person", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
