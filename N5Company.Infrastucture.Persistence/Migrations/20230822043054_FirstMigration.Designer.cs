﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using N5Company.Infrastucture.Persistence.Context;

#nullable disable

namespace N5Company.Infrastucture.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230822043054_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("N5Company.Core.Domain.Entities.PermissionTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PermissionTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Doctor"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Free Day"
                        });
                });

            modelBuilder.Entity("N5Company.Core.Domain.Entities.Permissions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmployeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpolyeLastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PermissionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PermissionTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionTypeId");

                    b.ToTable("Permissions", (string)null);
                });

            modelBuilder.Entity("N5Company.Core.Domain.Entities.Permissions", b =>
                {
                    b.HasOne("N5Company.Core.Domain.Entities.PermissionTypes", "PermissionTypes")
                        .WithMany("Permissions")
                        .HasForeignKey("PermissionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionTypes");
                });

            modelBuilder.Entity("N5Company.Core.Domain.Entities.PermissionTypes", b =>
                {
                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
