﻿// <auto-generated />
using System;
using IdentityDb.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityDb.Persistence.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20231110044741_Add Role Migration")]
    partial class AddRoleMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IdentityDb.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf"),
                            CreatedTime = new DateTime(2023, 11, 10, 4, 47, 41, 267, DateTimeKind.Utc).AddTicks(5799),
                            IsDisabled = false,
                            ModifiedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("7d07ea1f-9be7-48f0-ad91-5b83a5806baf"),
                            CreatedTime = new DateTime(2023, 11, 10, 4, 47, 41, 267, DateTimeKind.Utc).AddTicks(5803),
                            IsDisabled = false,
                            ModifiedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("df290f92-dd78-4fa7-9ce3-6b0056a8b68f"),
                            CreatedTime = new DateTime(2023, 11, 10, 4, 47, 41, 267, DateTimeKind.Utc).AddTicks(5806),
                            IsDisabled = false,
                            ModifiedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
